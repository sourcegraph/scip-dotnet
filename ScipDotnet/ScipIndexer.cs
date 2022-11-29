using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

internal class ScipIndexer
{
    public ScipIndexer(Workspace workspace, ILogger<ScipIndexer> logger)
    {
        Workspace = workspace;
        Logger = logger;
    }

    public Workspace Workspace { get; }
    public ILogger<ScipIndexer> Logger { get; }

    public readonly record struct Range(int StartLine, int StartCharacter, int EndLine, int EndCharacter);
    public readonly record struct Occurrence(Range Range, string Symbol, int Role);
    public readonly record struct IndexedDocument(string RelativePath, List<Occurrence> Occurrences);

    public readonly record struct IndexedProject(List<IndexedDocument> Documents);

    public async IAsyncEnumerable<IndexedDocument> Index(IndexOptions options)
    {
        var solution = Workspace.CurrentSolution;
        Logger.LogInformation("Solution {solution}", solution.FilePath);
        foreach (var project in solution.Projects)
        {
            if (project.Language != "C#")
            {
                Logger.LogWarning($"Skipping project {project.FilePath} because it has language {project.Language} and scip-dotnet currently only supports C#.");
                continue;
            }

            foreach (var document in project.Documents)
            {
                yield return await IndexDocument(document, options);
            }
        }
    }

    public async Task<IndexedDocument> IndexDocument(Document document, IndexOptions options)
    {
        if (document.FilePath == null)
        {
            Logger.LogWarning($"Skipping document {document.Name} because it has no FilePath");
            return new IndexedDocument();
        }
        IndexedDocument doc = new IndexedDocument(document.FilePath, new List<Occurrence>());
        var semanticModel = await document.GetSemanticModelAsync();
        if (semanticModel != null)
        {
            var walker = new ScipCSharpSyntaxWalker(document, semanticModel, options);
            var root = await document.GetSyntaxRootAsync();
            walker.Visit(root);
        }
        return doc;
    }
}
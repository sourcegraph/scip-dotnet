using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

/// <summary>
/// Orchestrates Roslyn and MSBuild APIs to SCIP index a given project.
/// </summary>
public class ScipIndexer
{
    public ScipIndexer(ILogger<ScipIndexer> logger)
    {
        Logger = logger;
    }

    private ILogger<ScipIndexer> Logger { get; }

    public void Restore(IndexCommandOptions options)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                WorkingDirectory = options.WorkingDirectory.FullName,
                FileName = "dotnet",
                Arguments = options.ProjectsFile.FullName.EndsWith(".sln")
                    ? $"restore {options.ProjectsFile.FullName}"
                    : "restore"
            }
        };
        process.Start();
    }

    public async IAsyncEnumerable<Scip.Document> IndexDocuments(IHost host, IndexCommandOptions options)
    {
        Restore(options);
        IEnumerable<Project> projects = string.Equals(options.ProjectsFile.Extension, ".csproj")
            ? new[]
            {
                await host.Services.GetRequiredService<MSBuildWorkspace>()
                    .OpenProjectAsync(options.ProjectsFile.FullName)
            }
            : (await host.Services.GetRequiredService<MSBuildWorkspace>()
                .OpenSolutionAsync(options.ProjectsFile.FullName)).Projects;

        foreach (var project in projects)
        {
            if (project.Language != "C#")
            {
                Logger.LogWarning(
                    "Skipping project {ProjectFilePath} because it has language {ProjectLanguage} and scip-dotnet currently only supports C#",
                    project.FilePath, project.Language);
                continue;
            }

            var globals = new Dictionary<ISymbol, ScipSymbol>(SymbolEqualityComparer.Default);

            foreach (var document in project.Documents)
            {
                if (options.Matcher.Match(options.WorkingDirectory.FullName, document.FilePath).HasMatches)
                {
                    yield return await IndexDocument(document, options, globals);
                }
                else
                {
                    options.Logger.LogDebug(
                        "Excluded file path '{FilePath}' because it did not match the provided --include and --exclude arguments",
                        document.FilePath);
                }
            }
        }
    }

    private async Task<Scip.Document> IndexDocument(Document document, IndexCommandOptions options,
        Dictionary<ISymbol, ScipSymbol> globals)
    {
        Scip.Document doc = new Scip.Document
        {
            RelativePath = document.FilePath == null
                ? null
                : Path.GetRelativePath(options.WorkingDirectory.FullName, document.FilePath)
        };
        var semanticModel = await document.GetSemanticModelAsync();
        if (semanticModel == null)
        {
            Logger.LogWarning(
                "Skipping document {DocumentFilePath} because document.GetSemanticModelAsync() returned null",
                document.FilePath);
        }
        else
        {
            var walker = new ScipCSharpSyntaxWalker(doc, semanticModel, options, globals);
            var root = await document.GetSyntaxRootAsync();
            walker.Visit(root);
        }

        return doc;
    }
}
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
    private const int DotnetRestoreTimeout = 3000;

    public ScipIndexer(ILogger<ScipIndexer> logger)
    {
        Logger = logger;
    }

    private ILogger<ScipIndexer> Logger { get; }

    private static void Restore(IndexCommandOptions options, FileInfo project)
    {
        var arguments = project.Extension.Equals(".sln") ? $"restore {project.FullName}" : "restore";
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                WorkingDirectory = options.WorkingDirectory.FullName,
                FileName = "dotnet",
                Arguments = arguments
            }
        };
        options.Logger.LogInformation("$ dotnet {Arguments}", arguments);
        process.Start();
        process.WaitForExit(DotnetRestoreTimeout);
    }

    public async IAsyncEnumerable<Scip.Document> IndexDocuments(IHost host, IndexCommandOptions options)
    {
        var indexedProjects = new HashSet<ProjectId>();
        foreach (var project in options.ProjectsFile)
        {
            await foreach (var document in IndexProject(host, options, project, indexedProjects))
            {
                yield return document;
            }
        }
    }

    private async IAsyncEnumerable<Scip.Document> IndexProject(IHost host, IndexCommandOptions options,
        FileInfo rootProject, HashSet<ProjectId> indexedProjects)
    {
        Restore(options, rootProject);
        IEnumerable<Project> projects = string.Equals(rootProject.Extension, ".csproj")
            ? new[]
            {
                await host.Services.GetRequiredService<MSBuildWorkspace>()
                    .OpenProjectAsync(rootProject.FullName)
            }
            : (await host.Services.GetRequiredService<MSBuildWorkspace>()
                .OpenSolutionAsync(rootProject.FullName)).Projects;

        foreach (var project in projects)
        {
            if (project.Language != "C#")
            {
                Logger.LogWarning(
                    "Skipping project {ProjectFilePath} because it has language {ProjectLanguage} and scip-dotnet currently only supports C#",
                    project.FilePath, project.Language);
                continue;
            }

            if (indexedProjects.Contains(project.Id))
            {
                continue;
            }

            indexedProjects.Add(project.Id);

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
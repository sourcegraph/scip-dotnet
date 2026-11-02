using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

/// <summary>
/// Orchestrates Roslyn and MSBuild APIs to SCIP index a given project.
/// </summary>
public class ScipProjectIndexer
{
    public ScipProjectIndexer(ILogger<ScipProjectIndexer> logger) =>
        Logger = logger;

    private ILogger<ScipProjectIndexer> Logger { get; }

    // Index-wide collections populated while documents are indexed. After indexing
    // finishes, the caller copies ExternalSymbols (minus DefinedSymbols) into
    // Index.external_symbols to provide dependency hover documentation.
    public Dictionary<string, Scip.SymbolInformation> ExternalSymbols { get; } = new();
    public HashSet<string> DefinedSymbols { get; } = new();

    private void Restore(IndexCommandOptions options, FileInfo project)
    {
        var isSolution = project.Extension.Equals(".sln", StringComparison.OrdinalIgnoreCase)
                      || project.Extension.Equals(".slnx", StringComparison.OrdinalIgnoreCase);
        var arguments = isSolution ? $"restore {project.FullName} /p:EnableWindowsTargeting=true" : "restore /p:EnableWindowsTargeting=true";
        if (options.NugetConfigPath != null)
        {
            arguments += $" --configfile \"{options.NugetConfigPath.FullName}\"";
        }
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
        if (!process.WaitForExit(options.DotnetRestoreTimeout))
        {
            Logger.LogWarning("Dotnet restore did not finish in {Time} milliseconds, the results of the indexing might be incorrect.", options.DotnetRestoreTimeout);
        }
    }

    public async IAsyncEnumerable<Scip.Document> IndexDocuments(MSBuildWorkspace workspace, IndexCommandOptions options)
    {
        // Opening a solution replaces the workspace and gives its projects new IDs.
        var indexedProjects = new HashSet<string>(OperatingSystem.IsWindows()
            ? StringComparer.OrdinalIgnoreCase
            : StringComparer.Ordinal);
        foreach (var project in options.ProjectsFile)
        {
            await foreach (var document in IndexProject(workspace, options, project, indexedProjects))
            {
                yield return document;
            }
        }
    }

    private async IAsyncEnumerable<Scip.Document> IndexProject(MSBuildWorkspace workspace,
                                                               IndexCommandOptions options,
                                                               FileInfo rootProject,
                                                               HashSet<string> indexedProjects)
    {
        if (indexedProjects.Contains(rootProject.FullName))
        {
            yield break;
        }

        var isProjectFile = string.Equals(rootProject.Extension, ".csproj", StringComparison.OrdinalIgnoreCase)
                         || string.Equals(rootProject.Extension, ".vbproj", StringComparison.OrdinalIgnoreCase);
        var projects = isProjectFile
            ? workspace.CurrentSolution.Projects
                .Where(project => indexedProjects.Comparer.Equals(project.FilePath, rootProject.FullName)).ToList()
            : new List<Project>();
        if (projects.Count == 0)
        {
            if (!options.SkipDotnetRestore)
            {
                Restore(options, rootProject);
            }

            if (isProjectFile)
            {
                await workspace.OpenProjectAsync(rootProject.FullName);
                // OpenProjectAsync returns only the first target framework. Select from all
                // loaded variants, just as we do when the project is loaded via a solution.
                projects = workspace.CurrentSolution.Projects
                    .Where(project => indexedProjects.Comparer.Equals(project.FilePath, rootProject.FullName)).ToList();
            }
            else
            {
                projects = (await workspace.OpenSolutionAsync(rootProject.FullName)).Projects.ToList();
            }
        }

        options.Logger.LogDebug($"Found {projects.Count()} projects");
        var projectsPerProjFile = projects.GroupBy(x => x.FilePath!, indexedProjects.Comparer);
        var framework = $"net{Environment.Version.Major}.0";
        foreach (var projectGroup in projectsPerProjFile)
        {
            // Index one target framework per project file, preferring the running framework.
            // Fall back to the first variant when the project does not target it.
            var project = projectGroup.FirstOrDefault(x => x.Name.Contains($"({framework})", StringComparison.OrdinalIgnoreCase)) ?? projectGroup.First();
            if (project.Language != "C#" && project.Language != "Visual Basic")
            {
                Logger.LogWarning(
                    "Skipping project {ProjectFilePath} because it has language {ProjectLanguage} and scip-dotnet currently only supports C# and Visual Basic.",
                    project.FilePath, project.Language);
                continue;
            }

            if (!indexedProjects.Add(project.FilePath!))
            {
                continue;
            }

            var globals = new Dictionary<ISymbol, ScipSymbol>(SymbolEqualityComparer.Default);

            options.Logger.LogDebug($"Found {project.Documents.Count()} documents in {projectGroup.Key}");
            foreach (var document in project.Documents)
            {
                if (options.Matcher.Match(options.WorkingDirectory.FullName, document.FilePath).HasMatches)
                {
                    yield return await IndexDocument(document, options, globals, project.Language);
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

    private async Task<Scip.Document> IndexDocument(Document document,
                                                    IndexCommandOptions options,
                                                    Dictionary<ISymbol, ScipSymbol> globals,
                                                    string language)
    {
        Scip.Document doc = new()
        {
            Language = language,
            PositionEncoding = Scip.PositionEncoding.Utf16CodeUnitOffsetFromLineStart,
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
            var symbolFormatter = new ScipDocumentIndexer(doc, options, globals, ExternalSymbols, DefinedSymbols);
            var root = await document.GetSyntaxRootAsync();
            if (language == "C#")
            {
                var walker = new ScipCSharpSyntaxWalker(symbolFormatter, semanticModel);
                walker.Visit(root);
            }
            else if (language == "Visual Basic")
            {
                var walker = new ScipVisualBasicSyntaxWalker(symbolFormatter, semanticModel);
                walker.Visit(root);
            }
        }

        return doc;
    }
}

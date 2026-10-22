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
public class ScipProjectIndexer
{
    public ScipProjectIndexer(ILogger<ScipProjectIndexer> logger) =>
        Logger = logger;

    private ILogger<ScipProjectIndexer> Logger { get; }

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

    private async IAsyncEnumerable<Scip.Document> IndexProject(IHost host,
                                                               IndexCommandOptions options,
                                                               FileInfo rootProject,
                                                               HashSet<ProjectId> indexedProjects)
    {
        if (!options.SkipDotnetRestore)
        {
            Restore(options, rootProject);
        }

        var isProjectFile = string.Equals(rootProject.Extension, ".csproj", StringComparison.OrdinalIgnoreCase)
                         || string.Equals(rootProject.Extension, ".vbproj", StringComparison.OrdinalIgnoreCase);
        var projects = (isProjectFile
            ? new[]
            {
                await host.Services.GetRequiredService<MSBuildWorkspace>()
                    .OpenProjectAsync(rootProject.FullName)
            }
            : (await host.Services.GetRequiredService<MSBuildWorkspace>()
                .OpenSolutionAsync(rootProject.FullName)).Projects).ToList();


        options.Logger.LogDebug($"Found {projects.Count()} projects");
        var projectsPerProjFile = projects.GroupBy(x => x.FilePath);
        var framework = $"net{Environment.Version.Major}.0";
        foreach (var projectGroup in projectsPerProjFile)
        {

            // If the project was found by opening the solution, we need to find the project that matches the framework.
            // if we can' fall back to the first one. Without this, we will process the same document multiple times
            // once for each framework version being targeting and it leads to unpredictable results since the scip file
            // will contain the same document multiple times iwth different symbols.
            var project = projectGroup.FirstOrDefault(x => x.Name.Contains($"({framework})", StringComparison.OrdinalIgnoreCase)) ?? projectGroup.First();
            if (project.Language != "C#" && project.Language != "Visual Basic")
            {
                Logger.LogWarning(
                    "Skipping project {ProjectFilePath} because it has language {ProjectLanguage} and scip-dotnet currently only supports C# and Visual Basic.",
                    project.FilePath, project.Language);
                continue;
            }

            if (indexedProjects.Contains(project.Id))
            {
                continue;
            }

            indexedProjects.Add(project.Id);

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

            foreach (var document in await IndexSourceGeneratedDocuments(project, options, globals))
            {
                yield return document;
            }
        }
    }

    /// <summary>
    /// Indexes the documents that the compiler synthesizes instead of reading from disk.
    /// Razor views (.cshtml) and Blazor components (.razor) enter the compilation this way,
    /// through the Razor source generator, so <code>project.Documents</code> never sees them.
    ///
    /// The generated C# lives under <code>obj/</code> and usually does not exist on disk at all,
    /// so reporting its path would produce an index full of files nobody can open. Instead we
    /// follow the <code>#line</code> directives that the generator emits, group the occurrences
    /// by the original file each one came from and report that file. Occurrences that map to
    /// generated code rather than to a file the developer wrote are dropped.
    /// </summary>
    private async Task<IEnumerable<Scip.Document>> IndexSourceGeneratedDocuments(
        Project project,
        IndexCommandOptions options,
        Dictionary<ISymbol, ScipSymbol> globals)
    {
        var documentsByOriginalPath = new Dictionary<string, Scip.Document>();
        var generatedDocuments = await project.GetSourceGeneratedDocumentsAsync();
        options.Logger.LogDebug($"Found {generatedDocuments.Count()} source generated documents in {project.FilePath}");
        foreach (var document in generatedDocuments)
        {
            var tree = await document.GetSyntaxTreeAsync();
            if (tree == null)
            {
                continue;
            }

            foreach (var originalPath in OriginalFilePaths(tree))
            {
                if (!options.Matcher.Match(options.WorkingDirectory.FullName, originalPath).HasMatches)
                {
                    options.Logger.LogDebug(
                        "Excluded file path '{FilePath}' because it did not match the provided --include and --exclude arguments",
                        originalPath);
                    continue;
                }

                if (!documentsByOriginalPath.TryGetValue(originalPath, out var doc))
                {
                    doc = new Scip.Document
                    {
                        Language = project.Language,
                        RelativePath = Path.GetRelativePath(options.WorkingDirectory.FullName, originalPath)
                    };
                    documentsByOriginalPath.Add(originalPath, doc);
                }

                await WalkDocument(doc, document, options, globals, project.Language, originalPath);
            }
        }

        foreach (var doc in documentsByOriginalPath.Values)
        {
            RemoveDuplicates(doc);
        }

        return documentsByOriginalPath.Values;
    }

    /// <summary>
    /// Removes the occurrences and symbols that we recorded more than once because several
    /// generated files attribute the same region of the same original file to themselves.
    /// </summary>
    private static void RemoveDuplicates(Scip.Document doc)
    {
        var seenOccurrences = new HashSet<string>();
        var occurrences = doc.Occurrences.Where(occurrence => seenOccurrences.Add(OccurrenceKey(occurrence))).ToList();
        doc.Occurrences.Clear();
        doc.Occurrences.AddRange(occurrences);

        var seenSymbols = new HashSet<string>();
        var symbols = doc.Symbols.Where(symbol => seenSymbols.Add(symbol.Symbol)).ToList();
        doc.Symbols.Clear();
        doc.Symbols.AddRange(symbols);
    }

    private static string OccurrenceKey(Scip.Occurrence occurrence) =>
        $"{occurrence.Symbol} {occurrence.SymbolRoles} {string.Join(",", occurrence.Range)}";

    /// <summary>
    /// Returns the files that a generated syntax tree attributes its contents to via
    /// <code>#line</code> directives. A single generated Razor file can point at more than one
    /// original file because directives from <code>_ViewImports.cshtml</code> are copied into
    /// every view that inherits them.
    /// </summary>
    private static IEnumerable<string> OriginalFilePaths(SyntaxTree tree) =>
        tree.GetLineMappings()
            .Where(mapping => !mapping.IsHidden && mapping.MappedSpan.HasMappedPath)
            .Select(mapping => mapping.MappedSpan.Path)
            .Where(path => !string.IsNullOrEmpty(path) && File.Exists(path))
            .Distinct();

    private async Task<Scip.Document> IndexDocument(Document document,
                                                    IndexCommandOptions options,
                                                    Dictionary<ISymbol, ScipSymbol> globals,
                                                    string language)
    {
        Scip.Document doc = new()
        {
            Language = language,
            RelativePath = document.FilePath == null
                ? null
                : Path.GetRelativePath(options.WorkingDirectory.FullName, document.FilePath)
        };
        await WalkDocument(doc, document, options, globals, language, originalFilePath: null);
        return doc;
    }

    /// <summary>
    /// Walks <paramref name="document"/> and adds what it finds to <paramref name="doc"/>. When
    /// <paramref name="originalFilePath"/> is non-null only the occurrences that <code>#line</code>
    /// directives attribute to that file are recorded.
    /// </summary>
    private async Task WalkDocument(Scip.Document doc,
                                    Document document,
                                    IndexCommandOptions options,
                                    Dictionary<ISymbol, ScipSymbol> globals,
                                    string language,
                                    string? originalFilePath)
    {
        var semanticModel = await document.GetSemanticModelAsync();
        if (semanticModel == null)
        {
            Logger.LogWarning(
                "Skipping document {DocumentFilePath} because document.GetSemanticModelAsync() returned null",
                document.FilePath);
            return;
        }

        var symbolFormatter = new ScipDocumentIndexer(doc, options, globals, originalFilePath);
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
}
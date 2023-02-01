using System.Diagnostics;
using Google.Protobuf;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scip;

namespace ScipDotnet;

public static class IndexCommandHandler
{
    public static async Task<int> Process(IHost host, FileInfo? projects, string output, FileInfo workingDirectory,
        List<string> include, List<string> exclude, bool allowGlobalSymbolDefinitions)
    {
        var logger = host.Services.GetRequiredService<ILogger<IndexCommandOptions>>();
        var matcher = new Matcher();
        matcher.AddIncludePatterns(include.Count == 0 ? new[] { "**" } : include);
        matcher.AddExcludePatterns(exclude);

        var projectsFile = projects?.FullName ?? FindSolutionOrProjectFile(workingDirectory, logger);
        if (projectsFile == null)
        {
            return 1;
        }

        var options = new IndexCommandOptions(workingDirectory, OutputFile(workingDirectory, output),
            new FileInfo(projectsFile), logger, matcher,
            allowGlobalSymbolDefinitions);
        await ScipIndex(host, options);
        return 0;
    }

    private static FileInfo OutputFile(FileInfo workingDirectory, string output)
    {
        if (Path.IsPathRooted(output))
        {
            return new FileInfo(output);
        }

        return new FileInfo(Path.Join(workingDirectory.FullName, output));
    }

    private static async Task ScipIndex(IHost host, IndexCommandOptions options)
    {
        var stopwatch = Stopwatch.StartNew();
        options.Logger.LogInformation("Solution file {SolutionFileFullName}", options.ProjectsFile.FullName);
        var indexer = host.Services.GetRequiredService<ScipIndexer>();
        var index = new Scip.Index
        {
            Metadata = new Metadata
            {
                ProjectRoot = new Uri(new Uri("file://"), options.WorkingDirectory.FullName).ToString(),
                ToolInfo = new ToolInfo
                {
                    Name = "scip-dotnet",
                    Version = "0.1.0-SNAPSHOT"
                },
                TextDocumentEncoding = TextEncoding.Utf8,
            }
        };
        await foreach (var document in indexer.IndexDocuments(host, options))
        {
            index.Documents.Add(document);
        }

        await File.WriteAllBytesAsync(options.Output.FullName, index.ToByteArray());
        options.Logger.LogInformation("done: {OptionsOutput} {TimeElapsed}", options.Output,
            stopwatch.Elapsed.ToFriendlyString());
    }

    private static string FixThisProblem(string examplePath)
    {
        return "To fix this problem, pass the path of a solution (.sln) or project (.csproj) file to the `scip-dotnet index` command. " +
        $"For example, run: scip-dotnet index {examplePath}";
    }
    
    private static string? FindSolutionOrProjectFile(FileInfo workingDirectory, ILogger<IndexCommandOptions> logger)
    {
        var paths = Directory.GetFiles(workingDirectory.FullName).Where(file =>
            string.Equals(Path.GetExtension(file), ".sln", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(Path.GetExtension(file), ".csproj", StringComparison.OrdinalIgnoreCase)
        ).ToList();

        switch (paths.Count)
        {
            case 0:
                logger.LogError(
                    "No solution (.sln) or .csproj file detected in the working directory '{WorkingDirectory}'. {FixThis}",
                    workingDirectory.FullName, FixThisProblem("SOLUTION_FILE"));
                return null;
            case 1:
                return paths.First();
        }

        var relativePaths = paths.Select(path => Path.GetRelativePath(workingDirectory.FullName, path)).ToList();
        logger.LogError(
            "Ambiguous solution files: {Join}. {FixThis}",
            String.Join(", ", relativePaths),
            FixThisProblem(relativePaths.First()));
        return null;

    }
}
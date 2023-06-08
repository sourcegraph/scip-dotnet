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
    public static async Task<int> Process(IHost host, List<FileInfo> projects, string output, FileInfo workingDirectory,
        List<string> include, List<string> exclude, bool allowGlobalSymbolDefinitions, int dotnetRestoreTimeout)
    {
        var logger = host.Services.GetRequiredService<ILogger<IndexCommandOptions>>();
        var matcher = new Matcher();
        matcher.AddIncludePatterns(include.Count == 0 ? new[] { "**" } : include);
        matcher.AddExcludePatterns(exclude);

        var projectFiles = projects.Count > 0
            ? projects
            : FindSolutionOrProjectFile(workingDirectory, logger);
        if (!projectFiles.Any())
        {
            return 1;
        }

        var options = new IndexCommandOptions(
            workingDirectory,
            OutputFile(workingDirectory, output),
            projectFiles,
            logger,
            matcher,
            allowGlobalSymbolDefinitions,
            dotnetRestoreTimeout
        );
        await ScipIndex(host, options);
        return 0;
    }

    private static FileInfo OutputFile(FileInfo workingDirectory, string output) =>
        Path.IsPathRooted(output) ? new FileInfo(output) : new FileInfo(Path.Join(workingDirectory.FullName, output));

    private static async Task ScipIndex(IHost host, IndexCommandOptions options)
    {
        var stopwatch = Stopwatch.StartNew();
        var indexer = host.Services.GetRequiredService<ScipProjectIndexer>();
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

    private static string FixThisProblem(string examplePath) =>
        "To fix this problem, pass the path of a solution (.sln) or project (.csproj/.vbrpoj) file to the `scip-dotnet index` command. " +
        $"For example, run: scip-dotnet index {examplePath}";

    private static List<FileInfo> FindSolutionOrProjectFile(FileInfo workingDirectory, ILogger logger)
    {
        var paths = Directory.GetFiles(workingDirectory.FullName).Where(file =>
            string.Equals(Path.GetExtension(file), ".sln", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(Path.GetExtension(file), ".csproj", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(Path.GetExtension(file), ".vbproj", StringComparison.OrdinalIgnoreCase)
        ).ToList();

        if (paths.Count != 0)
        {
            return paths.Select(path => new FileInfo(path)).ToList();
        }

        logger.LogError(
            "No solution (.sln) or .csproj/.vbproj file detected in the working directory '{WorkingDirectory}'. {FixThis}",
            workingDirectory.FullName, FixThisProblem("SOLUTION_FILE"));
        return new List<FileInfo>();
    }
}
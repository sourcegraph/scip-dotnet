using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

public class IndexHandler
{
    public static async Task Process(IHost host, FileInfo workingDirectory, FileInfo? solutionFile, FileInfo outputFile)
    {
        var logger = host.Services.GetRequiredService<ILogger<IndexOptions>>();
        var options = new IndexOptions(workingDirectory, outputFile,
            new FileInfo(solutionFile?.FullName ?? FindSolutionFile(workingDirectory)), logger);
        await ScipIndex(host, options);
    }

    private static async Task ScipIndex(IHost host, IndexOptions options)
    {
        var stopwatch = Stopwatch.StartNew();
        await host.Services.GetRequiredService<MSBuildWorkspace>().OpenSolutionAsync(options.solutionFile.FullName);
        var indexer = host.Services.GetRequiredService<ScipIndexer>();
        await foreach (var indexedDocument in indexer.Index(options)) options.logger.LogInformation($"Document {indexedDocument}");
        options.logger.LogInformation($"done: {options.output} ({stopwatch.Elapsed})");
    }

    private static string FindSolutionFile(FileInfo workingDirectory)
    {
        var files = Directory.GetFiles(workingDirectory.FullName).Where(file =>
            string.Equals(Path.GetExtension(file), ".sln", StringComparison.OrdinalIgnoreCase)).ToList();
        if (files.Count != 1)
        {
            throw new ArgumentException(
                $"ambiguous solution files {files}. Use the --solution-file argument to specify which solution file to index.");
        }

        return files.First();
    }
}
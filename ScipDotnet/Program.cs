using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var outputOption = new Option<FileInfo>("--output", () => new FileInfo("index.scip"),
            "Where to write the output SCIP index file");
        var workingDirectoryOption = new Option<FileInfo>("--working-directory", () => new FileInfo(Directory.GetCurrentDirectory()),
            "The working directory");
        var indexCommand = new Command("index", "Index a solution file")
        {
            new Argument<FileInfo>("solutionFile", "The solution ") { Arity = ArgumentArity.ZeroOrOne },
            outputOption,
            workingDirectoryOption
        };
        var rootCommand =
            new RootCommand("SCIP indexer for C# and Visual Studio Languages, built with the Roslyn .NET compiler")
            {
                indexCommand,
            };
        var builder = new CommandLineBuilder(rootCommand);
        return await builder.UseHost(_ => Host.CreateDefaultBuilder(), host =>
            {
                host.ConfigureAppConfiguration(b => b.AddInMemoryCollection());
                host.ConfigureLogging(b => b.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.None));
                host.ConfigureServices((_, collection) =>
                    collection
                        .AddSingleton(_ => CreateWorkspace())
                        .AddTransient<ScipIndexer>()
                        .AddTransient(services => (Workspace)services.GetRequiredService<MSBuildWorkspace>())
                    );
            })
            .UseDefaults()
            .Build()
            .InvokeAsync(args);
    }

    private static MSBuildWorkspace CreateWorkspace()
    {
        MSBuildLocator.RegisterDefaults();
        return MSBuildWorkspace.Create();
    }
}
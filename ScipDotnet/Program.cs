using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.NamingConventionBinder;
using System.CommandLine.Parsing;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

public static class Program
{
    private const int DotnetRestoreTimeout = 300000;

    public static async Task<int> Main(string[] args)
    {
        var indexCommand = new Command("index", "Index a solution file")
        {
            new Argument<FileInfo>("projects", "Path to the .sln (solution) or .csproj/.vbproj file")
                { Arity = ArgumentArity.ZeroOrMore },
            new Option<string>("--output", () => "index.scip",
                "Path to the output SCIP index file"),
            new Option<FileInfo>("--working-directory",
                () => new FileInfo(Directory.GetCurrentDirectory()),
                "The working directory"),
            new Option<List<string>>("--include", () => new List<string>(),
                "Only index files that match the given file glob pattern")
            {
                Arity = ArgumentArity.ZeroOrMore,
            },
            new Option<List<string>>("--exclude", () => new List<string>(),
                "Only index files that match the given file glob pattern")
            {
                Arity = ArgumentArity.ZeroOrMore
            },
            new Option<bool>("--allow-global-symbol-definitions", () => false,
                "If enabled, allow public symbol definitions to be accessible from other SCIP indexes. " +
                "If disabled, then public symbols will only be visible within the index."),
            new Option<int>("--dotnet-restore-timeout", () => DotnetRestoreTimeout,
                @"The timeout (in ms) for the ""dotnet restore"" command"),
            new Option<bool>("--dotnet-skip-restore", () => false,
                @"Skip executing ""dotnet restore"" and assume it has been run externally."),
            new Option<FileInfo?>("--dotnet-nuget-config-file", () => null,
                @"Provide a custom path for ""dotnet restore"" to find the NuGet.config file."),
        };
        indexCommand.Handler = CommandHandler.Create(IndexCommandHandler.Process);
        var rootCommand =
            new RootCommand(
                "SCIP indexer for the C# and Visual basic programming languages. Built with the Roslyn .NET compiler. Supports MSBuild.")
            {
                indexCommand,
            };
        var builder = new CommandLineBuilder(rootCommand);
        return await builder.UseHost(_ => Host.CreateDefaultBuilder(), host =>
            {
                host.ConfigureAppConfiguration(b => b.AddInMemoryCollection());
                host.ConfigureLogging(b => b.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "HH:mm:ss ";
                }).AddFilter("Microsoft.Hosting.Lifetime", LogLevel.None));
                host.ConfigureServices((_, collection) =>
                    collection
                        .AddSingleton(_ => CreateWorkspace())
                        .AddTransient<ScipProjectIndexer>()
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
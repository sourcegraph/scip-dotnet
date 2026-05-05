using System.CommandLine;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

public static class Program
{
    private const int DotnetRestoreTimeout = 300000;

    public static async Task<int> Main(string[] args)
    {
        var projectsArgument = new Argument<List<FileInfo>>("projects")
        {
            Arity = ArgumentArity.ZeroOrMore,
            Description = "Path to the .sln (solution) or .csproj/.vbproj file"
        };
        var outputOption = new Option<string>("--output")
        {
            Description = "Path to the output SCIP index file",
            DefaultValueFactory = _ => "index.scip"
        };
        var workingDirectoryOption = new Option<FileInfo>("--working-directory")
        {
            Description = "The working directory",
            DefaultValueFactory = _ => new FileInfo(Directory.GetCurrentDirectory())
        };
        var includeOption = new Option<List<string>>("--include")
        {
            Description = "Only index files that match the given file glob pattern",
            Arity = ArgumentArity.ZeroOrMore,
            DefaultValueFactory = _ => new List<string>()
        };
        var excludeOption = new Option<List<string>>("--exclude")
        {
            Description = "Only index files that match the given file glob pattern",
            Arity = ArgumentArity.ZeroOrMore,
            DefaultValueFactory = _ => new List<string>()
        };
        var allowGlobalSymbolDefinitionsOption = new Option<bool>("--allow-global-symbol-definitions")
        {
            Description = "If enabled, allow public symbol definitions to be accessible from other SCIP indexes. " +
                          "If disabled, then public symbols will only be visible within the index.",
            DefaultValueFactory = _ => false
        };
        var dotnetRestoreTimeoutOption = new Option<int>("--dotnet-restore-timeout")
        {
            Description = @"The timeout (in ms) for the ""dotnet restore"" command",
            DefaultValueFactory = _ => DotnetRestoreTimeout
        };
        var skipDotnetRestoreOption = new Option<bool>("--skip-dotnet-restore")
        {
            Description = @"Skip executing ""dotnet restore"" and assume it has been run externally.",
            DefaultValueFactory = _ => false
        };
        var nugetConfigPathOption = new Option<FileInfo?>("--nuget-config-path")
        {
            Description = @"Provide a case sensitive custom path for ""dotnet restore"" to find the NuGet.config file. " +
                          @"If not provided, ""dotnet restore"" will search for the NuGet.config file recursively up the folder hierarchy " +
                          @"and in the default user and system config locations."
        };

        var indexCommand = new Command("index", "Index a solution file")
        {
            projectsArgument,
            outputOption,
            workingDirectoryOption,
            includeOption,
            excludeOption,
            allowGlobalSymbolDefinitionsOption,
            dotnetRestoreTimeoutOption,
            skipDotnetRestoreOption,
            nugetConfigPathOption
        };

        indexCommand.SetAction(async (parseResult, cancellationToken) =>
        {
            var projects = parseResult.GetValue(projectsArgument) ?? new List<FileInfo>();
            var output = parseResult.GetValue(outputOption) ?? "index.scip";
            var workingDirectory = parseResult.GetValue(workingDirectoryOption) ?? new FileInfo(Directory.GetCurrentDirectory());
            var include = parseResult.GetValue(includeOption) ?? new List<string>();
            var exclude = parseResult.GetValue(excludeOption) ?? new List<string>();
            var allowGlobalSymbolDefinitions = parseResult.GetValue(allowGlobalSymbolDefinitionsOption);
            var dotnetRestoreTimeout = parseResult.GetValue(dotnetRestoreTimeoutOption);
            var skipDotnetRestore = parseResult.GetValue(skipDotnetRestoreOption);
            var nugetConfigPath = parseResult.GetValue(nugetConfigPathOption);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "HH:mm:ss ";
                });
                builder.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.None);
            });

            MSBuildLocator.RegisterDefaults();
            var workspace = MSBuildWorkspace.Create();

            return await IndexCommandHandler.Process(
                loggerFactory,
                workspace,
                projects,
                output,
                workingDirectory,
                include,
                exclude,
                allowGlobalSymbolDefinitions,
                dotnetRestoreTimeout,
                skipDotnetRestore,
                nugetConfigPath);
        });

        var rootCommand = new RootCommand(
            "SCIP indexer for the C# and Visual basic programming languages. Built with the Roslyn .NET compiler. Supports MSBuild.")
        {
            indexCommand
        };

        return await rootCommand.Parse(args).InvokeAsync();
    }
}

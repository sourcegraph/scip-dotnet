using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

public record IndexCommandOptions(
    FileInfo WorkingDirectory,
    FileInfo Output,
    List<FileInfo> ProjectsFile,
    ILogger<IndexCommandOptions> Logger,
    Matcher Matcher,
    bool AllowGlobalSymbolDefinitions,
    int DotnetRestoreTimeout,
    bool DotnetSkipRestore,
    FileInfo? DotnetNugetConfigFile
);
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

public record IndexOptions(FileInfo workingDirectory, FileInfo? output, FileInfo solutionFile, ILogger<IndexOptions> logger);
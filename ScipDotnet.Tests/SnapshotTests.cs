using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using Scip;
using Index = Scip.Index;

namespace ScipDotnet.Tests;

[TestFixture]
public class SnapshotTests
{
    [Test, TestCaseSource(nameof(ListSnapshotInputDirectories))]
    public void Snapshot(string inputDirectory)
    {
        var indexFile = IndexDirectory(inputDirectory);
        var indexBytes = File.ReadAllBytes(indexFile);
        var index = Index.Parser.ParseFrom(indexBytes);
        var snapshots = index.Documents.ToDictionary(document => document.RelativePath,
            document => FormatDocument(index, document));
        var outputDirectory =
            Path.GetFullPath(Path.Join(inputDirectory, "../../", "output", Path.GetFileName(inputDirectory)));
        var isUpdateSnapshots = Environment.GetEnvironmentVariable("SCIP_UPDATE_SNAPSHOTS") != null;
        if (isUpdateSnapshots)
        {
            if (Directory.Exists(outputDirectory))
            {
                Directory.Delete(outputDirectory, true);
            }

            foreach (var (relativePath, snapshot) in snapshots)
            {
                var documentPath = Path.Join(outputDirectory, relativePath);
                var directory = Path.GetDirectoryName(documentPath);
                if (directory == null) continue;
                Directory.CreateDirectory(directory);
                File.WriteAllText(documentPath, snapshot);
            }
        }
        else
        {
            Assert.Multiple(() =>
            {
                var relativeInputPaths = new HashSet<string>(GitLsFiles(inputDirectory));
                var absoluteOutputPaths = new List<string>();
                RecursivelyListFiles(outputDirectory, absoluteOutputPaths);
                foreach (var absolutePath in absoluteOutputPaths)
                {
                    if (!absolutePath.EndsWith(".cs"))
                    {
                        continue;
                    }

                    var relativePath = Path.GetRelativePath(outputDirectory, absolutePath);
                    var obtained = snapshots[relativePath];
                    var expected = File.ReadAllText(absolutePath);
                    var diff = DiffStrings(obtained, expected);
                    if (diff.Length > 0)
                    {
                        // Console.WriteLine(diff);
                        Assert.Fail(
                            $"{absolutePath}\n(+ expected, - obtained). To update the expected output to match the obtained behavior, run: " +
                            "SCIP_UPDATE_SNAPSHOTS=true dotnet test\n\n" + diff);
                    }
                }

                var absoluteOutputPathsSet = new HashSet<string>(absoluteOutputPaths);
                foreach (var (relativePath, _) in snapshots)
                {
                    var absolutePath = Path.Join(outputDirectory, relativePath);
                    if (relativeInputPaths.Contains(relativePath) && !absoluteOutputPathsSet.Contains(absolutePath))
                    {
                        Assert.Fail(
                            $"relative path '{relativePath}' missing an output file. To fix this problem, run the following command: SCIP_UPDATE_SNAPSHOTS=true dotnet test");
                    }
                }
            });
        }
    }

    private static void RecursivelyListFiles(string path, List<string> result)
    {
        if (!Directory.Exists(path)) return;
        result.AddRange(Directory.GetFiles(path));
        foreach (var directory in Directory.GetDirectories(path))
        {
            RecursivelyListFiles(directory, result);
        }
    }

    private static string DiffStrings(string obtained, string expected)
    {
        var diff = InlineDiffBuilder.Diff(expected, obtained);
        var sb = new StringBuilder();
        for (var i = 0; i < diff.Lines.Count; i++)
        {
            var line = diff.Lines[i];
            if (line.Type == ChangeType.Unchanged)
            {
                continue;
            }

            if (i > 0 && diff.Lines[i - 1].Type == ChangeType.Unchanged)
            {
                sb.Append("  ").AppendLine(diff.Lines[i - 1].Text);
            }

            switch (line.Type)
            {
                case ChangeType.Inserted:
                    sb.Append("+ ");
                    break;
                case ChangeType.Deleted:
                    sb.Append("- ");
                    break;
            }

            sb.AppendLine(line.Text);
        }

        return sb.ToString();
    }

    private static string[] ListSnapshotInputDirectories()
    {
        var inputs = Path.Join(RootDirectory(), "snapshots", "input");
        return Directory.GetDirectories(inputs);
    }

    private static string IndexDirectory(string directory)
    {
        var include = Environment.GetEnvironmentVariable("SCIP_INCLUDE");
        var includeOption = include != null ? $" --include {include}" : "";
        var arguments = $"run --project ScipDotnet -- index --working-directory {directory}{includeOption}";
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "dotnet",
                Arguments = arguments,
                WorkingDirectory = RootDirectory(),
            }
        };
        process.Start();
        process.WaitForExit();
        if (process.ExitCode != 0)
        {
            Assert.Fail(
                $"non-zero exit code {process.ExitCode} indexing {directory}\ndotnet {arguments}");
        }

        return Path.Join(directory, "index.scip");
    }

    private static string[] GitLsFiles(string directory)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "git",
                Arguments = "ls-files",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                WorkingDirectory = directory
            }
        };
        process.Start();
        return process.StandardOutput.ReadToEnd().Trim().Split("\n");
    }

    private static string RootDirectory()
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                // The working directory of `dotnet test` is not the root directory of the project
                // so we infer it by invoking `git rev-parse --show-toplevel`. It would be cleaner
                // to get the root directory from MSBuild but I wasn't able to figure out how to do it
                // after searching for ~20 minutes. This works for now and unblocks writing tests.
                FileName = "git",
                Arguments = "rev-parse --show-toplevel",
                UseShellExecute = false,
                RedirectStandardOutput = true
            }
        };
        process.Start();
        return process.StandardOutput.ReadToEnd().Trim();
    }


    private Dictionary<String, SymbolInformation> SymbolTable(Document document)
    {
        var result = new Dictionary<String, SymbolInformation>();
        foreach (var info in document.Symbols)
        {
            // Intentionally crash the test if we emit conflicting SymbolInformation
            if (!result.TryAdd(info.Symbol, info))
            {
                Assert.Fail("duplicate SymbolInformation '{0}'", info.Symbol);
            }
        }

        return result;
    }

    private string FormatDocument(Index index, Document document)
    {
        var sb = new StringBuilder();
        var inputPath = new Uri(index.Metadata.ProjectRoot + "/" + document.RelativePath).LocalPath;
        var occurrences = document.Occurrences.ToList();
        occurrences.Sort(CompareOccurrences);
        var symtab = SymbolTable(document);
        var occurrenceIndex = 0;
        var lines = File.ReadAllLines(inputPath);
        for (var lineNumber = 0; lineNumber < lines.Length; lineNumber++)
        {
            var line = lines[lineNumber].Replace("\t", " ");
            sb.Append("  ").AppendLine(line);
            while (occurrenceIndex < occurrences.Count)
            {
                var occurrence = occurrences[occurrenceIndex];
                var range = Range.FromOccurrence(occurrence);
                if (range.Start.Line != range.End.Line)
                    continue; // TODO: support in the future
                if (range.Start.Line != lineNumber)
                    break;
                var isDefinition = (occurrence.SymbolRoles & (int)SymbolRole.Definition) != 0;
                var role = isDefinition ? "definition" : "reference";
                var length = range.End.Character - range.Start.Character;
                var indent = new String(' ', range.Start.Character);
                sb.Append("//")
                    .Append(indent)
                    .Append(new String('^', length))
                    .Append(' ')
                    .Append(role)
                    .Append(' ')
                    .AppendLine(occurrence.Symbol);

                if (isDefinition)
                {
                    var info = symtab.GetValueOrDefault(occurrence.Symbol, new SymbolInformation());
                    var prefix = "//" + indent + new String(' ', length + 1);
                    foreach (var documentation in info.Documentation)
                    {
                        sb.Append(prefix).Append("documentation ").AppendLine(documentation.Replace("\n", "\\n"));
                    }

                    foreach (var relationship in info.Relationships)
                    {
                        sb.Append(prefix).Append("relationship ");
                        if (relationship.IsDefinition) sb.Append("definition ");
                        if (relationship.IsImplementation) sb.Append("implementation ");
                        if (relationship.IsReference) sb.Append("reference ");
                        if (relationship.IsTypeDefinition) sb.Append("type_definition ");
                        sb.AppendLine(relationship.Symbol);
                    }
                }

                occurrenceIndex++;
            }
        }

        return sb.ToString();
    }

    private static int CompareOccurrences(Occurrence a, Occurrence b)
    {
        return Range.FromOccurrence(a).CompareTo(Range.FromOccurrence(b));
    }
}
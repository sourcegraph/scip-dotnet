using System.Diagnostics;
using Scip;
using Index = Scip.Index;

namespace ScipDotnet.Tests;

/// <summary>
/// Regression test for dangling cross-package occurrences.
///
/// SCIP requires that every occurrence referencing a symbol that is defined in an
/// external package have a matching <see cref="SymbolInformation"/> in
/// <c>Index.external_symbols</c> (the same invariant <c>scip lint</c> enforces).
///
/// Before the external-symbols fix, scip-dotnet emitted reference occurrences for
/// NuGet/BCL symbols (e.g. <c>System.Runtime</c>) but never populated
/// <c>external_symbols</c>, so ~60% of occurrences in a real-world index dangled.
/// </summary>
[TestFixture]
public class ExternalSymbolsTests
{
    [Test]
    public void EveryGenuineExternalOccurrenceHasSymbolInformation()
    {
        var inputDirectory = Path.Join(RootDirectory(), "snapshots", "input", "syntax");
        var indexFile = IndexDirectory(inputDirectory);
        var index = Index.Parser.ParseFrom(File.ReadAllBytes(indexFile));

        var declared = DeclaredSymbols(index);

        var dangling = new SortedSet<string>();
        foreach (var document in index.Documents)
        {
            foreach (var occurrence in document.Occurrences)
            {
                if (IsGenuineExternal(occurrence.Symbol) && !declared.Contains(occurrence.Symbol))
                {
                    dangling.Add(occurrence.Symbol);
                }
            }
        }

        Assert.That(dangling, Is.Empty,
            "Occurrences reference external-package symbols that have no SymbolInformation "
            + "in external_symbols or any document:\n  " + string.Join("\n  ", dangling));
    }

    // Every external-package symbol referenced as a relationship target (e.g. the
    // implicitly implemented IEquatable<T> on a record, or a transitively inherited
    // interface that never appears textually in the source) must also be declared in
    // external_symbols. Otherwise scip lint reports:
    //   "has a relationship to <symbol>, but couldn't find #2 in external symbols ...".
    [Test]
    public void EveryExternalRelationshipTargetHasSymbolInformation()
    {
        var inputDirectory = Path.Join(RootDirectory(), "snapshots", "input", "syntax");
        var indexFile = IndexDirectory(inputDirectory);
        var index = Index.Parser.ParseFrom(File.ReadAllBytes(indexFile));

        var declared = DeclaredSymbols(index);

        var dangling = new SortedSet<string>();
        foreach (var document in index.Documents)
        {
            foreach (var info in document.Symbols)
            {
                foreach (var relationship in info.Relationships)
                {
                    if (IsGenuineExternal(relationship.Symbol) && !declared.Contains(relationship.Symbol))
                    {
                        dangling.Add(relationship.Symbol);
                    }
                }
            }
        }

        Assert.That(dangling, Is.Empty,
            "SymbolInformation relationships target external-package symbols that have no "
            + "SymbolInformation in external_symbols or any document:\n  " + string.Join("\n  ", dangling));
    }

    // The set of symbols for which a SymbolInformation exists, either as an
    // in-document definition or as an external symbol.
    private static HashSet<string> DeclaredSymbols(Index index)
    {
        var declared = new HashSet<string>();
        foreach (var document in index.Documents)
        {
            foreach (var info in document.Symbols)
            {
                declared.Add(info.Symbol);
            }
        }
        foreach (var info in index.ExternalSymbols)
        {
            declared.Add(info.Symbol);
        }

        return declared;
    }

    // A "genuine external" symbol is a global symbol that resolves to a real NuGet/BCL
    // package. Index-local symbols use the "scip-dotnet nuget . . " package placeholder
    // and are intentionally excluded here (their dangling references are a separate issue).
    private static bool IsGenuineExternal(string symbol) =>
        symbol.StartsWith("scip-dotnet nuget ")
        && !symbol.StartsWith("scip-dotnet nuget . . ");

    private static string IndexDirectory(string directory)
    {
        var framework = $"net{Environment.Version.Major}.0";
        var arguments = $"run --project ScipDotnet --framework {framework} -- index --working-directory {directory}";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = arguments,
                WorkingDirectory = RootDirectory()
            }
        };
        process.Start();
        process.WaitForExit();
        if (process.ExitCode != 0)
        {
            Assert.Fail($"non-zero exit code {process.ExitCode} indexing {directory}\ndotnet {arguments}");
        }

        return Path.Join(directory, "index.scip");
    }

    private static string RootDirectory()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "rev-parse --show-toplevel",
                UseShellExecute = false,
                RedirectStandardOutput = true
            }
        };
        process.Start();
        return process.StandardOutput.ReadToEnd().Trim();
    }
}

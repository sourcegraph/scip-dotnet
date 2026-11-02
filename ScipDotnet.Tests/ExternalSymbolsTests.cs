using System.Diagnostics;
using Scip;
using Index = Scip.Index;

namespace ScipDotnet.Tests;

/// <summary>
/// Checks the dependency hover metadata emitted in Index.external_symbols.
/// SCIP permits this metadata to be omitted when dependencies are indexed separately;
/// we include it so their documentation is available without a separate index.
/// </summary>
[TestFixture]
public class ExternalSymbolsTests
{
    [TestCase(false)]
    [TestCase(true)]
    public void GenericHoverDescribesDeclarationRegardlessOfReferenceOrder(bool stringsFirst)
    {
        var directory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(directory);
        try
        {
            File.WriteAllText(Path.Join(directory, "Example.csproj"), $"""
                <Project Sdk="Microsoft.NET.Sdk">
                  <PropertyGroup>
                    <TargetFramework>net{Environment.Version.Major}.0</TargetFramework>
                  </PropertyGroup>
                </Project>
                """);
            var intCalls = """
                ints.Add(1);
                _ = ints.First();
                _ = Enumerable.First(ints);
                _ = ints.First(x => x > 0);
                _ = Enumerable.First(ints, x => x > 0);
                """;
            var stringCalls = """
                strings.Add("x");
                _ = strings.First(x => x.Length > 0);
                _ = Enumerable.First(strings, x => x.Length > 0);
                _ = strings.First();
                _ = Enumerable.First(strings);
                """;
            File.WriteAllText(Path.Join(directory, "Example.cs"), $$"""
                using System.Collections.Generic;
                using System.Linq;

                public class Example
                {
                    public void Run(List<int> ints, List<string> strings)
                    {
                        {{(stringsFirst ? stringCalls : intCalls)}}
                        {{(stringsFirst ? intCalls : stringCalls)}}
                        Helper.Later();
                    }
                }
                {{(stringsFirst ? "public record Text(string Value);" : "public record Number(int Value);")}}
                {{(stringsFirst ? "public record Number(int Value);" : "public record Text(string Value);")}}
                public static class Helper
                {
                    public static void Later() { }
                }
                """);

            var index = Index.Parser.ParseFrom(File.ReadAllBytes(IndexDirectory(directory, allowGlobalDefinitions: true)));
            var document = index.Documents.Single(doc => doc.RelativePath == "Example.cs");
            var addReferences = document.Occurrences.Where(occurrence => occurrence.Symbol.Contains("/List#Add(")).ToList();
            Assert.That(addReferences, Has.Count.EqualTo(2), "Both generic constructions must have occurrences.");
            Assert.That(addReferences.Select(occurrence => occurrence.Symbol).Distinct().Count(), Is.EqualTo(1));
            var add = index.ExternalSymbols.Single(info => info.Symbol == addReferences[0].Symbol);
            Assert.That(add.Documentation[0], Does.Contain("List<T>.Add(T item)"));

            var sourceLines = File.ReadAllLines(Path.Join(directory, "Example.cs"));
            var firstReferences = document.Occurrences.Where(occurrence => occurrence.Symbol.Contains("/Enumerable#First(")).ToList();
            Assert.That(firstReferences, Has.Count.EqualTo(8), "Both overloads, constructions and call styles must have occurrences.");
            Assert.That(firstReferences.Select(occurrence => occurrence.Symbol).Distinct().Count(), Is.EqualTo(2),
                "Distinct overloads must not share a SCIP identity.");
            foreach (var hasPredicate in new[] { false, true })
            {
                var references = firstReferences.Where(occurrence => sourceLines[occurrence.Range[0]].Contains("=>") == hasPredicate).ToList();
                Assert.That(references, Has.Count.EqualTo(4));
                Assert.That(references.Select(occurrence => occurrence.Symbol).Distinct().Count(), Is.EqualTo(1));
                var external = index.ExternalSymbols.Single(info => info.Symbol == references[0].Symbol);
                Assert.That(external.Documentation[0], Does.Contain("TSource"));
                Assert.That(external.Documentation[0], Does.Not.Contain("int"));
                Assert.That(external.Documentation[0], Does.Not.Contain("string"));
                Assert.That(external.Documentation[0].Contains("predicate"), Is.EqualTo(hasPredicate));
            }

            var equatableTargets = document.Symbols.SelectMany(info => info.Relationships)
                .Where(relationship => relationship.Symbol.EndsWith("/IEquatable#")).ToList();
            Assert.That(equatableTargets, Has.Count.EqualTo(2));
            Assert.That(equatableTargets.Select(relationship => relationship.Symbol).Distinct().Count(), Is.EqualTo(1));
            var equatable = index.ExternalSymbols.Single(info => info.Symbol == equatableTargets[0].Symbol);
            Assert.That(equatable.Documentation[0], Does.Contain("IEquatable<T>"));

            var later = document.Occurrences.Where(occurrence => occurrence.Symbol.EndsWith("/Helper#Later().")).ToList();
            Assert.That(later, Has.Count.EqualTo(2), "The source definition is visited after its reference.");
            Assert.That(index.ExternalSymbols.Select(info => info.Symbol), Does.Not.Contain(later[0].Symbol));
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

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

    // Include metadata for relationship targets even when they have no source occurrence,
    // such as the implicitly implemented IEquatable<T> on a record.
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

    private static string IndexDirectory(string directory, bool allowGlobalDefinitions = false)
    {
        var framework = $"net{Environment.Version.Major}.0";
        var arguments = $"run --project ScipDotnet --framework {framework} -- index --working-directory \"{directory}\""
            + (allowGlobalDefinitions ? " --allow-global-symbol-definitions" : "");
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

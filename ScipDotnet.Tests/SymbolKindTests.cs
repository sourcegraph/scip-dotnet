using Scip;
using Index = Scip.Index;
using Kind = Scip.SymbolInformation.Types.Kind;

namespace ScipDotnet.Tests;

[TestFixture]
public class SymbolKindTests
{
    private static readonly Dictionary<string, Kind> ExpectedKinds = new()
    {
        ["SymbolKinds/IShape#"] = Kind.Interface,
        ["SymbolKinds/Point#"] = Kind.Struct,
        ["SymbolKinds/Color#"] = Kind.Enum,
        ["SymbolKinds/Color#Red."] = Kind.EnumMember,
        ["SymbolKinds/Handler#"] = Kind.Delegate,
        ["SymbolKinds/Kinds#"] = Kind.Class,
        ["SymbolKinds/Kinds#Constant."] = Kind.Constant,
        ["SymbolKinds/Kinds#Field."] = Kind.Field,
        ["SymbolKinds/Kinds#StaticField."] = Kind.StaticField,
        ["SymbolKinds/Kinds#`.ctor`()."] = Kind.Constructor,
        ["SymbolKinds/Kinds#Property."] = Kind.Property,
        ["SymbolKinds/Kinds#StaticProperty."] = Kind.StaticProperty,
        ["SymbolKinds/Kinds#Event#"] = Kind.Event,
        ["SymbolKinds/Kinds#StaticEvent#"] = Kind.StaticEvent,
        ["SymbolKinds/Kinds#Method()."] = Kind.Method,
        ["SymbolKinds/Kinds#StaticMethod()."] = Kind.StaticMethod,
        ["SymbolKinds/KindsExtensions#"] = Kind.Class,
        ["SymbolKinds/KindsExtensions#Extension()."] = Kind.StaticMethod,
        ["SymbolKinds/VBClass#"] = Kind.Class,
        ["SymbolKinds/VBModule#"] = Kind.Module,
    };

    [Test]
    public void DefinitionsCarrySymbolKindAndDocumentsDeclareUtf16()
    {
        var directory = Path.Join(SnapshotTests.RootDirectory(), "snapshots", "input", "symbol-kinds");
        var index = Index.Parser.ParseFrom(File.ReadAllBytes(SnapshotTests.IndexDirectory(directory)));

        var kinds = index.Documents.SelectMany(document => document.Symbols).ToList();
        foreach (var (suffix, expected) in ExpectedKinds)
        {
            var matches = kinds.Where(info => info.Symbol.EndsWith(" " + suffix)).Select(info => info.Kind).ToList();
            Assert.That(matches, Has.Count.EqualTo(1), suffix);
            Assert.That(matches[0], Is.EqualTo(expected), suffix);
        }

        Assert.That(index.Documents.Select(document => document.Language).Distinct(),
            Is.EquivalentTo(new[] { "C#", "Visual Basic" }));
        Assert.That(index.Documents.Select(document => document.PositionEncoding),
            Has.All.EqualTo(PositionEncoding.Utf16CodeUnitOffsetFromLineStart));
    }
}

using System.Text.RegularExpressions;
using Scip;

namespace ScipDotnet;

/// <summary>
/// Utility class to format SCIP symbols.
/// </summary>
public class ScipSymbol
{
    public string Value { get; }

    private ScipSymbol(string value) => 
        Value = value;

    public bool IsLocal() =>
        Value.StartsWith("local ");

    public static ScipSymbol Global(ScipSymbol owner, SymbolDescriptor descriptor) =>
        new(owner.Value + DescriptorString(descriptor));

    public static ScipSymbol Local(int counter) =>
        new("local " + counter);

    public static readonly ScipSymbol Empty = new("");
    public static readonly ScipSymbol IndexLocalPackage = Package(".", ".");

    public static ScipSymbol Package(string name, string version) => 
        new(
            "scip-dotnet nuget " +
            // SCIP package names and versions should use double-space to escape space characters.
            name.Replace(" ", "  ") + " " +
            version.Replace(" ", "  ") + " "
        );

    private static string DescriptorString(SymbolDescriptor desc) => 
        desc.Suffix switch
        {
            SymbolDescriptor.Types.Suffix.Package => EscapedName(desc) + '/',
            SymbolDescriptor.Types.Suffix.Type => EscapedName(desc) + '#',
            SymbolDescriptor.Types.Suffix.Term => EscapedName(desc) + '.',
            SymbolDescriptor.Types.Suffix.Meta => EscapedName(desc) + ':',
            SymbolDescriptor.Types.Suffix.Method => EscapedName(desc) + '(' + (desc.Disambiguator ?? "") + ").",
            SymbolDescriptor.Types.Suffix.Parameter => '(' + EscapedName(desc) + ')',
            SymbolDescriptor.Types.Suffix.TypeParameter => '[' + EscapedName(desc) + ']',
            SymbolDescriptor.Types.Suffix.Local => "local" + EscapedName(desc),
            _ => throw new ArgumentException("unexpected descriptor suffix: " + desc.Suffix)
        };

    private static string EscapedName(SymbolDescriptor desc)
    {
        if (desc.Name == null)
        {
            return "";
        }

        if (IsSimpleIdentifier(desc.Name))
        {
            return desc.Name;
        }

        return "`" + desc.Name.Replace("`", "``") + "`";
    }

    private static bool IsSimpleIdentifier(string name) =>
        Regex.IsMatch(name, @"^[\w$+-]+$", RegexOptions.IgnoreCase);
}
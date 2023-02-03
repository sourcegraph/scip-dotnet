using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Google.Protobuf.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Scip;
using Document = Scip.Document;

namespace ScipDotnet;

/// <summary>
/// Walks a single C# syntax tree and produces a SCIP <code>Document</code>.
/// </summary>
public class ScipCSharpSyntaxWalker : CSharpSyntaxWalker
{
    private readonly Document _doc;
    private readonly SemanticModel _semanticModel;
    private readonly IndexCommandOptions _options;
    private int _localCounter;
    private readonly Dictionary<ISymbol, ScipSymbol> _globals;
    private readonly Dictionary<ISymbol, ScipSymbol> _locals = new(SymbolEqualityComparer.Default);

    private readonly SymbolDisplayFormat _format = new(
        globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining,
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
        genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters |
                         SymbolDisplayGenericsOptions.IncludeVariance |
                         SymbolDisplayGenericsOptions.IncludeTypeConstraints,
        memberOptions: SymbolDisplayMemberOptions.IncludeAccessibility | SymbolDisplayMemberOptions.IncludeModifiers |
                       SymbolDisplayMemberOptions.IncludeParameters | SymbolDisplayMemberOptions.IncludeRef |
                       SymbolDisplayMemberOptions.IncludeType | SymbolDisplayMemberOptions.IncludeConstantValue |
                       SymbolDisplayMemberOptions.IncludeContainingType |
                       SymbolDisplayMemberOptions.IncludeExplicitInterface,
        delegateStyle: SymbolDisplayDelegateStyle.NameAndSignature,
        extensionMethodStyle: SymbolDisplayExtensionMethodStyle.InstanceMethod,
        parameterOptions: SymbolDisplayParameterOptions.IncludeType | SymbolDisplayParameterOptions.IncludeName |
                          SymbolDisplayParameterOptions.IncludeDefaultValue |
                          SymbolDisplayParameterOptions.IncludeExtensionThis |
                          SymbolDisplayParameterOptions.IncludeOptionalBrackets |
                          SymbolDisplayParameterOptions.IncludeParamsRefOut,
        propertyStyle: SymbolDisplayPropertyStyle.ShowReadWriteDescriptor,
        localOptions: SymbolDisplayLocalOptions.IncludeType | SymbolDisplayLocalOptions.IncludeRef |
                      SymbolDisplayLocalOptions.IncludeConstantValue,
        kindOptions: SymbolDisplayKindOptions.IncludeTypeKeyword | SymbolDisplayKindOptions.IncludeMemberKeyword |
                     SymbolDisplayKindOptions.IncludeNamespaceKeyword,
        miscellaneousOptions: SymbolDisplayMiscellaneousOptions.AllowDefaultLiteral |
                              SymbolDisplayMiscellaneousOptions.ExpandNullable
    );

    public ScipCSharpSyntaxWalker(
        Document doc,
        SemanticModel semanticModel,
        IndexCommandOptions options,
        Dictionary<ISymbol, ScipSymbol> globals,
        SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node
    ) : base(depth)
    {
        _doc = doc;
        _semanticModel = semanticModel;
        _options = options;
        _globals = globals;
    }

    //-------------------------
    // Overridden visit methods
    //-------------------------

    public override void VisitIdentifierName(IdentifierNameSyntax node)
    {
        if (!node.IsVar)
        {
            VisitOccurrence(_semanticModel.GetSymbolInfo(node).Symbol, node.GetLocation(), false);
        }

        base.VisitIdentifierName(node);
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitClassDeclaration(node);
    }

    public override void VisitRecordDeclaration(RecordDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitRecordDeclaration(node);
    }

    public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEnumDeclaration(node);
    }

    public override void VisitCatchDeclaration(CatchDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitCatchDeclaration(node);
    }

    public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitConstructorDeclaration(node);
    }

    public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitDelegateDeclaration(node);
    }

    public override void VisitDestructorDeclaration(DestructorDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitDestructorDeclaration(node);
    }

    public override void VisitEventDeclaration(EventDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEventDeclaration(node);
    }

    public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitInterfaceDeclaration(node);
    }

    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitPropertyDeclaration(node);
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitStructDeclaration(node);
    }


    public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitVariableDeclarator(node);
    }


    public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEnumMemberDeclaration(node);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitMethodDeclaration(node);
    }

    public override void VisitParameter(ParameterSyntax node)
    {
        VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitParameter(node);
    }

    //------------------
    // Symbol formatting
    //------------------



    private ScipSymbol CreateScipSymbol(ISymbol? sym)
    {
        if (sym == null)
        {
            return ScipSymbol.Empty;
        }

        var fromCache = _globals.GetValueOrDefault(sym, ScipSymbol.Empty);
        if (fromCache != ScipSymbol.Empty)
        {
            return fromCache;
        }

        if (IsLocalSymbol(sym))
        {
            return CreateLocalScipSymbol(sym);
        }

        var owner = sym.Kind == SymbolKind.Namespace
            ? CreateScipPackageSymbol(sym)
            : CreateScipSymbol(sym.ContainingSymbol);

        if (owner.IsLocal())
        {
            return CreateLocalScipSymbol(sym);
        }


        var result = ScipSymbol.Global(owner, new SymbolDescriptor
        {
            Name = sym.Name,
            Suffix = SymbolSuffix(sym),
            Disambiguator = MethodDisambiguator(sym)
        });
        _globals.TryAdd(sym, result);
        return result;
    }


    private ScipSymbol CreateLocalScipSymbol(ISymbol sym)
    {
        var local = _locals.GetValueOrDefault(sym, ScipSymbol.Empty);
        if (local != ScipSymbol.Empty)
        {
            return local;
        }

        var localResult = ScipSymbol.Local(_localCounter++);
        _locals.TryAdd(sym, localResult);
        return localResult;
    }

    private ScipSymbol CreateScipPackageSymbol(ISymbol sym)
    {
        if (sym.ContainingAssembly == null)
        {
            return ScipSymbol.IndexLocalPackage;
        }

        if (!_options.AllowGlobalSymbolDefinitions && sym.Locations.Any(location => location.IsInSource))
        {
            // Emit index-local symbols to avoid exporting public symbols into the global scope (all repos in the world).
            // We have no guarantee that a random csproj file from any random repository is publishing to NuGet.
            // Use the command-line flag --allow-global-symbol-definitions to disable this behavior.
            return ScipSymbol.IndexLocalPackage;
        }


        return ScipSymbol.Package(
            sym.ContainingAssembly.Identity.Name,
            sym.ContainingAssembly.Identity.Version.ToString());
    }

    private SymbolDescriptor.Types.Suffix SymbolSuffix(ISymbol sym)
    {
        switch (sym.Kind)
        {
            case SymbolKind.Namespace:
                return SymbolDescriptor.Types.Suffix.Package;
            case SymbolKind.NamedType:
            case SymbolKind.FunctionPointerType:
            case SymbolKind.ErrorType:
            case SymbolKind.PointerType:
            case SymbolKind.ArrayType:
            case SymbolKind.DynamicType:
            case SymbolKind.Alias:
            case SymbolKind.Event:
                return SymbolDescriptor.Types.Suffix.Type;
            case SymbolKind.Property:
            case SymbolKind.Field:
            case SymbolKind.Assembly:
            case SymbolKind.Label:
            case SymbolKind.NetModule:
            case SymbolKind.RangeVariable:
            case SymbolKind.Preprocessing:
            case SymbolKind.Discard:
                return SymbolDescriptor.Types.Suffix.Term;
            case SymbolKind.Method:
                return SymbolDescriptor.Types.Suffix.Method;
            case SymbolKind.Parameter:
                return SymbolDescriptor.Types.Suffix.Parameter;
            case SymbolKind.TypeParameter:
                return SymbolDescriptor.Types.Suffix.TypeParameter;
            case SymbolKind.Local:
                return SymbolDescriptor.Types.Suffix.Local;
            default:
                _options.Logger.LogWarning("unknown symbol kind {SymKind}", sym.Kind);
                return SymbolDescriptor.Types.Suffix.Meta;
        }
    }

    private static string MethodDisambiguator(ISymbol sym)
    {
        if (sym is not IMethodSymbol)
        {
            return "";
        }

        var overloadCount = 0;
        foreach (var member in sym.ContainingType.GetMembers())
        {
            if (member.Equals(sym, SymbolEqualityComparer.Default))
            {
                return overloadCount == 0 ? "" : $"+{overloadCount}";
            }

            if (member.Name.Equals(sym.Name))
            {
                overloadCount++;
            }
        }

        return "";
    }


    private void VisitOccurrence(ISymbol? symbol, Location location, bool isDefinition)
    {
        if (symbol == null)
        {
            return;
        }

        var symbolRole = 0;
        if (isDefinition)
        {
            symbolRole |= (int)SymbolRole.Definition;
        }

        var scipSymbol = CreateScipSymbol(symbol).Value;
        var occurrence = new Occurrence
        {
            Symbol = scipSymbol,
            SymbolRoles = symbolRole
        };
        _doc.Occurrences.Add(occurrence);
        foreach (var range in LocationToRange(location))
        {
            occurrence.Range.Add(range);
        }

        if (!isDefinition) return;

        // Emit SymbolInformation for this definition occurrence.
        var info = new SymbolInformation { Symbol = scipSymbol };
        _doc.Symbols.Add(info);

        var symbolSignature = symbol.ToDisplayString(_format);
        if (symbolSignature.Length > 0)
        {
            info.Documentation.Add("```cs\n" + symbolSignature + "\n```");
        }

        var symbolDocumentation = symbol.GetDocumentationCommentXml();
        if (symbolDocumentation?.Length > 0)
        {
            info.Documentation.Add(symbolDocumentation);
        }

        switch (symbol)
        {
            case INamedTypeSymbol namedTypeSymbol:
                {
                    var baseType = namedTypeSymbol.BaseType;
                    while (baseType != null)
                    {
                        info.Relationships.Add(new Relationship
                        {
                            Symbol = CreateScipSymbol(baseType).Value,
                            IsImplementation = true
                        });
                        baseType = baseType.BaseType;
                    }

                    foreach (var interfaceSymbol in namedTypeSymbol.AllInterfaces)
                    {
                        info.Relationships.Add(new Relationship
                        {
                            Symbol = CreateScipSymbol(interfaceSymbol).Value,
                            IsImplementation = true
                        });
                    }

                    break;
                }
            case IMethodSymbol methodSymbol:
                {
                    var overriddenMethod = methodSymbol.OverriddenMethod;
                    while (overriddenMethod != null)
                    {
                        info.Relationships.Add(new Relationship
                        {
                            Symbol = CreateScipSymbol(overriddenMethod).Value,
                            IsImplementation = true,
                            IsReference = true
                        });
                        overriddenMethod = overriddenMethod.OverriddenMethod;
                    }

                    foreach (var interfaceMethod in InterfaceImplementations(methodSymbol))
                    {
                        info.Relationships.Add(new Relationship
                        {
                            Symbol = CreateScipSymbol(interfaceMethod).Value,
                            IsImplementation = true,
                            IsReference = true
                        });
                    }

                    break;
                }
        }
    }


    // Returns explicitly and implicitly implemented interface methods by the given symbol method.
    // The Roslyn API has a `ExplicitInterfaceImplementations` that does not return implicitly implemented
    // methods.
    private IEnumerable<ISymbol> InterfaceImplementations(IMethodSymbol symbol)
    {
        foreach (var interfaceSymbol in symbol.ContainingType.AllInterfaces)
        {
            foreach (var interfaceMember in interfaceSymbol.GetMembers())
            {
                var implementation = symbol.ContainingType.FindImplementationForInterfaceMember(interfaceMember);
                if (implementation != null && symbol.Equals(implementation, SymbolEqualityComparer.Default))
                {
                    yield return interfaceMember;
                }
            }
        }
    }


    // Converts a Roslyn location into a SCIP range.
    private static IEnumerable<int> LocationToRange(Location location)
    {
        var span = location.GetMappedLineSpan();
        if (span.StartLinePosition.Line == span.EndLinePosition.Line)
        {
            return new[]
                { span.StartLinePosition.Line, span.StartLinePosition.Character, span.EndLinePosition.Character };
        }

        return new[]
        {
            span.StartLinePosition.Line, span.StartLinePosition.Character, span.EndLinePosition.Line,
            span.EndLinePosition.Character
        };
    }

    private static bool IsLocalSymbol(ISymbol sym)
    {
        return sym.Kind == SymbolKind.Local || (sym.Kind != SymbolKind.Namespace && sym.Name.Equals(""));
    }
}
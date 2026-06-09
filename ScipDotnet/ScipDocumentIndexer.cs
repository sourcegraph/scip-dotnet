using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Scip;
using Document = Scip.Document;

namespace ScipDotnet;

/// <summary>
/// Creates SCIP <code>Document</code> based on provided symbols.
/// </summary>
public class ScipDocumentIndexer
{
    private readonly Document _doc;
    private readonly IndexCommandOptions _options;
    private int _localCounter;
    private readonly Dictionary<ISymbol, ScipSymbol> _globals;
    private readonly Dictionary<ISymbol, ScipSymbol> _locals = new(SymbolEqualityComparer.Default);

    // Index-wide accounting shared across every document, used to populate
    // Index.external_symbols. `_externalSymbols` maps a SCIP symbol string to the
    // SymbolInformation we will emit for a referenced external-package symbol.
    // `_definedSymbols` is the set of symbols that already have an in-source definition;
    // it lets us avoid duplicating a symbol in external_symbols (relevant when
    // --allow-global-symbol-definitions assigns a real package name to a source symbol).
    private readonly Dictionary<string, SymbolInformation> _externalSymbols;
    private readonly HashSet<string> _definedSymbols;
    private readonly string _markdownCodeFenceLanguage;

    // Custom formatting options to render symbol documentation. Feel free to tweak these parameters.
    // The options were derived by multiple rounds of experimentation with the goal of striking a
    // balance between showing detailed/accurate information without using too verbose syntax.
    private readonly SymbolDisplayFormat _format = new(
        globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining,
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly,
        genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters |
                         SymbolDisplayGenericsOptions.IncludeVariance |
                         SymbolDisplayGenericsOptions.IncludeTypeConstraints,
        memberOptions: SymbolDisplayMemberOptions.IncludeAccessibility |
                       SymbolDisplayMemberOptions.IncludeModifiers |
                       SymbolDisplayMemberOptions.IncludeParameters |
                       SymbolDisplayMemberOptions.IncludeRef |
                       SymbolDisplayMemberOptions.IncludeType |
                       SymbolDisplayMemberOptions.IncludeConstantValue |
                       SymbolDisplayMemberOptions.IncludeContainingType |
                       SymbolDisplayMemberOptions.IncludeExplicitInterface,
        delegateStyle: SymbolDisplayDelegateStyle.NameAndSignature,
        extensionMethodStyle: SymbolDisplayExtensionMethodStyle.InstanceMethod,
        parameterOptions: SymbolDisplayParameterOptions.IncludeType |
                          SymbolDisplayParameterOptions.IncludeName |
                          SymbolDisplayParameterOptions.IncludeDefaultValue |
                          SymbolDisplayParameterOptions.IncludeExtensionThis |
                          SymbolDisplayParameterOptions.IncludeOptionalBrackets |
                          SymbolDisplayParameterOptions.IncludeParamsRefOut,
        propertyStyle: SymbolDisplayPropertyStyle.ShowReadWriteDescriptor,
        localOptions: SymbolDisplayLocalOptions.IncludeType |
                      SymbolDisplayLocalOptions.IncludeRef |
                      SymbolDisplayLocalOptions.IncludeConstantValue,
        kindOptions: SymbolDisplayKindOptions.IncludeTypeKeyword |
                     SymbolDisplayKindOptions.IncludeMemberKeyword |
                     SymbolDisplayKindOptions.IncludeNamespaceKeyword,
        miscellaneousOptions: SymbolDisplayMiscellaneousOptions.AllowDefaultLiteral |
                              SymbolDisplayMiscellaneousOptions.UseSpecialTypes |
                              SymbolDisplayMiscellaneousOptions.UseAsterisksInMultiDimensionalArrays |
                              SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier |
                              SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers
    );

    public ScipDocumentIndexer(
        Document doc,
        IndexCommandOptions options,
        Dictionary<ISymbol, ScipSymbol> globals,
        Dictionary<string, SymbolInformation> externalSymbols,
        HashSet<string> definedSymbols)
    {
        _doc = doc;
        _options = options;
        _globals = globals;
        _externalSymbols = externalSymbols;
        _definedSymbols = definedSymbols;
        _markdownCodeFenceLanguage = _doc.Language == "C#" ? "cs" : "vb";
    }

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

    private readonly string[] _isIgnoredRelationshipSymbol =
    {
        " System/Object#",
        " System/Enum#",
        " System/ValueType#",
    };

    // Returns true if this symbol should not be emitted as a SymbolInformation relationship symbol.
    // The reason we ignore these symbols is because they appear automatically for a large number of
    // symbols putting pressure on our backend to index the inverted index. It's not particularly useful anyways
    // to query all the implementations of something like System/Object#.
    private bool IsIgnoredRelationshipSymbol(string symbol) =>
        _isIgnoredRelationshipSymbol.Any(symbol.EndsWith);

    public void VisitOccurrence(ISymbol? symbol, Location location, bool isDefinition)
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

        var scip = CreateScipSymbol(symbol);
        var scipSymbol = scip.Value;
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

        if (!isDefinition)
        {
            // This occurrence references a symbol that is not defined in the indexed
            // source. If it belongs to an external NuGet/BCL package, record a minimal
            // SymbolInformation so the reference is resolvable via Index.external_symbols.
            // Without this, every cross-package reference dangles (scip lint reports
            // "no matching SymbolInformation in external symbols or any document").
            if (scip.IsExternalPackageSymbol() && !_externalSymbols.ContainsKey(scipSymbol))
            {
                _externalSymbols[scipSymbol] = CreateExternalSymbolInformation(symbol, scipSymbol);
            }

            return;
        }

        // Emit SymbolInformation for this definition occurrence.
        _definedSymbols.Add(scipSymbol);
        var info = new SymbolInformation { Symbol = scipSymbol };
        _doc.Symbols.Add(info);

        var symbolSignature = symbol.ToDisplayString(_format);
        if (symbolSignature.Length > 0)
        {
            info.Documentation.Add($"```{_markdownCodeFenceLanguage}\n{symbolSignature}\n```");
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
                        var baseTypeScip = CreateScipSymbol(baseType);
                        if (IsIgnoredRelationshipSymbol(baseTypeScip.Value))
                        {
                            break;
                        }

                        info.Relationships.Add(new Relationship
                        {
                            Symbol = baseTypeScip.Value,
                            IsImplementation = true
                        });
                        CollectExternalRelationship(baseType, baseTypeScip);
                        baseType = baseType.BaseType;
                    }

                    foreach (var interfaceSymbol in namedTypeSymbol.AllInterfaces)
                    {
                        var interfaceScip = CreateScipSymbol(interfaceSymbol);
                        if (IsIgnoredRelationshipSymbol(interfaceScip.Value))
                        {
                            continue;
                        }

                        info.Relationships.Add(new Relationship
                        {
                            Symbol = interfaceScip.Value,
                            IsImplementation = true
                        });
                        CollectExternalRelationship(interfaceSymbol, interfaceScip);
                    }

                    break;
                }
            case IMethodSymbol methodSymbol:
                {
                    var overriddenMethod = methodSymbol.OverriddenMethod;
                    while (overriddenMethod != null)
                    {
                        var overriddenScip = CreateScipSymbol(overriddenMethod);
                        info.Relationships.Add(new Relationship
                        {
                            Symbol = overriddenScip.Value,
                            IsImplementation = true,
                            IsReference = true
                        });
                        CollectExternalRelationship(overriddenMethod, overriddenScip);
                        overriddenMethod = overriddenMethod.OverriddenMethod;
                    }

                    foreach (var interfaceMethod in ScipDocumentIndexer.InterfaceImplementations(methodSymbol))
                    {
                        var interfaceMethodScip = CreateScipSymbol(interfaceMethod);
                        info.Relationships.Add(new Relationship
                        {
                            Symbol = interfaceMethodScip.Value,
                            IsImplementation = true,
                            IsReference = true
                        });
                        CollectExternalRelationship(interfaceMethod, interfaceMethodScip);
                    }

                    break;
                }
        }
    }

    // Collects an external-package symbol that appears only as a relationship target
    // (e.g. an implicitly implemented IEquatable<T> on a record, or a transitive base
    // class / inherited interface that never appears textually in the source and so is
    // never seen by VisitOccurrence). Without this, the relationship dangles
    // (scip lint: "has a relationship to <symbol>, couldn't find #2").
    private void CollectExternalRelationship(ISymbol related, ScipSymbol scip)
    {
        if (scip.IsExternalPackageSymbol() && !_externalSymbols.ContainsKey(scip.Value))
        {
            _externalSymbols[scip.Value] = CreateExternalSymbolInformation(related, scip.Value);
        }
    }

    // Builds the SymbolInformation emitted into Index.external_symbols for a referenced
    // external-package symbol. We intentionally emit only the symbol and its hover
    // documentation: unlike in-source definitions we do NOT walk base types / interfaces,
    // because doing so would recurse across the entire BCL type graph and generate an
    // unbounded number of additional external symbols.
    private SymbolInformation CreateExternalSymbolInformation(ISymbol symbol, string scipSymbol)
    {
        var info = new SymbolInformation { Symbol = scipSymbol };

        var symbolSignature = symbol.ToDisplayString(_format);
        if (symbolSignature.Length > 0)
        {
            info.Documentation.Add($"```{_markdownCodeFenceLanguage}\n{symbolSignature}\n```");
        }

        var symbolDocumentation = symbol.GetDocumentationCommentXml();
        if (symbolDocumentation?.Length > 0)
        {
            info.Documentation.Add(symbolDocumentation);
        }

        return info;
    }

    // Returns explicitly and implicitly implemented interface methods by the given symbol method.
    // The Roslyn API has a `ExplicitInterfaceImplementations` that does not return implicitly implemented
    // methods.
    private static IEnumerable<ISymbol> InterfaceImplementations(IMethodSymbol symbol)
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
                {
                    span.StartLinePosition.Line,
                    span.StartLinePosition.Character,
                    span.EndLinePosition.Character
                };
        }

        return new[]
            {
                span.StartLinePosition.Line,
                span.StartLinePosition.Character,
                span.EndLinePosition.Line,
                span.EndLinePosition.Character
            };
    }

    private static bool IsLocalSymbol(ISymbol sym)
    {
        return sym.Kind == SymbolKind.Local ||
               sym.Kind == SymbolKind.RangeVariable ||
               sym.Kind == SymbolKind.TypeParameter ||
               sym is IMethodSymbol { MethodKind: MethodKind.LocalFunction } ||
               // Anonymous classes/methods have empty names and can not be accessed outside their file.
               // The "global namespace" (parent of all namespaces) also has an empty name and should not
               // be treated as a local variable.
               (sym.Name.Equals("") && sym.Kind != SymbolKind.Namespace);
    }
}

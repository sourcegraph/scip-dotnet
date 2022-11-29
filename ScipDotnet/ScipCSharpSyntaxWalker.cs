using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Shared.Extensions;
using Microsoft.Extensions.Logging;

namespace ScipDotnet;

public class ScipCSharpSyntaxWalker : CSharpSyntaxWalker
{
    private Document document;
    private SemanticModel semanticModel;
    private IndexOptions options;

    public ScipCSharpSyntaxWalker(Document document, SemanticModel semanticModel, IndexOptions options, SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node) : base(depth)
    {
        this.document = document;
        this.semanticModel = semanticModel;
        this.options = options;
    }

    public override void VisitIdentifierName(IdentifierNameSyntax node)
    {
        var info = semanticModel.GetSymbolInfo(node);
        if (info.Symbol != null)
        {
            options.logger.LogInformation($"symbol {info.Symbol}");
        }
        base.VisitIdentifierName(node);
    }

}
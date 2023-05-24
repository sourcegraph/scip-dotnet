using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Diagnostics;

namespace ScipDotnet;

/// <summary>
/// Walks a single VisualBasic syntax tree and produces a SCIP <code>Document</code>.
/// </summary>
public class ScipVisualBasicSyntaxWalker : VisualBasicSyntaxWalker
{
    private readonly SemanticModel _semanticModel;
    private readonly ScipDocumentIndexer _scipDocumentIndexer;

    public ScipVisualBasicSyntaxWalker(ScipDocumentIndexer scipSymbolFormatter, SemanticModel semanticModel, SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node) : base(depth)
    {
        _scipDocumentIndexer = scipSymbolFormatter;
        _semanticModel = semanticModel;
    }

    public override void VisitIdentifierName(IdentifierNameSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetSymbolInfo(node).Symbol, node.GetLocation(), false);
        base.VisitIdentifierName(node);
    }

    public override void VisitClassStatement(ClassStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitClassStatement(node);
    }

    public override void VisitModuleStatement(ModuleStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitModuleStatement(node);
    }

    public override void VisitEnumStatement(EnumStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEnumStatement(node);
    }

    public override void VisitCatchStatement(CatchStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.IdentifierName.Identifier.GetLocation(), true);
        base.VisitCatchStatement(node);
    }

    public override void VisitSubNewStatement(SubNewStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.NewKeyword.GetLocation(), true);
        base.VisitSubNewStatement(node);
    }

    public override void VisitDelegateStatement(DelegateStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitDelegateStatement(node);
    }

    public override void VisitEventStatement(EventStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEventStatement(node);
    }

    public override void VisitInterfaceStatement(InterfaceStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitInterfaceStatement(node);
    }

    public override void VisitPropertyStatement(PropertyStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitPropertyStatement(node);
    }

    public override void VisitStructureStatement(StructureStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitStructureStatement(node);
    }

    public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
    {
        foreach (var identifiers in node.Names)
        {
            _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(identifiers), identifiers.Identifier.GetLocation(), true);
        }
       base.VisitVariableDeclarator(node);
    }

    public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEnumMemberDeclaration(node);
    }

    public override void VisitMethodStatement(MethodStatementSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitMethodStatement(node);
    }

    public override void VisitParameter(ParameterSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitParameter(node);
    }

    public override void VisitTypeParameter(TypeParameterSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitTypeParameter(node);
    }
}
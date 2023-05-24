using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ScipDotnet;

/// <summary>
/// Walks a single C# syntax tree and produces a SCIP <code>Document</code>.
/// </summary>
public class ScipCSharpSyntaxWalker : CSharpSyntaxWalker
{
    private readonly SemanticModel _semanticModel;
    private readonly ScipDocumentIndexer _scipDocumentIndexer;

    public ScipCSharpSyntaxWalker(ScipDocumentIndexer scipSymbolFormatter, SemanticModel semanticModel, SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node) : base(depth)
    {
        _scipDocumentIndexer = scipSymbolFormatter;
        _semanticModel = semanticModel;
    }

    public override void VisitIdentifierName(IdentifierNameSyntax node)
    {
        if (!node.IsVar)
        {
            _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetSymbolInfo(node).Symbol, node.GetLocation(), false);
        }

        base.VisitIdentifierName(node);
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitClassDeclaration(node);
    }

    public override void VisitRecordDeclaration(RecordDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitRecordDeclaration(node);
    }

    public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEnumDeclaration(node);
    }

    public override void VisitCatchDeclaration(CatchDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitCatchDeclaration(node);
    }

    public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitConstructorDeclaration(node);
    }

    public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitDelegateDeclaration(node);
    }

    public override void VisitDestructorDeclaration(DestructorDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitDestructorDeclaration(node);
    }

    public override void VisitEventDeclaration(EventDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEventDeclaration(node);
    }

    public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitInterfaceDeclaration(node);
    }

    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitPropertyDeclaration(node);
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitStructDeclaration(node);
    }


    public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitVariableDeclarator(node);
    }


    public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitEnumMemberDeclaration(node);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitMethodDeclaration(node);
    }

    public override void VisitParameter(ParameterSyntax node)
    {
        _scipDocumentIndexer.VisitOccurrence(_semanticModel.GetDeclaredSymbol(node), node.Identifier.GetLocation(), true);
        base.VisitParameter(node);
    }
}
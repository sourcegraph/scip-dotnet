Imports System.Diagnostics.CodeAnalysis
Imports DiffPlex.DiffBuilder
Imports DiffPlex.DiffBuilder.Model

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Packages
        Private Function Diff() As DiffPaneModel
            Return InlineDiffBuilder.Diff("a", "b")
        End Function
    End Class
End Namespace

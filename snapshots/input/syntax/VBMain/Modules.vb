Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Module Modules
        Private Function [Function](ByVal b As Integer) As Integer
            Return b
        End Function

        Private Sub [Sub](ByVal Optional a As Integer = 5)
        End Sub

    End Module
End Namespace

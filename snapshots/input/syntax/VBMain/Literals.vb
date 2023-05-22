Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Literals
        Private Function Interpolation() As String
            Dim a = 1
            Dim b = 2
            Dim c = 3
            Dim d = 3
            Return $"a={a} b={b} c={c} d={d}"
        End Function
    End Class
End Namespace

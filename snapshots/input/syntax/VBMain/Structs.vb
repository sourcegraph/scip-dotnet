Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Structs
        Structure BasicStruct
            Public Property1 As Integer

            Public Sub New(ByVal field1 As Integer)
                Property1 = field1
            End Sub
        End Structure
    End Class
End Namespace

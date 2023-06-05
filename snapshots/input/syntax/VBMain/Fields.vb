Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Fields
        Class Fields1
            Private ReadOnly Property1 As Integer
            Private Property2, Property3 As Int64
            Private Property4 As Tuple(Of Char, Nullable(Of Integer))

            Public Sub New(ByVal field2 As Long, ByVal field3 As Long, ByVal field4 As Tuple(Of Char, Integer?), ByVal field1 As Integer)
                Property2 = field2
                Property3 = field3
                Property4 = field4
                Property1 = field1
            End Sub
        End Class
    End Class
End Namespace
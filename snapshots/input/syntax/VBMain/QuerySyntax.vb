Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class QuerySyntax
        Private sourceA As List(Of IGeneric) = New List(Of IGeneric)()
        Private sourceB As List(Of IGeneric) = New List(Of IGeneric)()

        Interface IGeneric
            Function Method() As String
        End Interface

        Private Sub [Select]()
            Dim x = From a In sourceA Select a.Method()
        End Sub

        Private Sub Projection()
            Dim x = From a In sourceA Select New With {Key .Name = a.Method()}
            Dim b = From a In x Select a.Name
        End Sub

        Private Sub Where()
            Dim x = From a In sourceA Where a.Method().StartsWith("a") Select a
        End Sub

        Private Sub [Let]()
            Dim x = From a In sourceA Let z = New With {Key .A = a.Method(), Key .B = a.Method()} Select z
        End Sub

        Private Sub Join()
            Dim x = From a In sourceA Join b In sourceB On a.Method() Equals b.Method() Select New With {Key .A = a.Method(), Key .B = b.Method()}
        End Sub

        Private Sub MultipleFrom()
            Dim x = From a In sourceA From b In sourceB Where a.Method() = b.Method() Select c = New With {Key .A = a.Method(), Key .B = b.Method()} Where c.A = String.Empty
        End Sub

        Private Sub Into(Students As List(Of Student))
            Dim sortedGroups = From student In Students Order By student.Last, student.First Group student By student.Last Into newGroup = Group Order By newGroup
        End Sub

        Private Class Student
            Public Property First As String
            Public Property Last As String
            Public Property ID As Integer
        End Class

    End Class
End Namespace

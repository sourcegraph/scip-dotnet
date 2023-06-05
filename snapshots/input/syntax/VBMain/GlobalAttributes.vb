Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True, Inherited:=True)>
    Public Class GlobalAttributes
        Inherits Attribute

        Class AuthorAttribute
            Inherits Attribute

            Public Sub New(ByVal name As String)
            End Sub
        End Class

        <Author("PropertyAttribute")>
        Public Z As Integer

        <Author("MethodAttribute")>
        Private Function Method1() As Integer
            Return 0
        End Function

        <Author("EnumAttribute")>
        Enum A
            B
            C
        End Enum

        <Author("EventAttribute")>
        Public Event SomeEvent As EventHandler

        <Author("TypeParameterAttribute")>
        Public Class InnerClass(Of T)
            Private Sub Method(Of T2)()
            End Sub
        End Class
    End Class
End Namespace

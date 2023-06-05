Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Methods
        Private Function SingleParameter(ByVal b As Integer) As Integer
            Return b
        End Function

        Private Function TwoParameters(ByVal a As Integer, ByVal b As Integer) As Integer
            Return a + b
        End Function

        Private Function Overload1(ByVal a As Integer) As Integer
            Return a
        End Function

        Private Function Overload1(ByVal a As Integer, ByVal b As Integer) As Integer
            Return a + b
        End Function

        Private Function Generic(Of T)(ByVal param As T) As T
            Return param
        End Function

        Private Function GenericConstraint(Of T As New)(ByVal param As T) As T
            Return param
        End Function

        Private Sub DefaultParameter(ByVal Optional a As Integer = 5)
        End Sub

        Private Function DefaultParameterOverload(ByVal Optional a As Integer = 5) As Integer
            Return DefaultParameterOverload(a, a)
        End Function

        Private Function DefaultParameterOverload(ByVal a As Integer, ByVal b As Integer) As Integer
            Return DefaultParameterOverload()
        End Function

        Interface IHello
            Function Hello() As String
        End Interface

        Class ImplementsHello
            Implements IHello

            Private Function Hello() As String Implements IHello.Hello
                Throw New NotImplementedException()
            End Function

        End Class

        Class InheritedOverloads1
            Public Sub Method()
            End Sub
        End Class

        Class InheritedOverloads2
            Inherits InheritedOverloads1

            Public Function Method(ByVal parameter As Integer) As Integer
                Return parameter
            End Function
        End Class

        Class InheritedOverloads3
            Inherits InheritedOverloads2

            Public Function Method(ByVal parameter As String) As String
                Return parameter
            End Function
        End Class

        Public Shared Sub InheritedOverloads()
            Dim a As InheritedOverloads1 = New InheritedOverloads1
            a.Method()
            Dim b As InheritedOverloads2 = New InheritedOverloads2
            DirectCast(b, InheritedOverloads1).Method()
            b.Method(42)
            Dim c As InheritedOverloads3 = New InheritedOverloads3
            DirectCast(c, InheritedOverloads1).Method()
            DirectCast(c, InheritedOverloads2).Method(42)
            c.Method("42")
        End Sub
    End Class
End Namespace

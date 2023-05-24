Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Expressions

        Private Sub AssignmentToPrefixUnaryExpressions()
            Dim A = 42
            Dim B = 42
            A = +A
            A = -A
            A = Not A
            B = A
            Dim C = True
            C = Not C
        End Sub

        Private Sub AssignmentToPrefixBinaryExpressions()
            Dim A = 42
            A = A + A
            A = A - A
            A = A * A
            A = A / A
            A = A \ A
            A = A ^ A
            A = A Mod A
            A = A And A
            A = A Or A
            A = A Xor A
            A = A << A
            A = A >> A
        End Sub

        Private Sub AssignmentToBinaryEqualityExpression()
            Dim A = True
            Dim B = True
            Dim C = 42
            Dim D = 42
            A = A = B
            A = A <> B
            A = C < D
            A = C <= D
            A = C > D
            A = C >= D
        End Sub

        Private Sub AssignmentToBinaryExpression()
            Dim A = 42
            A += A
            A -= A
            A *= A
            A /= A
            A \= A
            A &= A
            A <<= A
            A >>= A
            A ^= A
        End Sub

        Structure Struct
            Public [Property] As Integer
        End Structure

        Structure IndexedClass
            Public [Property] As Integer

            Default Public Property Item(ByVal index As Integer) As Integer
                Get
                    Return [Property]
                End Get
                Set(ByVal value As Integer)
                    [Property] = value
                End Set
            End Property
        End Structure

        Private Sub AssignmentToLeftValueTypes()
            Dim E As (A As Integer, B As Integer) = (1, 2)
            Dim A = 1
            Dim C = New Struct With {
                .[Property] = 42
            }
            C.[Property] = 1
            Dim D = New IndexedClass()
            D(E.B) = 1
            Dim X = New IndexedClass With {
                .[Property] = 1
            }
            E.A = 1
        End Sub

        Private Sub TernaryExpression()
            Dim X = True
            Dim Y = If(X, "foo", "bar")
            Dim Z As Object = True
            Dim T = If(TypeOf Z Is Boolean, 42, 41)
        End Sub

        Class Cast
            Public Nested As Cast
            Public Nested2 As Cast2

            Public Function Plus(ByVal other As Cast) As Cast
                Nested = other
                Return Me
            End Function

            Public Class Cast2
            End Class
        End Class

        Private Function CastExpressions() As Integer
            Dim A As Object = New Cast()
            Dim B As Object = New Cast()
            Dim C As Cast = (CType(A, Cast)).Plus(CType(B, Cast))
            Dim D As Cast = CType(New Object() {A, B}(0), Cast)
            Dim E = CType((C.Nested.Nested2), Cast.Cast2)
            Dim F = CType((1), Int32)
            Dim G = CType((1), Int32)
            Dim H = CType(((1)), Int32)
            Return F + G + H
        End Function

        Private Function AnonymousObject() As Object
            Dim X = New With {Key .Helper = ""}
            Dim Y = New With {X}
            Return Y.x.Helper
        End Function

        Class ObjectCreationClass
            Public Field As D

            Public Sub New(ByVal field As D)
                Me.Field = field
            End Sub

            Public Class D
                Public Sub New(ByVal a As Integer, ByVal b As String)
                End Sub
            End Class
        End Class

        Private Sub ObjectCreation()
            Dim A = New ObjectCreationClass.D(1, "hi")
            Dim B = New ObjectCreationClass(A) With {
                .Field = A
            }
            B = New ObjectCreationClass(A)
        End Sub

        Class NamedParametersClass
            Public A As Integer
            Public B As String

            Public Sub New(ByVal a As Integer, ByVal b As String)
                Me.A = a
                Me.B = b
            End Sub

            Public Sub Update(ByVal a As Integer, ByVal b As String)
                Me.A = a
                Me.B = b
            End Sub
        End Class

        Private Function NamedParameters() As NamedParametersClass
            Dim A = New NamedParametersClass(b:="hi", a:=1)
            A.Update(b:="foo", a:=42)
            Return A
        End Function

        Private Function AnonymousFunction() As Func(Of Integer, Integer)
            Dim d = Function(ByVal __ As Integer, ByVal ___ As Integer) 42
            Return Function(ByVal a As Integer) a + d.Invoke(a, a)
        End Function

        Class Lambda
            Public Function func(ByVal x As Lambda) As String
                Return ""
            End Function
        End Class

        Private Sub LambdaExpressions()
            Dim a = Function(ByVal x As String) x & 1
            Dim b = Function(ByVal aa As Lambda, ByVal bb As Lambda) aa.func(bb)
            Dim c = Function(aaa As Lambda, __ As Lambda)
                        If True Then
                            Return "hi"
                        End If
                    End Function
        End Sub

        Private Sub TupleExpression()
            Dim A = (1, 2, "")
        End Sub

        Private Sub ArrayCreation()
            Dim a = {
            {1, 1},
            {2, 2},
            {3, 3}}
            Dim d = New Integer(2) {1, 2, 3}
            Dim e = New Byte(,) {
            {1, 2},
            {2, 3}}
            Dim f = New Integer(2, 1) {
            {1, 1},
            {2, 2},
            {3, 3}}

            Dim numbers(4) As Integer
            Dim numbers2 = New Integer() {1, 2, 4, 8}
            ReDim Preserve numbers(15)
            ReDim numbers(15)
            Dim matrix(5, 5) As Double
            Dim matrix2 = New Integer(,) {{1, 2, 3}, {2, 3, 4}, {3, 4, 5}, {4, 5, 6}}
            Dim sales()() As Double = New Double(11)() {}
        End Sub

        Private Sub [TypeOf]()
            Dim a = GetType(Integer)
            Dim b = GetType(List(Of String).Enumerator)
            Dim c = GetType(Dictionary(Of,))
            Dim d = GetType(Tuple(Of,,,))
        End Sub

        Private Sub SelectCase()
            Dim Some = 42
            Select Case Some
                Case 1
                    Debug.WriteLine("One")
                Case 2
                    Debug.WriteLine("One")
                Case Else
                    Debug.WriteLine("More")
            End Select
        End Sub

        Private Sub Dictionary()
            Dim A = New Dictionary(Of String, Integer) From {{1, "Test1"}, {2, "Test1"}}
        End Sub

    End Class
End Namespace

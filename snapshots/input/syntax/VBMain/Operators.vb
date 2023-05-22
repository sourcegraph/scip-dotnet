Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Operators
        Public Class PlusMinus
            Public Shared Operator +(A As PlusMinus)
                Return 0
            End Operator

            Public Shared Operator +(A As PlusMinus, B As PlusMinus)
                Return 0
            End Operator

            Public Shared Operator -(A As PlusMinus)
                Return 0
            End Operator
        End Class

        Public Class TrueFalse
            Public Shared Operator IsTrue(A As TrueFalse) As Boolean
                Return True
            End Operator

            Public Shared Operator IsFalse(A As TrueFalse) As Boolean
                Return False
            End Operator

            Public Shared Operator =(A As TrueFalse, B As TrueFalse) As Boolean
                Return True
            End Operator

            Public Shared Operator <>(A As TrueFalse, B As TrueFalse) As Boolean
                Return True
            End Operator

            Public Overrides Function Equals(obj As Object) As Boolean
                If ReferenceEquals(Nothing, obj) Then Return False
                If ReferenceEquals(Me, obj) Then Return True
                If obj.GetType() <> Me.GetType() Then Return False
                Return Equals(CType(obj, TrueFalse))
            End Function

            Public Overrides Function GetHashCode() As Integer
                Throw New NotImplementedException()
            End Function

        End Class
    End Class
End Namespace

Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Classes

        Public Name As String
        Public Const IntConstant As Integer = 1
        Public Const StringConstant As String = "hello"

        Public Sub New(ByVal name As Integer)
            Me.Name = "name"
        End Sub

        Public Sub New(ByVal name As String)
            Me.Name = name
        End Sub

        Protected Overrides Sub Finalize()
            Console.WriteLine(42)
        End Sub

        Public Class ObjectClass
            Inherits Object
            Implements SomeInterface
        End Class

        Public Partial Class PartialClass
        End Class

        Class TypeParameterClass(Of T)
        End Class

        Friend Class InternalMultipleTypeParametersClass(Of T1, T2)
        End Class
        
        Interface ICovariantContravariant(Of In T1, Out T2)
        Sub Method1(ByVal t1 As T1)

        Function Method2() As T2

        End Interface

        Public Class StructConstraintClass(Of T As Structure)
        End Class

        Public Class ClassConstraintClass(Of T As Class)
        End Class

        Public Class NewConstraintClass(Of T As New)
        End Class

        Public Class TypeParameterConstraintClass(Of T As SomeInterface)
        End Class

        Private Class MultipleTypeParameterConstraintsClass(Of T1 As {SomeInterface, SomeInterface2, New}, T2 As SomeInterface2)
        End Class

        Class IndexClass
            Private a As Boolean

            Default Public Property Item(ByVal index As Integer) As Boolean
                Get
                    Return a
                End Get
                Set(ByVal value As Boolean)
                    a = value
                End Set
            End Property
        End Class

    Interface SomeInterface
    End Interface

    Friend Interface SomeInterface2
    End Interface

    End Class

End Namespace

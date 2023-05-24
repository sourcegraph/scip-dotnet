Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Interfaces
        Interface IOne
        End Interface

        Interface ITwo
        End Interface

        Interface IThree
        End Interface

        Interface IProperties
            ReadOnly Property [Get] As Byte
            WriteOnly Property [Set] As Char
            Property GetSet As UInteger
            Property SetGet As Long
        End Interface

        Interface IMethods
            Sub [Nothing]()
            Function Output() As Integer
            Sub Input(ByVal a As String)
            Function InputOutput(ByVal a As String) As Integer
        End Interface

        Interface IEvent
            Event SomeEvent As EventHandler(Of Integer)
        End Interface

        Interface IIndex
            Default Property Item(ByVal index As Integer) As Boolean
        End Interface

        Private Interface IInherit
            Inherits IOne, ITwo
        End Interface
    End Class
End Namespace

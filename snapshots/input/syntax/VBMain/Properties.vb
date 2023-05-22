Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Properties
        Private ReadOnly Property [Get] As Byte

        Private WriteOnly Property [Set] As Char
            Set(ByVal value As Char)
                Throw New NotImplementedException()
            End Set
        End Property

        Private Property GetSet As UInteger
        Private Property SetGet As Long
    End Class
End Namespace

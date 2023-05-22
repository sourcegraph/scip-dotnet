Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Enums
        Enum EnumWithIntValues
            Ten = 10
            Twenty = 20
        End Enum

        Enum EnumWithByteValues
            Five = &H05
            Fifteen = &H0F
        End Enum
    End Class
End Namespace
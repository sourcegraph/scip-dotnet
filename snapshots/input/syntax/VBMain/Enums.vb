Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Enums
        Enum EnumWithIntValues
            Ten = 10
            Twenty = 20
        End Enum

        Enum EnumWithByteValues
            Five = &H5
            Fifteen = &HF
        End Enum
    End Class
End Namespace
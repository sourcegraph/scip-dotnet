Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Preprocessors
        Private Function OperatingSystem() As String
#If WIN32 Then
            Dim Os As String = "Win32"
#warning This class is bad.
#error Okay, just stop.
#elif MACOS
            Dim Os As String = "MacOS"
#Else
            Dim Os As String = "Unknown"
#End If
            Return Os
        End Function
    End Class
End Namespace
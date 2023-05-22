Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Preprocessors
        Private Function OperatingSystem() As String
#if WIN32
            Dim Os As String = "Win32"
#warning This class is bad.
#error Okay, just stop.
#elif MACOS
            Dim Os As String = "MacOS"
#else
            Dim Os As String = "Unknown"
#End If
            Return Os
        End Function
    End Class
End Namespace
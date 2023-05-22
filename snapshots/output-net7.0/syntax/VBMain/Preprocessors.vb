  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Preprocessors
'                  ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Preprocessors#
'                                documentation ```vb\nClass Preprocessors\n```
          Private Function OperatingSystem() As String
'                          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Preprocessors#OperatingSystem().
'                                          documentation ```vb\nPrivate Function Preprocessors.OperatingSystem() As String\n```
  #if WIN32
              Dim Os As String = "Win32"
  #warning This class is bad.
  #error Okay, just stop.
  #elif MACOS
              Dim Os As String = "MacOS"
  #else
              Dim Os As String = "Unknown"
'                 ^^ definition local 0
'                    documentation ```vb\nOs As String\n```
  #End If
              Return Os
'                    ^^ reference local 0
          End Function
      End Class
  End Namespace

  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Literals
'                  ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Literals#
'                           documentation ```vb\nClass Literals\n```
          Private Function Interpolation() As String
'                          ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Literals#Interpolation().
'                                        documentation ```vb\nPrivate Function Literals.Interpolation() As String\n```
              Dim a = 1
'                 ^ definition local 0
'                   documentation ```vb\na As Integer\n```
              Dim b = 2
'                 ^ definition local 1
'                   documentation ```vb\nb As Integer\n```
              Dim c = 3
'                 ^ definition local 2
'                   documentation ```vb\nc As Integer\n```
              Dim d = 3
'                 ^ definition local 3
'                   documentation ```vb\nd As Integer\n```
              Return $"a={a} b={b} c={c} d={d}"
'                         ^ reference local 0
'                               ^ reference local 1
'                                     ^ reference local 2
'                                           ^ reference local 3
          End Function
      End Class
  End Namespace

  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Identifiers
'                  ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Identifiers#
'                              documentation ```vb\nClass Identifiers\n```
          Private Sub SpecialNames()
'                     ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Identifiers#SpecialNames().
'                                  documentation ```vb\nPrivate Sub Identifiers.SpecialNames()\n```
              Dim [const] = 42
'                 ^^^^^^^ definition local 0
'                         documentation ```vb\n[const] As Integer\n```
              Dim var As Integer = [const]
'                 ^^^ definition local 1
'                     documentation ```vb\nvar As Integer\n```
'                                  ^^^^^^^ reference local 0
              Dim under_score = 0
'                 ^^^^^^^^^^^ definition local 2
'                             documentation ```vb\nunder_score As Integer\n```
              Dim with1number = 0
'                 ^^^^^^^^^^^ definition local 3
'                             documentation ```vb\nwith1number As Integer\n```
              Dim varæble = 0
'                 ^^^^^^^ definition local 4
'                         documentation ```vb\nvaræble As Integer\n```
              Dim Переменная = 0
'                 ^^^^^^^^^^ definition local 5
'                            documentation ```vb\nПеременная As Integer\n```
              Dim first‿letter = 0
'                 ^^^^^^^^^^^^ definition local 6
'                              documentation ```vb\nfirst‿letter As Integer\n```
              Dim ග්රහලෝකය = 0
'                 ^^^^^^^^ definition local 7
'                          documentation ```vb\nග්රහලෝකය As Integer\n```
              Dim _كوكبxxx = 0
'                 ^^^^^^^^ definition local 8
'                          documentation ```vb\n_كوكبxxx As Integer\n```
          End Sub
      End Class
  End Namespace

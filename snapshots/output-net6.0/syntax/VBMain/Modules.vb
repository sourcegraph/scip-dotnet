  Imports System.Diagnostics.CodeAnalysis

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Module Modules
'                   ^^^^^^^ definition scip-dotnet nuget . . VBMain/Modules#
'                           documentation ```vb\nModule Modules\n```
          Private Function [Function](ByVal b As Integer) As Integer
'                          ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Modules#Function().
'                                     documentation ```vb\nPrivate Function Modules.Function(b As Integer) As Integer\n```
'                                           ^ definition local 0
'                                             documentation ```vb\nb As Integer\n```
              Return b
'                    ^ reference local 0
          End Function

          Private Sub [Sub](ByVal Optional a As Integer = 5)
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/Modules#Sub().
'                           documentation ```vb\nPrivate Sub Modules.Sub([a As Integer = 5])\n```
'                                          ^ definition local 1
'                                            documentation ```vb\n[a As Integer = 5]\n```
          End Sub

      End Module
  End Namespace

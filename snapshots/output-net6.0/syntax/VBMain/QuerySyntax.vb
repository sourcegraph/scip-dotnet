  Imports System.Diagnostics.CodeAnalysis

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Class QuerySyntax
'                  ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#
'                              documentation ```vb\nClass QuerySyntax\n```
          Private sourceA As List(Of IGeneric) = New List(Of IGeneric)()
'                 ^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                         documentation ```vb\nPrivate QuerySyntax.sourceA As List\n```
'                                    ^^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#
'                                                            ^^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#
          Private sourceB As List(Of IGeneric) = New List(Of IGeneric)()
'                 ^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                         documentation ```vb\nPrivate QuerySyntax.sourceB As List\n```
'                                    ^^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#
'                                                            ^^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#

          Interface IGeneric
'                   ^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#
'                            documentation ```vb\nInterface IGeneric\n```
              Function Method() As String
'                      ^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                             documentation ```vb\nFunction IGeneric.Method() As String\n```
          End Interface

          Private Sub [Select]()
'                     ^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Select().
'                              documentation ```vb\nPrivate Sub QuerySyntax.Select()\n```
              Dim x = From a In sourceA Select a.Method()
'                 ^ definition local 0
'                   documentation ```vb\nx As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                              ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Select().a.
          End Sub

          Private Sub Projection()
'                     ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Projection().
'                                documentation ```vb\nPrivate Sub QuerySyntax.Projection()\n```
              Dim x = From a In sourceA Select New With {Key .Name = a.Method()}
'                 ^ definition local 1
'                   documentation ```vb\nx As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                             ^^^^ reference local 3
'                                                                    ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Projection().a.
              Dim b = From a In x Select a.Name
'                 ^ definition local 4
'                   documentation ```vb\nb As \n```
'                               ^ reference local 1
'                                        ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Projection().a.
          End Sub

          Private Sub Where()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Where().
'                           documentation ```vb\nPrivate Sub QuerySyntax.Where()\n```
              Dim x = From a In sourceA Where a.Method().StartsWith("a") Select a
'                 ^ definition local 5
'                   documentation ```vb\nx As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                             ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Where().a.
'                                                                               ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Where().a.
          End Sub

          Private Sub [Let]()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Let().
'                           documentation ```vb\nPrivate Sub QuerySyntax.Let()\n```
              Dim x = From a In sourceA Let z = New With {Key .A = a.Method(), Key .B = a.Method()} Select z
'                 ^ definition local 6
'                   documentation ```vb\nx As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                              ^ reference local 8
'                                                                  ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Let().a.
'                                                                                   ^ reference local 9
'                                                                                       ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Let().a.
'                                                                                                          ^ reference local 11
          End Sub

          Private Sub Join()
'                     ^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Join().
'                          documentation ```vb\nPrivate Sub QuerySyntax.Join()\n```
              Dim x = From a In sourceA Join b In sourceB On a.Method() Equals b.Method() Select New With {Key .A = a.Method(), Key .B = b.Method()}
'                 ^ definition local 12
'                   documentation ```vb\nx As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                 ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                                                            ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().a.
'                                                                              ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().b.
'                                                                                                               ^ reference local 8
'                                                                                                                   ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().a.
'                                                                                                                                    ^ reference local 9
'                                                                                                                                        ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().b.
          End Sub

          Private Sub MultipleFrom()
'                     ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#MultipleFrom().
'                                  documentation ```vb\nPrivate Sub QuerySyntax.MultipleFrom()\n```
              Dim x = From a In sourceA From b In sourceB Where a.Method() = b.Method() Select New With {Key .A = a.Method(), Key .B = b.Method()}
'                 ^ definition local 13
'                   documentation ```vb\nx As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                 ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                                                               ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#MultipleFrom().a.
'                                                                            ^ reference local 15
'                                                                                                             ^ reference local 8
'                                                                                                                 ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#MultipleFrom().a.
'                                                                                                                                  ^ reference local 9
'                                                                                                                                      ^ reference local 15
          End Sub
      End Class
  End Namespace

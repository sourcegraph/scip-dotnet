  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class QuerySyntax
'                  ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#
'                              documentation ```vb\nClass QuerySyntax\n```
          Private sourceA As List(Of IGeneric) = New List(Of IGeneric)()
'                 ^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                         documentation ```vb\nPrivate QuerySyntax.sourceA As List(Of IGeneric)\n```
'                                    ^^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#
'                                                            ^^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#
          Private sourceB As List(Of IGeneric) = New List(Of IGeneric)()
'                 ^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                         documentation ```vb\nPrivate QuerySyntax.sourceB As List(Of IGeneric)\n```
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
'                   documentation ```vb\nx As Interface IEnumerable(Of String)\n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                              ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Select().a.
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
          End Sub

          Private Sub Projection()
'                     ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Projection().
'                                documentation ```vb\nPrivate Sub QuerySyntax.Projection()\n```
              Dim x = From a In sourceA Select New With {Key.Name = a.Method()}
'                 ^ definition local 1
'                   documentation ```vb\nx As Interface IEnumerable(Of <anonymous type: Key Name As String>)\n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                            ^^^^ reference local 3
'                                                                   ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Projection().a.
'                                                                     ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
              Dim b = From a In x Select a.Name
'                 ^ definition local 4
'                   documentation ```vb\nb As Interface IEnumerable(Of String)\n```
'                               ^ reference local 1
'                                        ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Projection().a.
'                                          ^^^^ reference local 3
          End Sub

          Private Sub Where()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Where().
'                           documentation ```vb\nPrivate Sub QuerySyntax.Where()\n```
              Dim x = From a In sourceA Where a.Method().StartsWith("a") Select a
'                 ^ definition local 5
'                   documentation ```vb\nx As Interface IEnumerable(Of IGeneric)\n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                             ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Where().a.
'                                               ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                        ^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/String#StartsWith(+1).
'                                                                               ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Where().a.
          End Sub

          Private Sub [Let]()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Let().
'                           documentation ```vb\nPrivate Sub QuerySyntax.Let()\n```
              Dim x = From a In sourceA Let z = New With { Key.A = a.Method(), Key.B = a.Method() } Select z
'                 ^ definition local 6
'                   documentation ```vb\nx As Interface IEnumerable(Of <anonymous type: Key A As String, Key B As String>)\n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                              ^ reference local 8
'                                                                  ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Let().a.
'                                                                    ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                                  ^ reference local 9
'                                                                                      ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Let().a.
'                                                                                        ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                                                          ^ reference local 11
          End Sub

          Private Sub Join()
'                     ^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Join().
'                          documentation ```vb\nPrivate Sub QuerySyntax.Join()\n```
              Dim x = From a In sourceA Join b In sourceB On a.Method() Equals b.Method() Select New With { Key.A = a.Method(), Key.B = b.Method() }
'                 ^ definition local 12
'                   documentation ```vb\nx As Interface IEnumerable(Of <anonymous type: Key A As String, Key B As String>)\n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                 ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                                                            ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().a.
'                                                              ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                              ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().b.
'                                                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                                                               ^ reference local 8
'                                                                                                                   ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().a.
'                                                                                                                     ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                                                                                   ^ reference local 9
'                                                                                                                                       ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Join().b.
'                                                                                                                                         ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
          End Sub

          Private Sub MultipleFrom()
'                     ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#MultipleFrom().
'                                  documentation ```vb\nPrivate Sub QuerySyntax.MultipleFrom()\n```
              Dim x = From a In sourceA From b In sourceB Where a.Method() = b.Method() Select New With { Key.A = a.Method(), Key.B = b.Method() }
'                 ^ definition local 13
'                   documentation ```vb\nx As Interface IEnumerable(Of <anonymous type: Key A As String, Key B As String>)\n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                 ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                                                               ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#MultipleFrom().a.
'                                                                 ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                            ^ reference local 15
'                                                                              ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                                                             ^ reference local 8
'                                                                                                                 ^ reference scip-dotnet nuget . . VBMain/QuerySyntax#MultipleFrom().a.
'                                                                                                                   ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
'                                                                                                                                 ^ reference local 9
'                                                                                                                                     ^ reference local 15
'                                                                                                                                       ^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#IGeneric#Method().
          End Sub
      End Class
  End Namespace

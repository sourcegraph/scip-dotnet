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
'                          ^ definition local 1
'                            documentation ```vb\na As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                              ^ reference local 1
          End Sub

          Private Sub Projection()
'                     ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Projection().
'                                documentation ```vb\nPrivate Sub QuerySyntax.Projection()\n```
              Dim x = From a In sourceA Select New With {Key .Name = a.Method()}
'                 ^ definition local 2
'                   documentation ```vb\nx As \n```
'                          ^ definition local 3
'                            documentation ```vb\na As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                                             ^^^^ reference local 5
'                                                                    ^ reference local 3
              Dim b = From a In x Select a.Name
'                 ^ definition local 6
'                   documentation ```vb\nb As \n```
'                          ^ definition local 7
'                            documentation ```vb\na As \n```
'                               ^ reference local 2
'                                        ^ reference local 7
          End Sub

          Private Sub Where()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Where().
'                           documentation ```vb\nPrivate Sub QuerySyntax.Where()\n```
              Dim x = From a In sourceA Where a.Method().StartsWith("a") Select a
'                 ^ definition local 8
'                   documentation ```vb\nx As \n```
'                          ^ definition local 9
'                            documentation ```vb\na As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                             ^ reference local 9
'                                                                               ^ reference local 9
          End Sub

          Private Sub [Let]()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Let().
'                           documentation ```vb\nPrivate Sub QuerySyntax.Let()\n```
              Dim x = From a In sourceA Let z = New With {Key .A = a.Method(), Key .B = a.Method()} Select z
'                 ^ definition local 10
'                   documentation ```vb\nx As \n```
'                          ^ definition local 11
'                            documentation ```vb\na As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                           ^ definition local 12
'                                             documentation ```vb\nz As AnonymousType <anonymous type: Key A As , Key B As >\n```
'                                                              ^ reference local 14
'                                                                  ^ reference local 11
'                                                                                   ^ reference local 15
'                                                                                       ^ reference local 11
'                                                                                                          ^ reference local 12
          End Sub

          Private Sub Join()
'                     ^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Join().
'                          documentation ```vb\nPrivate Sub QuerySyntax.Join()\n```
              Dim x = From a In sourceA Join b In sourceB On a.Method() Equals b.Method() Select New With {Key .A = a.Method(), Key .B = b.Method()}
'                 ^ definition local 16
'                   documentation ```vb\nx As \n```
'                          ^ definition local 17
'                            documentation ```vb\na As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                            ^ definition local 18
'                                              documentation ```vb\nb As \n```
'                                                 ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                                                            ^ reference local 17
'                                                                              ^ reference local 18
'                                                                                                               ^ reference local 14
'                                                                                                                   ^ reference local 17
'                                                                                                                                    ^ reference local 15
'                                                                                                                                        ^ reference local 18
          End Sub

          Private Sub MultipleFrom()
'                     ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#MultipleFrom().
'                                  documentation ```vb\nPrivate Sub QuerySyntax.MultipleFrom()\n```
              Dim x = From a In sourceA From b In sourceB Where a.Method() = b.Method() Select c = New With {Key .A = a.Method(), Key .B = b.Method()} Where c.A = String.Empty
'                 ^ definition local 19
'                   documentation ```vb\nx As \n```
'                          ^ definition local 20
'                            documentation ```vb\na As \n```
'                               ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceA.
'                                            ^ definition local 21
'                                              documentation ```vb\nb As \n```
'                                                 ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#sourceB.
'                                                               ^ reference local 20
'                                                                            ^ reference local 21
'                                                                                              ^ definition local 22
'                                                                                                documentation ```vb\nc As AnonymousType <anonymous type: Key A As , Key B As >\n```
'                                                                                                                 ^ reference local 14
'                                                                                                                     ^ reference local 20
'                                                                                                                                      ^ reference local 15
'                                                                                                                                          ^ reference local 21
'                                                                                                                                                            ^ reference local 22
'                                                                                                                                                              ^ reference local 14
          End Sub

          Private Sub Into(Students As List(Of Student))
'                     ^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Into().
'                          documentation ```vb\nPrivate Sub QuerySyntax.Into(Students As List)\n```
'                          ^^^^^^^^ definition local 23
'                                   documentation ```vb\nStudents As List\n```
'                                              ^^^^^^^ reference scip-dotnet nuget . . VBMain/QuerySyntax#Student#
              Dim sortedGroups = From student In Students Order By student.Last, student.First Group student By student.Last Into newGroup = Group Order By newGroup
'                 ^^^^^^^^^^^^ definition local 24
'                              documentation ```vb\nsortedGroups As \n```
'                                     ^^^^^^^ definition local 25
'                                             documentation ```vb\nstudent As \n```
'                                                ^^^^^^^^ reference local 23
'                                                                  ^^^^^^^ reference local 25
'                                                                                ^^^^^^^ reference local 25
'                                                                                                    ^^^^^^^ reference local 25
'                                                                                                               ^^^^^^^ reference local 25
'                                                                                                                                 ^^^^^^^^ definition local 26
'                                                                                                                                          documentation ```vb\nnewGroup As \n```
'                                                                                                                                                           ^^^^^^^^ reference local 26
          End Sub

          Private Class Student
'                       ^^^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Student#
'                               documentation ```vb\nClass Student\n```
              Public Property First As String
'                             ^^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Student#First.
'                                   documentation ```vb\nPublic Property Student.First As String\n```
              Public Property Last As String
'                             ^^^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Student#Last.
'                                  documentation ```vb\nPublic Property Student.Last As String\n```
              Public Property ID As Integer
'                             ^^ definition scip-dotnet nuget . . VBMain/QuerySyntax#Student#ID.
'                                documentation ```vb\nPublic Property Student.ID As Integer\n```
          End Class

      End Class
  End Namespace

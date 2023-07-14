  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Methods
'                  ^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#
'                          documentation ```vb\nClass Methods\n```
          Private Function SingleParameter(ByVal b As Integer) As Integer
'                          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#SingleParameter().
'                                          documentation ```vb\nPrivate Function Methods.SingleParameter(b As Integer) As Integer\n```
'                                                ^ definition local 0
'                                                  documentation ```vb\nb As Integer\n```
              Return b
'                    ^ reference local 0
          End Function

          Private Function TwoParameters(ByVal a As Integer, ByVal b As Integer) As Integer
'                          ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#TwoParameters().
'                                        documentation ```vb\nPrivate Function Methods.TwoParameters(a As Integer, b As Integer) As Integer\n```
'                                              ^ definition local 1
'                                                documentation ```vb\na As Integer\n```
'                                                                  ^ definition local 2
'                                                                    documentation ```vb\nb As Integer\n```
              Return a + b
'                    ^ reference local 1
'                        ^ reference local 2
          End Function

          Private Function Overload1(ByVal a As Integer) As Integer
'                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#Overload1().
'                                    documentation ```vb\nPrivate Function Methods.Overload1(a As Integer) As Integer\n```
'                                          ^ definition local 3
'                                            documentation ```vb\na As Integer\n```
              Return a
'                    ^ reference local 3
          End Function

          Private Function Overload1(ByVal a As Integer, ByVal b As Integer) As Integer
'                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#Overload1(+1).
'                                    documentation ```vb\nPrivate Function Methods.Overload1(a As Integer, b As Integer) As Integer\n```
'                                          ^ definition local 4
'                                            documentation ```vb\na As Integer\n```
'                                                              ^ definition local 5
'                                                                documentation ```vb\nb As Integer\n```
              Return a + b
'                    ^ reference local 4
'                        ^ reference local 5
          End Function

          Private Function Generic(Of T)(ByVal param As T) As T
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#Generic().
'                                  documentation ```vb\nPrivate Function Methods.Generic(Of T)(param As T) As T\n```
'                                     ^ definition local 6
'                                       documentation ```vb\nT\n```
'                                              ^^^^^ definition local 7
'                                                    documentation ```vb\nparam As T\n```
'                                                       ^ reference local 6
'                                                             ^ reference local 6
              Return param
'                    ^^^^^ reference local 7
          End Function

          Private Function GenericConstraint(Of T As New)(ByVal param As T) As T
'                          ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#GenericConstraint().
'                                            documentation ```vb\nPrivate Function Methods.GenericConstraint(Of T As New)(param As T) As T\n```
'                                               ^ definition local 8
'                                                 documentation ```vb\nT\n```
'                                                               ^^^^^ definition local 9
'                                                                     documentation ```vb\nparam As T\n```
'                                                                        ^ reference local 8
'                                                                              ^ reference local 8
              Return param
'                    ^^^^^ reference local 9
          End Function

          Private Sub DefaultParameter(ByVal Optional a As Integer = 5)
'                     ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameter().
'                                      documentation ```vb\nPrivate Sub Methods.DefaultParameter([a As Integer = 5])\n```
'                                                     ^ definition local 10
'                                                       documentation ```vb\n[a As Integer = 5]\n```
          End Sub

          Private Function DefaultParameterOverload(ByVal Optional a As Integer = 5) As Integer
'                          ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload().
'                                                   documentation ```vb\nPrivate Function Methods.DefaultParameterOverload([a As Integer = 5]) As Integer\n```
'                                                                  ^ definition local 11
'                                                                    documentation ```vb\n[a As Integer = 5]\n```
              Return DefaultParameterOverload(a, a)
'                    ^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload(+1).
'                                             ^ reference local 11
'                                                ^ reference local 11
          End Function

          Private Function DefaultParameterOverload(ByVal a As Integer, ByVal b As Integer) As Integer
'                          ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload(+1).
'                                                   documentation ```vb\nPrivate Function Methods.DefaultParameterOverload(a As Integer, b As Integer) As Integer\n```
'                                                         ^ definition local 12
'                                                           documentation ```vb\na As Integer\n```
'                                                                             ^ definition local 13
'                                                                               documentation ```vb\nb As Integer\n```
              Return DefaultParameterOverload()
'                    ^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload().
          End Function

          Interface IHello
'                   ^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#IHello#
'                          documentation ```vb\nInterface IHello\n```
              Function Hello() As String
'                      ^^^^^ definition scip-dotnet nuget . . VBMain/Methods#IHello#Hello().
'                            documentation ```vb\nFunction IHello.Hello() As String\n```
          End Interface

          Class ImplementsHello
'               ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#ImplementsHello#
'                               documentation ```vb\nClass ImplementsHello\n```
'                               relationship implementation scip-dotnet nuget . . VBMain/Methods#IHello#
              Implements IHello
'                        ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#IHello#

              Private Function Hello() As String Implements IHello.Hello
'                              ^^^^^ definition scip-dotnet nuget . . VBMain/Methods#ImplementsHello#Hello().
'                                    documentation ```vb\nPrivate Function ImplementsHello.Hello() As String\n```
'                                    relationship implementation reference scip-dotnet nuget . . VBMain/Methods#IHello#Hello().
'                                                           ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#IHello#
'                                                                  ^^^^^ reference scip-dotnet nuget . . VBMain/Methods#IHello#Hello().
                  Throw New NotImplementedException()
'                           ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
              End Function

          End Class

          Class InheritedOverloads1
'               ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
'                                   documentation ```vb\nClass InheritedOverloads1\n```
              Public Sub Method()
'                        ^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#Method().
'                               documentation ```vb\nPublic Sub InheritedOverloads1.Method()\n```
              End Sub
          End Class

          Class InheritedOverloads2
'               ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
'                                   documentation ```vb\nClass InheritedOverloads2\n```
'                                   relationship implementation scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
              Inherits InheritedOverloads1
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#

              Public Function Method(ByVal parameter As Integer) As Integer
'                             ^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#Method().
'                                    documentation ```vb\nPublic Function InheritedOverloads2.Method(parameter As Integer) As Integer\n```
'                                          ^^^^^^^^^ definition local 14
'                                                    documentation ```vb\nparameter As Integer\n```
                  Return parameter
'                        ^^^^^^^^^ reference local 14
              End Function
          End Class

          Class InheritedOverloads3
'               ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#
'                                   documentation ```vb\nClass InheritedOverloads3\n```
'                                   relationship implementation scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
'                                   relationship implementation scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
              Inherits InheritedOverloads2
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#

              Public Function Method(ByVal parameter As String) As String
'                             ^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#Method().
'                                    documentation ```vb\nPublic Function InheritedOverloads3.Method(parameter As String) As String\n```
'                                          ^^^^^^^^^ definition local 15
'                                                    documentation ```vb\nparameter As String\n```
                  Return parameter
'                        ^^^^^^^^^ reference local 15
              End Function
          End Class

          Public Shared Sub InheritedOverloads()
'                           ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads().
'                                              documentation ```vb\nPublic Shared Sub Methods.InheritedOverloads()\n```
              Dim a As InheritedOverloads1 = New InheritedOverloads1
'                 ^ definition local 16
'                   documentation ```vb\na As Class InheritedOverloads1\n```
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
'                                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
              a.Method()
'             ^ reference local 16
'               ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#Method().
              Dim b As InheritedOverloads2 = New InheritedOverloads2
'                 ^ definition local 17
'                   documentation ```vb\nb As Class InheritedOverloads2\n```
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
'                                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
              DirectCast(b, InheritedOverloads1).Method()
'                        ^ reference local 17
'                           ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#Method().
              b.Method(42)
'             ^ reference local 17
'               ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#Method().
              Dim c As InheritedOverloads3 = New InheritedOverloads3
'                 ^ definition local 18
'                   documentation ```vb\nc As Class InheritedOverloads3\n```
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#
'                                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#
              DirectCast(c, InheritedOverloads1).Method()
'                        ^ reference local 18
'                           ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#Method().
              DirectCast(c, InheritedOverloads2).Method(42)
'                        ^ reference local 18
'                           ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#Method().
              c.Method("42")
'             ^ reference local 18
'               ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#Method().
          End Sub
      End Class
  End Namespace

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
'                                                ^ definition scip-dotnet nuget . . VBMain/Methods#SingleParameter().(b)
'                                                  documentation ```vb\nb As Integer\n```
              Return b
'                    ^ reference scip-dotnet nuget . . VBMain/Methods#SingleParameter().(b)
          End Function

          Private Function TwoParameters(ByVal a As Integer, ByVal b As Integer) As Integer
'                          ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#TwoParameters().
'                                        documentation ```vb\nPrivate Function Methods.TwoParameters(a As Integer, b As Integer) As Integer\n```
'                                              ^ definition scip-dotnet nuget . . VBMain/Methods#TwoParameters().(a)
'                                                documentation ```vb\na As Integer\n```
'                                                                  ^ definition scip-dotnet nuget . . VBMain/Methods#TwoParameters().(b)
'                                                                    documentation ```vb\nb As Integer\n```
              Return a + b
'                    ^ reference scip-dotnet nuget . . VBMain/Methods#TwoParameters().(a)
'                        ^ reference scip-dotnet nuget . . VBMain/Methods#TwoParameters().(b)
          End Function

          Private Function Overload1(ByVal a As Integer) As Integer
'                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#Overload1().
'                                    documentation ```vb\nPrivate Function Methods.Overload1(a As Integer) As Integer\n```
'                                          ^ definition scip-dotnet nuget . . VBMain/Methods#Overload1().(a)
'                                            documentation ```vb\na As Integer\n```
              Return a
'                    ^ reference scip-dotnet nuget . . VBMain/Methods#Overload1().(a)
          End Function

          Private Function Overload1(ByVal a As Integer, ByVal b As Integer) As Integer
'                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#Overload1(+1).
'                                    documentation ```vb\nPrivate Function Methods.Overload1(a As Integer, b As Integer) As Integer\n```
'                                          ^ definition scip-dotnet nuget . . VBMain/Methods#Overload1(+1).(a)
'                                            documentation ```vb\na As Integer\n```
'                                                              ^ definition scip-dotnet nuget . . VBMain/Methods#Overload1(+1).(b)
'                                                                documentation ```vb\nb As Integer\n```
              Return a + b
'                    ^ reference scip-dotnet nuget . . VBMain/Methods#Overload1(+1).(a)
'                        ^ reference scip-dotnet nuget . . VBMain/Methods#Overload1(+1).(b)
          End Function

          Private Function Generic(Of T)(ByVal param As T) As T
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#Generic().
'                                  documentation ```vb\nPrivate Function Methods.Generic(Of T)(param As T) As T\n```
'                                     ^ definition scip-dotnet nuget . . VBMain/Methods#Generic().[T]
'                                       documentation ```vb\nT\n```
'                                              ^^^^^ definition scip-dotnet nuget . . VBMain/Methods#Generic().(param)
'                                                    documentation ```vb\nparam As T\n```
'                                                       ^ reference scip-dotnet nuget . . VBMain/Methods#Generic().[T]
'                                                             ^ reference scip-dotnet nuget . . VBMain/Methods#Generic().[T]
              Return param
'                    ^^^^^ reference scip-dotnet nuget . . VBMain/Methods#Generic().(param)
          End Function

          Private Function GenericConstraint(Of T As New)(ByVal param As T) As T
'                          ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#GenericConstraint().
'                                            documentation ```vb\nPrivate Function Methods.GenericConstraint(Of T As New)(param As T) As T\n```
'                                               ^ definition scip-dotnet nuget . . VBMain/Methods#GenericConstraint().[T]
'                                                 documentation ```vb\nT\n```
'                                                               ^^^^^ definition scip-dotnet nuget . . VBMain/Methods#GenericConstraint().(param)
'                                                                     documentation ```vb\nparam As T\n```
'                                                                        ^ reference scip-dotnet nuget . . VBMain/Methods#GenericConstraint().[T]
'                                                                              ^ reference scip-dotnet nuget . . VBMain/Methods#GenericConstraint().[T]
              Return param
'                    ^^^^^ reference scip-dotnet nuget . . VBMain/Methods#GenericConstraint().(param)
          End Function

          Private Sub DefaultParameter(ByVal Optional a As Integer = 5)
'                     ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameter().
'                                      documentation ```vb\nPrivate Sub Methods.DefaultParameter([a As Integer = 5])\n```
'                                                     ^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameter().(a)
'                                                       documentation ```vb\n[a As Integer = 5]\n```
          End Sub

          Private Function DefaultParameterOverload(ByVal Optional a As Integer = 5) As Integer
'                          ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload().
'                                                   documentation ```vb\nPrivate Function Methods.DefaultParameterOverload([a As Integer = 5]) As Integer\n```
'                                                                  ^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload().(a)
'                                                                    documentation ```vb\n[a As Integer = 5]\n```
              Return DefaultParameterOverload(a, a)
'                    ^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload(+1).
'                                             ^ reference scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload().(a)
'                                                ^ reference scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload().(a)
          End Function

          Private Function DefaultParameterOverload(ByVal a As Integer, ByVal b As Integer) As Integer
'                          ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload(+1).
'                                                   documentation ```vb\nPrivate Function Methods.DefaultParameterOverload(a As Integer, b As Integer) As Integer\n```
'                                                         ^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload(+1).(a)
'                                                           documentation ```vb\na As Integer\n```
'                                                                             ^ definition scip-dotnet nuget . . VBMain/Methods#DefaultParameterOverload(+1).(b)
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
'                                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#Method().(parameter)
'                                                    documentation ```vb\nparameter As Integer\n```
                  Return parameter
'                        ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#Method().(parameter)
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
'                                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#Method().(parameter)
'                                                    documentation ```vb\nparameter As String\n```
                  Return parameter
'                        ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#Method().(parameter)
              End Function
          End Class

          Public Shared Sub InheritedOverloads()
'                           ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Methods#InheritedOverloads().
'                                              documentation ```vb\nPublic Shared Sub Methods.InheritedOverloads()\n```
              Dim a as InheritedOverloads1 = New InheritedOverloads1
'                 ^ definition local 0
'                   documentation ```vb\na As Class InheritedOverloads1\n```
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
'                                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
              a.Method()
'             ^ reference local 0
'               ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#Method().
              Dim b as InheritedOverloads2 = New InheritedOverloads2
'                 ^ definition local 1
'                   documentation ```vb\nb As Class InheritedOverloads2\n```
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
'                                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
              DirectCast(b, InheritedOverloads1).Method()
'                        ^ reference local 1
'                           ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#Method().
              b.Method(42)
'             ^ reference local 1
'               ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#Method().
              Dim c as InheritedOverloads3 = New InheritedOverloads3
'                 ^ definition local 2
'                   documentation ```vb\nc As Class InheritedOverloads3\n```
'                      ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#
'                                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#
              DirectCast(c, InheritedOverloads1).Method()
'                        ^ reference local 2
'                           ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads1#Method().
              DirectCast(c, InheritedOverloads2).Method(42)
'                        ^ reference local 2
'                           ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads2#Method().
              c.Method("42")
'             ^ reference local 2
'               ^^^^^^ reference scip-dotnet nuget . . VBMain/Methods#InheritedOverloads3#Method().
          End Sub
      End Class
  End Namespace

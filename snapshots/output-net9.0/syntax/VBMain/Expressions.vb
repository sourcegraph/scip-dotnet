  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Expressions
'                  ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#
'                              documentation ```vb\nClass Expressions\n```

          Private Sub AssignmentToPrefixUnaryExpressions()
'                     ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#AssignmentToPrefixUnaryExpressions().
'                                                        documentation ```vb\nPrivate Sub Expressions.AssignmentToPrefixUnaryExpressions()\n```
              Dim A = 42
'                 ^ definition local 0
'                   documentation ```vb\nA As Integer\n```
              Dim B = 42
'                 ^ definition local 1
'                   documentation ```vb\nB As Integer\n```
              A = +A
'             ^ reference local 0
'                  ^ reference local 0
              A = -A
'             ^ reference local 0
'                  ^ reference local 0
              A = Not A
'             ^ reference local 0
'                     ^ reference local 0
              B = A
'             ^ reference local 1
'                 ^ reference local 0
              Dim C = True
'                 ^ definition local 2
'                   documentation ```vb\nC As Boolean\n```
              C = Not C
'             ^ reference local 2
'                     ^ reference local 2
          End Sub

          Private Sub AssignmentToPrefixBinaryExpressions()
'                     ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#AssignmentToPrefixBinaryExpressions().
'                                                         documentation ```vb\nPrivate Sub Expressions.AssignmentToPrefixBinaryExpressions()\n```
              Dim A = 42
'                 ^ definition local 3
'                   documentation ```vb\nA As Integer\n```
              A = A + A
'             ^ reference local 3
'                 ^ reference local 3
'                     ^ reference local 3
              A = A - A
'             ^ reference local 3
'                 ^ reference local 3
'                     ^ reference local 3
              A = A * A
'             ^ reference local 3
'                 ^ reference local 3
'                     ^ reference local 3
              A = A / A
'             ^ reference local 3
'                 ^ reference local 3
'                     ^ reference local 3
              A = A \ A
'             ^ reference local 3
'                 ^ reference local 3
'                     ^ reference local 3
              A = A ^ A
'             ^ reference local 3
'                 ^ reference local 3
'                     ^ reference local 3
              A = A Mod A
'             ^ reference local 3
'                 ^ reference local 3
'                       ^ reference local 3
              A = A And A
'             ^ reference local 3
'                 ^ reference local 3
'                       ^ reference local 3
              A = A Or A
'             ^ reference local 3
'                 ^ reference local 3
'                      ^ reference local 3
              A = A Xor A
'             ^ reference local 3
'                 ^ reference local 3
'                       ^ reference local 3
              A = A << A
'             ^ reference local 3
'                 ^ reference local 3
'                      ^ reference local 3
              A = A >> A
'             ^ reference local 3
'                 ^ reference local 3
'                      ^ reference local 3
          End Sub

          Private Sub AssignmentToBinaryEqualityExpression()
'                     ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#AssignmentToBinaryEqualityExpression().
'                                                          documentation ```vb\nPrivate Sub Expressions.AssignmentToBinaryEqualityExpression()\n```
              Dim A = True
'                 ^ definition local 4
'                   documentation ```vb\nA As Boolean\n```
              Dim B = True
'                 ^ definition local 5
'                   documentation ```vb\nB As Boolean\n```
              Dim C = 42
'                 ^ definition local 6
'                   documentation ```vb\nC As Integer\n```
              Dim D = 42
'                 ^ definition local 7
'                   documentation ```vb\nD As Integer\n```
              A = A = B
'             ^ reference local 4
'                 ^ reference local 4
'                     ^ reference local 5
              A = A <> B
'             ^ reference local 4
'                 ^ reference local 4
'                      ^ reference local 5
              A = C < D
'             ^ reference local 4
'                 ^ reference local 6
'                     ^ reference local 7
              A = C <= D
'             ^ reference local 4
'                 ^ reference local 6
'                      ^ reference local 7
              A = C > D
'             ^ reference local 4
'                 ^ reference local 6
'                     ^ reference local 7
              A = C >= D
'             ^ reference local 4
'                 ^ reference local 6
'                      ^ reference local 7
          End Sub

          Private Sub AssignmentToBinaryExpression()
'                     ^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#AssignmentToBinaryExpression().
'                                                  documentation ```vb\nPrivate Sub Expressions.AssignmentToBinaryExpression()\n```
              Dim A = 42
'                 ^ definition local 8
'                   documentation ```vb\nA As Integer\n```
              A += A
'             ^ reference local 8
'                  ^ reference local 8
              A -= A
'             ^ reference local 8
'                  ^ reference local 8
              A *= A
'             ^ reference local 8
'                  ^ reference local 8
              A /= A
'             ^ reference local 8
'                  ^ reference local 8
              A \= A
'             ^ reference local 8
'                  ^ reference local 8
              A &= A
'             ^ reference local 8
'                  ^ reference local 8
              A <<= A
'             ^ reference local 8
'                   ^ reference local 8
              A >>= A
'             ^ reference local 8
'                   ^ reference local 8
              A ^= A
'             ^ reference local 8
'                  ^ reference local 8
          End Sub

          Structure Struct
'                   ^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Struct#
'                          documentation ```vb\nStructure Struct\n```
              Public [Property] As Integer
'                    ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Struct#Property.
'                               documentation ```vb\nPublic Struct.Property As Integer\n```
          End Structure

          Structure IndexedClass
'                   ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#IndexedClass#
'                                documentation ```vb\nStructure IndexedClass\n```
              Public [Property] As Integer
'                    ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#IndexedClass#Property.
'                               documentation ```vb\nPublic IndexedClass.Property As Integer\n```

              Default Public Property Item(ByVal index As Integer) As Integer
'                                     ^^^^ definition scip-dotnet nuget . . VBMain/Expressions#IndexedClass#Item.
'                                          documentation ```vb\nPublic Default Property IndexedClass.Item(index As Integer) As Integer\n```
'                                                ^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#IndexedClass#Item.(index)
'                                                      documentation ```vb\nindex As Integer\n```
                  Get
                      Return [Property]
'                            ^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#IndexedClass#Property.
                  End Get
                  Set(ByVal value As Integer)
'                           ^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#IndexedClass#set_Item().(value)
'                                 documentation ```vb\nvalue As Integer\n```
                      [Property] = value
'                     ^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#IndexedClass#Property.
'                                  ^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#IndexedClass#set_Item().(value)
                  End Set
              End Property
          End Structure

          Private Sub AssignmentToLeftValueTypes()
'                     ^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#AssignmentToLeftValueTypes().
'                                                documentation ```vb\nPrivate Sub Expressions.AssignmentToLeftValueTypes()\n```
              Dim E As (A As Integer, B As Integer) = (1, 2)
'                 ^ definition local 9
'                   documentation ```vb\nE As (A As Integer, B As Integer)\n```
              Dim A = 1
'                 ^ definition local 10
'                   documentation ```vb\nA As Integer\n```
              Dim C = New Struct With {
'                 ^ definition local 11
'                   documentation ```vb\nC As Structure Struct\n```
'                         ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Struct#
                  .[Property] = 42
'                  ^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Struct#Property.
              }
              C.[Property] = 1
'             ^ reference local 11
'               ^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Struct#Property.
              Dim D = New IndexedClass()
'                 ^ definition local 12
'                   documentation ```vb\nD As Structure IndexedClass\n```
'                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#IndexedClass#
              D(E.B) = 1
'             ^ reference local 12
'               ^ reference local 9
'                 ^ reference local 14
              Dim X = New IndexedClass With {
'                 ^ definition local 15
'                   documentation ```vb\nX As Structure IndexedClass\n```
'                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#IndexedClass#
                  .[Property] = 1
'                  ^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#IndexedClass#Property.
              }
              E.A = 1
'             ^ reference local 9
'               ^ reference local 16
          End Sub

          Private Sub TernaryExpression()
'                     ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#TernaryExpression().
'                                       documentation ```vb\nPrivate Sub Expressions.TernaryExpression()\n```
              Dim X = True
'                 ^ definition local 17
'                   documentation ```vb\nX As Boolean\n```
              Dim Y = If(X, "foo", "bar")
'                 ^ definition local 18
'                   documentation ```vb\nY As String\n```
'                        ^ reference local 17
              Dim Z As Object = True
'                 ^ definition local 19
'                   documentation ```vb\nZ As Object\n```
              Dim T = If(TypeOf Z Is Boolean, 42, 41)
'                 ^ definition local 20
'                   documentation ```vb\nT As Integer\n```
'                               ^ reference local 19
          End Sub

          Class Cast
'               ^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Cast#
'                    documentation ```vb\nClass Cast\n```
              Public Nested As Cast
'                    ^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Cast#Nested.
'                           documentation ```vb\nPublic Cast.Nested As Cast\n```
'                              ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
              Public Nested2 As Cast2
'                    ^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Cast#Nested2.
'                            documentation ```vb\nPublic Cast.Nested2 As Cast2\n```
'                               ^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#Cast2#

              Public Function Plus(ByVal other As Cast) As Cast
'                             ^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Cast#Plus().
'                                  documentation ```vb\nPublic Function Cast.Plus(other As Cast) As Cast\n```
'                                        ^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Cast#Plus().(other)
'                                              documentation ```vb\nother As Cast\n```
'                                                 ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
'                                                          ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
                  Nested = other
'                 ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#Nested.
'                          ^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#Plus().(other)
                  Return Me
              End Function

              Public Class Cast2
'                          ^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Cast#Cast2#
'                                documentation ```vb\nClass Cast2\n```
              End Class
          End Class

          Private Function CastExpressions() As Integer
'                          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#CastExpressions().
'                                          documentation ```vb\nPrivate Function Expressions.CastExpressions() As Integer\n```
              Dim A As Object = New Cast()
'                 ^ definition local 21
'                   documentation ```vb\nA As Object\n```
'                                   ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
              Dim B As Object = New Cast()
'                 ^ definition local 22
'                   documentation ```vb\nB As Object\n```
'                                   ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
              Dim C As Cast = (CType(A, Cast)).Plus(CType(B, Cast))
'                 ^ definition local 23
'                   documentation ```vb\nC As Class Cast\n```
'                      ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
'                                    ^ reference local 21
'                                       ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
'                                              ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#Plus().
'                                                         ^ reference local 22
'                                                            ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
              Dim D As Cast = CType(New Object() {A, B}(0), Cast)
'                 ^ definition local 24
'                   documentation ```vb\nD As Class Cast\n```
'                      ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
'                                                 ^ reference local 21
'                                                    ^ reference local 22
'                                                           ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
              Dim E = CType((C.Nested.Nested2), Cast.Cast2)
'                 ^ definition local 25
'                   documentation ```vb\nE As Class Cast2\n```
'                            ^ reference local 23
'                              ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#Nested.
'                                     ^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#Nested2.
'                                               ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#
'                                                    ^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Cast#Cast2#
              Dim F = CType((1), Int32)
'                 ^ definition local 26
'                   documentation ```vb\nF As Integer\n```
'                                ^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Int32#
              Dim G = CType((1), Int32)
'                 ^ definition local 27
'                   documentation ```vb\nG As Integer\n```
'                                ^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Int32#
              Dim H = CType(((1)), Int32)
'                 ^ definition local 28
'                   documentation ```vb\nH As Integer\n```
'                                  ^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Int32#
              Return F + G + H
'                    ^ reference local 26
'                        ^ reference local 27
'                            ^ reference local 28
          End Function

          Private Function AnonymousObject() As Object
'                          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#AnonymousObject().
'                                          documentation ```vb\nPrivate Function Expressions.AnonymousObject() As Object\n```
              Dim X = New With {Key .Helper = ""}
'                 ^ definition local 29
'                   documentation ```vb\nX As AnonymousType <anonymous type: Key Helper As String>\n```
'                                    ^^^^^^ reference local 31
              Dim Y = New With {X}
'                 ^ definition local 32
'                   documentation ```vb\nY As AnonymousType <anonymous type: X As AnonymousType <anonymous type: Key Helper As String>>\n```
'                               ^ reference local 29
              Return Y.x.Helper
'                    ^ reference local 32
'                      ^ reference local 34
'                        ^^^^^^ reference local 31
          End Function

          Class ObjectCreationClass
'               ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#
'                                   documentation ```vb\nClass ObjectCreationClass\n```
              Public Field As D
'                    ^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#Field.
'                          documentation ```vb\nPublic ObjectCreationClass.Field As D\n```
'                             ^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#D#

              Public Sub New(ByVal field As D)
'                        ^^^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#`.ctor`().
'                            documentation ```vb\nPublic Sub ObjectCreationClass.New(field As D)\n```
'                                  ^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#`.ctor`().(field)
'                                        documentation ```vb\nfield As D\n```
'                                           ^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#D#
                  Me.Field = field
'                    ^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#Field.
'                            ^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#`.ctor`().(field)
              End Sub

              Public Class D
'                          ^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#D#
'                            documentation ```vb\nClass D\n```
                  Public Sub New(ByVal a As Integer, ByVal b As String)
'                            ^^^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#D#`.ctor`().
'                                documentation ```vb\nPublic Sub D.New(a As Integer, b As String)\n```
'                                      ^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#D#`.ctor`().(a)
'                                        documentation ```vb\na As Integer\n```
'                                                          ^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#D#`.ctor`().(b)
'                                                            documentation ```vb\nb As String\n```
                  End Sub
              End Class
          End Class

          Private Sub ObjectCreation()
'                     ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#ObjectCreation().
'                                    documentation ```vb\nPrivate Sub Expressions.ObjectCreation()\n```
              Dim A = New ObjectCreationClass.D(1, "hi")
'                 ^ definition local 35
'                   documentation ```vb\nA As Class D\n```
'                         ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#
'                                             ^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#D#
              Dim B = New ObjectCreationClass(A) With {
'                 ^ definition local 36
'                   documentation ```vb\nB As Class ObjectCreationClass\n```
'                         ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#
'                                             ^ reference local 35
                  .Field = A
'                  ^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#Field.
'                          ^ reference local 35
              }
              B = New ObjectCreationClass(A)
'             ^ reference local 36
'                     ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#ObjectCreationClass#
'                                         ^ reference local 35
          End Sub

          Class NamedParametersClass
'               ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#
'                                    documentation ```vb\nClass NamedParametersClass\n```
              Public A As Integer
'                    ^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#A.
'                      documentation ```vb\nPublic NamedParametersClass.A As Integer\n```
              Public B As String
'                    ^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#B.
'                      documentation ```vb\nPublic NamedParametersClass.B As String\n```

              Public Sub New(ByVal a As Integer, ByVal b As String)
'                        ^^^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#`.ctor`().
'                            documentation ```vb\nPublic Sub NamedParametersClass.New(a As Integer, b As String)\n```
'                                  ^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#`.ctor`().(a)
'                                    documentation ```vb\na As Integer\n```
'                                                      ^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#`.ctor`().(b)
'                                                        documentation ```vb\nb As String\n```
                  Me.A = a
'                    ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#A.
'                        ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#`.ctor`().(a)
                  Me.B = b
'                    ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#B.
'                        ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#`.ctor`().(b)
              End Sub

              Public Sub Update(ByVal a As Integer, ByVal b As String)
'                        ^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().
'                               documentation ```vb\nPublic Sub NamedParametersClass.Update(a As Integer, b As String)\n```
'                                     ^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().(a)
'                                       documentation ```vb\na As Integer\n```
'                                                         ^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().(b)
'                                                           documentation ```vb\nb As String\n```
                  Me.A = a
'                    ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#A.
'                        ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().(a)
                  Me.B = b
'                    ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#B.
'                        ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().(b)
              End Sub
          End Class

          Private Function NamedParameters() As NamedParametersClass
'                          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#NamedParameters().
'                                          documentation ```vb\nPrivate Function Expressions.NamedParameters() As NamedParametersClass\n```
'                                               ^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#
              Dim A = New NamedParametersClass(b:="hi", a:=1)
'                 ^ definition local 37
'                   documentation ```vb\nA As Class NamedParametersClass\n```
'                         ^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#
'                                              ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#`.ctor`().(b)
'                                                       ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#`.ctor`().(a)
              A.Update(b:="foo", a:=42)
'             ^ reference local 37
'               ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().
'                      ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().(b)
'                                ^ reference scip-dotnet nuget . . VBMain/Expressions#NamedParametersClass#Update().(a)
              Return A
'                    ^ reference local 37
          End Function

          Private Function AnonymousFunction() As Func(Of Integer, Integer)
'                          ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#AnonymousFunction().
'                                            documentation ```vb\nPrivate Function Expressions.AnonymousFunction() As Func(Of Integer, Integer)\n```
              Dim d = Function(ByVal __ As Integer, ByVal ___ As Integer) 42
'                 ^ definition local 38
'                   documentation ```vb\nd As AnonymousType Function <generated method>(__ As Integer, ___ As Integer) As Integer\n```
'                                    ^^ definition local 40
'                                       documentation ```vb\n__ As Integer\n```
'                                                         ^^^ definition local 41
'                                                             documentation ```vb\n___ As Integer\n```
              Return Function(ByVal a As Integer) a + d.Invoke(a, a)
'                                   ^ definition local 43
'                                     documentation ```vb\na As Integer\n```
'                                                 ^ reference local 43
'                                                     ^ reference local 38
'                                                       ^^^^^^ reference local 45
'                                                              ^ reference local 43
'                                                                 ^ reference local 43
          End Function

          Class Lambda
'               ^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Lambda#
'                      documentation ```vb\nClass Lambda\n```
              Public Function func(ByVal x As Lambda) As String
'                             ^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Lambda#func().
'                                  documentation ```vb\nPublic Function Lambda.func(x As Lambda) As String\n```
'                                        ^ definition scip-dotnet nuget . . VBMain/Expressions#Lambda#func().(x)
'                                          documentation ```vb\nx As Lambda\n```
'                                             ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Lambda#
                  Return ""
              End Function
          End Class

          Private Sub LambdaExpressions()
'                     ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#LambdaExpressions().
'                                       documentation ```vb\nPrivate Sub Expressions.LambdaExpressions()\n```
              Dim a = Function(ByVal x As String) x & 1
'                 ^ definition local 46
'                   documentation ```vb\na As AnonymousType Function <generated method>(x As String) As String\n```
'                                    ^ definition local 48
'                                      documentation ```vb\nx As String\n```
'                                                 ^ reference local 48
              Dim b = Function(ByVal aa As Lambda, ByVal bb As Lambda) aa.func(bb)
'                 ^ definition local 49
'                   documentation ```vb\nb As AnonymousType Function <generated method>(aa As Lambda, bb As Lambda) As String\n```
'                                    ^^ definition local 51
'                                       documentation ```vb\naa As Lambda\n```
'                                          ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Lambda#
'                                                        ^^ definition local 52
'                                                           documentation ```vb\nbb As Lambda\n```
'                                                              ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Lambda#
'                                                                      ^^ reference local 51
'                                                                         ^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Lambda#func().
'                                                                              ^^ reference local 52
              Dim c = Function(aaa As Lambda, __ As Lambda)
'                 ^ definition local 53
'                   documentation ```vb\nc As AnonymousType Function <generated method>(aaa As Lambda, __ As Lambda) As String\n```
'                              ^^^ definition local 55
'                                  documentation ```vb\naaa As Lambda\n```
'                                     ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Lambda#
'                                             ^^ definition local 56
'                                                documentation ```vb\n__ As Lambda\n```
'                                                   ^^^^^^ reference scip-dotnet nuget . . VBMain/Expressions#Lambda#
                          If True Then
                              Return "hi"
                          End If
                      End Function
          End Sub

          Private Sub TupleExpression()
'                     ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#TupleExpression().
'                                     documentation ```vb\nPrivate Sub Expressions.TupleExpression()\n```
              Dim A = (1, 2, "")
'                 ^ definition local 57
'                   documentation ```vb\nA As (Integer, Integer, String)\n```
          End Sub

          Private Sub ArrayCreation()
'                     ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#ArrayCreation().
'                                   documentation ```vb\nPrivate Sub Expressions.ArrayCreation()\n```
              Dim a = {
'                 ^ definition local 58
'                   documentation ```vb\na As Integer(*,*)\n```
              {1, 1},
              {2, 2},
              {3, 3}}
              Dim d = New Integer(2) {1, 2, 3}
'                 ^ definition local 59
'                   documentation ```vb\nd As Integer()\n```
              Dim e = New Byte(,) {
'                 ^ definition local 60
'                   documentation ```vb\ne As Byte(*,*)\n```
              {1, 2},
              {2, 3}}
              Dim f = New Integer(2, 1) {
'                 ^ definition local 61
'                   documentation ```vb\nf As Integer(*,*)\n```
              {1, 1},
              {2, 2},
              {3, 3}}

              Dim numbers(4) As Integer
'                 ^^^^^^^ definition local 62
'                         documentation ```vb\nnumbers As Integer()\n```
              Dim numbers2 = New Integer() {1, 2, 4, 8}
'                 ^^^^^^^^ definition local 63
'                          documentation ```vb\nnumbers2 As Integer()\n```
              ReDim Preserve numbers(15)
'                            ^^^^^^^ reference local 62
              ReDim numbers(15)
'                   ^^^^^^^ reference local 62
              Dim matrix(5, 5) As Double
'                 ^^^^^^ definition local 64
'                        documentation ```vb\nmatrix As Double(*,*)\n```
              Dim matrix2 = New Integer(,) {{1, 2, 3}, {2, 3, 4}, {3, 4, 5}, {4, 5, 6}}
'                 ^^^^^^^ definition local 65
'                         documentation ```vb\nmatrix2 As Integer(*,*)\n```
              Dim sales()() As Double = New Double(11)() {}
'                 ^^^^^ definition local 66
'                       documentation ```vb\nsales As Double()()\n```
          End Sub

          Private Sub [TypeOf]()
'                     ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#TypeOf().
'                              documentation ```vb\nPrivate Sub Expressions.TypeOf()\n```
              Dim a = GetType(Integer)
'                 ^ definition local 67
'                   documentation ```vb\na As Class Type\n```
              Dim b = GetType(List(Of String).Enumerator)
'                 ^ definition local 68
'                   documentation ```vb\nb As Class Type\n```
'                                             ^^^^^^^^^^ reference scip-dotnet nuget System.Collections 9.0.0.0 Generic/List#Enumerator#
              Dim c = GetType(Dictionary(Of,))
'                 ^ definition local 69
'                   documentation ```vb\nc As Class Type\n```
              Dim d = GetType(Tuple(Of,,,))
'                 ^ definition local 70
'                   documentation ```vb\nd As Class Type\n```
          End Sub

          Private Sub SelectCase()
'                     ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#SelectCase().
'                                documentation ```vb\nPrivate Sub Expressions.SelectCase()\n```
              Dim Some = 42
'                 ^^^^ definition local 71
'                      documentation ```vb\nSome As Integer\n```
              Select Case Some
'                         ^^^^ reference local 71
                  Case 1
                      Debug.WriteLine("One")
'                     ^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 Diagnostics/Debug#
'                           ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 Diagnostics/Debug#WriteLine(+2).
                  Case 2
                      Debug.WriteLine("One")
'                     ^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 Diagnostics/Debug#
'                           ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 Diagnostics/Debug#WriteLine(+2).
                  Case Else
                      Debug.WriteLine("More")
'                     ^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 Diagnostics/Debug#
'                           ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 Diagnostics/Debug#WriteLine(+2).
              End Select
          End Sub

          Private Sub Dictionary()
'                     ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Expressions#Dictionary().
'                                documentation ```vb\nPrivate Sub Expressions.Dictionary()\n```
              Dim A = New Dictionary(Of String, Integer) From {{1, "Test1"}, {2, "Test1"}}
'                 ^ definition local 72
'                   documentation ```vb\nA As Class Dictionary(Of String, Integer)\n```
          End Sub

      End Class
  End Namespace

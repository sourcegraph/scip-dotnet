  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Classes
'                  ^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#
'                          documentation ```vb\nClass Classes\n```

          Public Name As String
'                ^^^^ definition scip-dotnet nuget . . VBMain/Classes#Name.
'                     documentation ```vb\nPublic Classes.Name As String\n```
          Public Const IntConstant As Integer = 1
'                      ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#IntConstant.
'                                  documentation ```vb\nPublic Const Classes.IntConstant As Integer = 1\n```
          Public Const StringConstant As String = "hello"
'                      ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#StringConstant.
'                                     documentation ```vb\nPublic Const Classes.StringConstant As String = "hello"\n```

          Public Sub New(ByVal name As Integer)
'                    ^^^ definition scip-dotnet nuget . . VBMain/Classes#`.ctor`().
'                        documentation ```vb\nPublic Sub Classes.New(name As Integer)\n```
'                              ^^^^ definition scip-dotnet nuget . . VBMain/Classes#`.ctor`().(name)
'                                   documentation ```vb\nname As Integer\n```
              Me.Name = "name"
'                ^^^^ reference scip-dotnet nuget . . VBMain/Classes#Name.
          End Sub

          Public Sub New(ByVal name As String)
'                    ^^^ definition scip-dotnet nuget . . VBMain/Classes#`.ctor`(+1).
'                        documentation ```vb\nPublic Sub Classes.New(name As String)\n```
'                              ^^^^ definition scip-dotnet nuget . . VBMain/Classes#`.ctor`(+1).(name)
'                                   documentation ```vb\nname As String\n```
              Me.Name = name
'                ^^^^ reference scip-dotnet nuget . . VBMain/Classes#Name.
'                       ^^^^ reference scip-dotnet nuget . . VBMain/Classes#`.ctor`(+1).(name)
          End Sub

          Protected Overrides Sub Finalize()
'                                 ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#Finalize().
'                                          documentation ```vb\nProtected Overrides Sub Classes.Finalize()\n```
'                                          relationship implementation reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#Finalize().
              Console.WriteLine(42)
'             ^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#
'                     ^^^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#WriteLine(+7).
          End Sub

          Public Class ObjectClass
'                      ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#ObjectClass#
'                                  documentation ```vb\nClass ObjectClass\n```
'                                  relationship implementation scip-dotnet nuget . . VBMain/Classes#SomeInterface#
              Inherits Object
              Implements SomeInterface
'                        ^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Classes#SomeInterface#
          End Class

          Public Partial Class PartialClass
'                              ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#PartialClass#
'                                           documentation ```vb\nClass PartialClass\n```
          End Class

          Class TypeParameterClass(Of T)
'               ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#TypeParameterClass#
'                                  documentation ```vb\nClass TypeParameterClass(Of T)\n```
'                                     ^ definition local 0
'                                       documentation ```vb\nT\n```
          End Class

          Friend Class InternalMultipleTypeParametersClass(Of T1, T2)
'                      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#InternalMultipleTypeParametersClass#
'                                                          documentation ```vb\nClass InternalMultipleTypeParametersClass(Of T1, T2)\n```
'                                                             ^^ definition local 1
'                                                                documentation ```vb\nT1\n```
'                                                                 ^^ definition local 2
'                                                                    documentation ```vb\nT2\n```
          End Class

          Interface ICovariantContravariant(Of In T1, Out T2)
'                   ^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#ICovariantContravariant#
'                                           documentation ```vb\nInterface ICovariantContravariant(Of In T1, Out T2)\n```
'                                                 ^^ definition local 3
'                                                    documentation ```vb\nIn T1\n```
'                                                         ^^ definition local 4
'                                                            documentation ```vb\nOut T2\n```
              Sub Method1(ByVal t1 As T1)
'                 ^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#ICovariantContravariant#Method1().
'                         documentation ```vb\nSub ICovariantContravariant(Of In T1, Out T2).Method1(t1 As T1)\n```
'                               ^^ definition scip-dotnet nuget . . VBMain/Classes#ICovariantContravariant#Method1().(t1)
'                                  documentation ```vb\nt1 As T1\n```
'                                     ^^ reference local 3

              Function Method2() As T2
'                      ^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#ICovariantContravariant#Method2().
'                              documentation ```vb\nFunction ICovariantContravariant(Of In T1, Out T2).Method2() As T2\n```
'                                   ^^ reference local 4

          End Interface

          Public Class StructConstraintClass(Of T As Structure)
'                      ^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#StructConstraintClass#
'                                            documentation ```vb\nClass StructConstraintClass(Of T As Structure)\n```
'                                               ^ definition local 5
'                                                 documentation ```vb\nT\n```
          End Class

          Public Class ClassConstraintClass(Of T As Class)
'                      ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#ClassConstraintClass#
'                                           documentation ```vb\nClass ClassConstraintClass(Of T As Class)\n```
'                                              ^ definition local 6
'                                                documentation ```vb\nT\n```
          End Class

          Public Class NewConstraintClass(Of T As New)
'                      ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#NewConstraintClass#
'                                         documentation ```vb\nClass NewConstraintClass(Of T As New)\n```
'                                            ^ definition local 7
'                                              documentation ```vb\nT\n```
          End Class

          Public Class TypeParameterConstraintClass(Of T As SomeInterface)
'                      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#TypeParameterConstraintClass#
'                                                   documentation ```vb\nClass TypeParameterConstraintClass(Of T As SomeInterface)\n```
'                                                      ^ definition local 8
'                                                        documentation ```vb\nT\n```
'                                                           ^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Classes#SomeInterface#
          End Class

          Private Class MultipleTypeParameterConstraintsClass(Of T1 As {SomeInterface, SomeInterface2, New}, T2 As SomeInterface2)
'                       ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#MultipleTypeParameterConstraintsClass#
'                                                             documentation ```vb\nClass MultipleTypeParameterConstraintsClass(Of T1 As {SomeInterface, SomeInterface2, New}, T2 As SomeInterface2)\n```
'                                                                ^^ definition local 9
'                                                                   documentation ```vb\nT1\n```
'                                                                       ^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Classes#SomeInterface#
'                                                                                      ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Classes#SomeInterface2#
'                                                                                                            ^^ definition local 10
'                                                                                                               documentation ```vb\nT2\n```
'                                                                                                                  ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Classes#SomeInterface2#
          End Class

          Class IndexClass
'               ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#IndexClass#
'                          documentation ```vb\nClass IndexClass\n```
              Private a As Boolean
'                     ^ definition scip-dotnet nuget . . VBMain/Classes#IndexClass#a.
'                       documentation ```vb\nPrivate IndexClass.a As Boolean\n```

              Default Public Property Item(ByVal index As Integer) As Boolean
'                                     ^^^^ definition scip-dotnet nuget . . VBMain/Classes#IndexClass#Item.
'                                          documentation ```vb\nPublic Default Property IndexClass.Item(index As Integer) As Boolean\n```
'                                                ^^^^^ definition scip-dotnet nuget . . VBMain/Classes#IndexClass#Item.(index)
'                                                      documentation ```vb\nindex As Integer\n```
                  Get
                      Return a
'                            ^ reference scip-dotnet nuget . . VBMain/Classes#IndexClass#a.
                  End Get
                  Set(ByVal value As Boolean)
'                           ^^^^^ definition scip-dotnet nuget . . VBMain/Classes#IndexClass#set_Item().(value)
'                                 documentation ```vb\nvalue As Boolean\n```
                      a = value
'                     ^ reference scip-dotnet nuget . . VBMain/Classes#IndexClass#a.
'                         ^^^^^ reference scip-dotnet nuget . . VBMain/Classes#IndexClass#set_Item().(value)
                  End Set
              End Property
          End Class

          Interface SomeInterface
'                   ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#SomeInterface#
'                                 documentation ```vb\nInterface SomeInterface\n```
          End Interface

          Friend Interface SomeInterface2
'                          ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Classes#SomeInterface2#
'                                         documentation ```vb\nInterface SomeInterface2\n```
          End Interface

      End Class

  End Namespace

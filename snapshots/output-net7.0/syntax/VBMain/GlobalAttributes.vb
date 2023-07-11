  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True, Inherited:=True)>
'      ^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeUsageAttribute#`.ctor`().
'                     ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeTargets#
'                                      ^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeTargets#Class.
'                                               ^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeUsageAttribute#AllowMultiple.
'                                                                    ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeUsageAttribute#Inherited.
      Public Class GlobalAttributes
'                  ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#
'                                   documentation ```vb\nClass GlobalAttributes\n```
'                                   relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
          Inherits Attribute
'                  ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#

          Class AuthorAttribute
'               ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#
'                               documentation ```vb\nClass AuthorAttribute\n```
'                               relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
              Inherits Attribute
'                      ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#

              Public Sub New(ByVal name As String)
'                        ^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().
'                            documentation ```vb\nPublic Sub AuthorAttribute.New(name As String)\n```
'                                  ^^^^ definition local 0
'                                       documentation ```vb\nname As String\n```
              End Sub
          End Class

          <Author("PropertyAttribute")>
'          ^^^^^^ reference scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().
          Public Z As Integer
'                ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#Z.
'                  documentation ```vb\nPublic GlobalAttributes.Z As Integer\n```

          <Author("MethodAttribute")>
'          ^^^^^^ reference scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().
          Private Function Method1() As Integer
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#Method1().
'                                  documentation ```vb\nPrivate Function GlobalAttributes.Method1() As Integer\n```
              Return 0
          End Function

          <Author("EnumAttribute")>
'          ^^^^^^ reference scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().
          Enum A
'              ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#A#
'                documentation ```vb\nEnum A\n```
'                relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IComparable#
'                relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IConvertible#
'                relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IFormattable#
              B
'             ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#A#B.
'               documentation ```vb\nA.B = 0\n```
              C
'             ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#A#C.
'               documentation ```vb\nA.C = 1\n```
          End Enum

          <Author("EventAttribute")>
'          ^^^^^^ reference scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().
          Public Event SomeEvent As EventHandler
'                      ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#SomeEvent#
'                                documentation ```vb\nPublic Event GlobalAttributes.SomeEvent As EventHandler\n```
'                                   ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#

          <Author("TypeParameterAttribute")>
'          ^^^^^^ reference scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().
          Public Class InnerClass(Of T)
'                      ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#InnerClass#
'                                 documentation ```vb\nClass InnerClass(Of T)\n```
'                                    ^ definition local 1
'                                      documentation ```vb\nT\n```
              Private Sub Method(Of T2)()
'                         ^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#InnerClass#Method().
'                                documentation ```vb\nPrivate Sub InnerClass(Of T).Method(Of T2)()\n```
'                                   ^^ definition local 2
'                                      documentation ```vb\nT2\n```
              End Sub
          End Class
      End Class
  End Namespace

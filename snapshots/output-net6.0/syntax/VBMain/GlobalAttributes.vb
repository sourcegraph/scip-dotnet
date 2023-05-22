  Imports System.Diagnostics.CodeAnalysis

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True, Inherited:=True)>
      Public Class GlobalAttributes
'                  ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#
'                                   documentation ```vb\nClass GlobalAttributes\n```
'                                   relationship implementation Attribute#
          Inherits Attribute

          Class AuthorAttribute
'               ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#
'                               documentation ```vb\nClass AuthorAttribute\n```
'                               relationship implementation Attribute#
              Inherits Attribute

              Public Sub New(ByVal name As String)
'                        ^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().
'                            documentation ```vb\nPublic Sub AuthorAttribute.New(name As String)\n```
'                                  ^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#AuthorAttribute#`.ctor`().(name)
'                                       documentation ```vb\nname As String\n```
              End Sub
          End Class

          <Author("PropertyAttribute")>
          Public Z As Integer
'                ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#Z.
'                  documentation ```vb\nPublic GlobalAttributes.Z As Integer\n```

          <Author("MethodAttribute")>
          Private Function Method1() As Integer
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#Method1().
'                                  documentation ```vb\nPrivate Function GlobalAttributes.Method1() As Integer\n```
              Return 0
          End Function

          <Author("EnumAttribute")>
          Enum A
'              ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#A#
'                documentation ```vb\nEnum A\n```
              B
'             ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#A#B.
'               documentation ```vb\nA.B = 0\n```
              C
'             ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#A#C.
'               documentation ```vb\nA.C = 1\n```
          End Enum

          <Author("EventAttribute")>
          Public Event SomeEvent As EventHandler
'                      ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#SomeEvent#
'                                documentation ```vb\nPublic Event GlobalAttributes.SomeEvent As EventHandler\n```

          <Author("TypeParameterAttribute")>
          Public Class InnerClass(Of T)
'                      ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#InnerClass#
'                                 documentation ```vb\nClass InnerClass(Of T)\n```
'                                    ^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#InnerClass#[T]
'                                      documentation ```vb\nT\n```
              Private Sub Method(Of T2)()
'                         ^^^^^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#InnerClass#Method().
'                                documentation ```vb\nPrivate Sub InnerClass(Of T).Method(Of T2)()\n```
'                                   ^^ definition scip-dotnet nuget . . VBMain/GlobalAttributes#InnerClass#Method().[T2]
'                                      documentation ```vb\nT2\n```
              End Sub
          End Class
      End Class
  End Namespace

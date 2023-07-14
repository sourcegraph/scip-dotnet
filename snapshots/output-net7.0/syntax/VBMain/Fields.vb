  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Fields
'                  ^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#
'                         documentation ```vb\nClass Fields\n```
          Class Fields1
'               ^^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#
'                       documentation ```vb\nClass Fields1\n```
              Private ReadOnly Property1 As Integer
'                              ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#Property1.
'                                        documentation ```vb\nPrivate ReadOnly Fields1.Property1 As Integer\n```
              Private Property2, Property3 As Int64
'                     ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#Property2.
'                               documentation ```vb\nPrivate Fields1.Property2 As Long\n```
'                                ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#Property3.
'                                          documentation ```vb\nPrivate Fields1.Property3 As Long\n```
'                                             ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int64#
              Private Property4 As Tuple(Of Char, Nullable(Of Integer))
'                     ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#Property4.
'                               documentation ```vb\nPrivate Fields1.Property4 As Tuple(Of Char, Integer?)\n```

              Public Sub New(ByVal field2 As Long, ByVal field3 As Long, ByVal field4 As Tuple(Of Char, Integer?), ByVal field1 As Integer)
'                        ^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().
'                            documentation ```vb\nPublic Sub Fields1.New(field2 As Long, field3 As Long, field4 As Tuple(Of Char, Integer?), field1 As Integer)\n```
'                                  ^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field2)
'                                         documentation ```vb\nfield2 As Long\n```
'                                                        ^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field3)
'                                                               documentation ```vb\nfield3 As Long\n```
'                                                                              ^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field4)
'                                                                                     documentation ```vb\nfield4 As Tuple(Of Char, Integer?)\n```
'                                                                                                                        ^^^^^^ definition scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field1)
'                                                                                                                               documentation ```vb\nfield1 As Integer\n```
                  Property2 = field2
'                 ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#Property2.
'                             ^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field2)
                  Property3 = field3
'                 ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#Property3.
'                             ^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field3)
                  Property4 = field4
'                 ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#Property4.
'                             ^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field4)
                  Property1 = field1
'                 ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#Property1.
'                             ^^^^^^ reference scip-dotnet nuget . . VBMain/Fields#Fields1#`.ctor`().(field1)
              End Sub
          End Class
      End Class
  End Namespace

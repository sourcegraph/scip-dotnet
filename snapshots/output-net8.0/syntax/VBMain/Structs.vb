  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 8.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Structs
'                  ^^^^^^^ definition scip-dotnet nuget . . VBMain/Structs#
'                          documentation ```vb\nClass Structs\n```
          Structure BasicStruct
'                   ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Structs#BasicStruct#
'                               documentation ```vb\nStructure BasicStruct\n```
              Public Property1 As Integer
'                    ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Structs#BasicStruct#Property1.
'                              documentation ```vb\nPublic BasicStruct.Property1 As Integer\n```

              Public Sub New(ByVal field1 As Integer)
'                        ^^^ definition scip-dotnet nuget . . VBMain/Structs#BasicStruct#`.ctor`(+1).
'                            documentation ```vb\nPublic Sub BasicStruct.New(field1 As Integer)\n```
'                                  ^^^^^^ definition scip-dotnet nuget . . VBMain/Structs#BasicStruct#`.ctor`(+1).(field1)
'                                         documentation ```vb\nfield1 As Integer\n```
                  Property1 = field1
'                 ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Structs#BasicStruct#Property1.
'                             ^^^^^^ reference scip-dotnet nuget . . VBMain/Structs#BasicStruct#`.ctor`(+1).(field1)
              End Sub
          End Structure
      End Class
  End Namespace

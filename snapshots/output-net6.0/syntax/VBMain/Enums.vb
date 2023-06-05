  Imports System.Diagnostics.CodeAnalysis

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Class Enums
'                  ^^^^^ definition scip-dotnet nuget . . VBMain/Enums#
'                        documentation ```vb\nClass Enums\n```
          Enum EnumWithIntValues
'              ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Enums#EnumWithIntValues#
'                                documentation ```vb\nEnum EnumWithIntValues\n```
              Ten = 10
'             ^^^ definition scip-dotnet nuget . . VBMain/Enums#EnumWithIntValues#Ten.
'                 documentation ```vb\nEnumWithIntValues.Ten = 10\n```
              Twenty = 20
'             ^^^^^^ definition scip-dotnet nuget . . VBMain/Enums#EnumWithIntValues#Twenty.
'                    documentation ```vb\nEnumWithIntValues.Twenty = 20\n```
          End Enum

          Enum EnumWithByteValues
'              ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Enums#EnumWithByteValues#
'                                 documentation ```vb\nEnum EnumWithByteValues\n```
              Five = &H5
'             ^^^^ definition scip-dotnet nuget . . VBMain/Enums#EnumWithByteValues#Five.
'                  documentation ```vb\nEnumWithByteValues.Five = 5\n```
              Fifteen = &HF
'             ^^^^^^^ definition scip-dotnet nuget . . VBMain/Enums#EnumWithByteValues#Fifteen.
'                     documentation ```vb\nEnumWithByteValues.Fifteen = 15\n```
          End Enum
      End Class
  End Namespace

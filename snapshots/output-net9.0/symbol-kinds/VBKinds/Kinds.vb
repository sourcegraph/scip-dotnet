  Namespace SymbolKinds
'           ^^^^^^^^^^^ reference scip-dotnet nuget . . SymbolKinds/
      Public Class VBClass
'                  ^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/VBClass#
'                          documentation ```vb\nClass VBClass\n```
      End Class

      Public Module VBModule
'                   ^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/VBModule#
'                            documentation ```vb\nModule VBModule\n```
          Public Sub ModuleMethod()
'                    ^^^^^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/VBModule#ModuleMethod().
'                                 documentation ```vb\nPublic Sub VBModule.ModuleMethod()\n```
              Dim marker = "🚀" : ModuleMethod()
'                 ^^^^^^ definition local 0
'                        documentation ```vb\nmarker As String\n```
'                                 ^^^^^^^^^^^^ reference scip-dotnet nuget . . SymbolKinds/VBModule#ModuleMethod().
          End Sub
      End Module
  End Namespace

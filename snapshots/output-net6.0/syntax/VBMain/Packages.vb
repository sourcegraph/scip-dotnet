  Imports System.Diagnostics.CodeAnalysis
  Imports DiffPlex.DiffBuilder
'         ^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffPlex/
'                  ^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffBuilder/
  Imports DiffPlex.DiffBuilder.Model
'         ^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffPlex/
'                  ^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffBuilder/
'                              ^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 Model/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Class Packages
'                  ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Packages#
'                           documentation ```vb\nClass Packages\n```
          Private Function Diff() As DiffPaneModel
'                          ^^^^ definition scip-dotnet nuget . . VBMain/Packages#Diff().
'                               documentation ```vb\nPrivate Function Packages.Diff() As DiffPaneModel\n```
'                                    ^^^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 Model/DiffPaneModel#
              Return InlineDiffBuilder.Diff("a", "b")
'                    ^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffBuilder/InlineDiffBuilder#
          End Function
      End Class
  End Namespace

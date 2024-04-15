  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  using DiffPlex.DiffBuilder;
//      ^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffPlex/
//               ^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffBuilder/
  using DiffPlex.DiffBuilder.Model;
//      ^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffPlex/
//               ^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffBuilder/
//                           ^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 Model/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 8.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Packages
//             ^^^^^^^^ definition scip-dotnet nuget . . Main/Packages#
//                      documentation ```cs\nclass Packages\n```
  {
      DiffPaneModel Diff()
//    ^^^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 Model/DiffPaneModel#
//                  ^^^^ definition scip-dotnet nuget . . Main/Packages#Diff().
//                       documentation ```cs\nprivate DiffPaneModel Packages.Diff()\n```
      {
          return InlineDiffBuilder.Diff("a", "b");
//               ^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffBuilder/InlineDiffBuilder#
//                                 ^^^^ reference scip-dotnet nuget DiffPlex 1.7.1.0 DiffBuilder/InlineDiffBuilder#Diff().
      }
  }

  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Properties
//             ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Properties#
//                        documentation ```cs\nclass Properties\n```
  {
      byte Get { get; }
//         ^^^ definition scip-dotnet nuget . . Main/Properties#Get.
//             documentation ```cs\nprivate byte Properties.Get { get; }\n```

      char Set
//         ^^^ definition scip-dotnet nuget . . Main/Properties#Set.
//             documentation ```cs\nprivate char Properties.Set { set; }\n```
      {
          set { throw new NotImplementedException(); }
//                        ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/NotImplementedException#
      }

      uint GetSet { get; set; }
//         ^^^^^^ definition scip-dotnet nuget . . Main/Properties#GetSet.
//                documentation ```cs\nprivate uint Properties.GetSet { get; set; }\n```
      long SetGet { set; get; }
//         ^^^^^^ definition scip-dotnet nuget . . Main/Properties#SetGet.
//                documentation ```cs\nprivate long Properties.SetGet { get; set; }\n```

      string? Init { get; init; }
//            ^^^^ definition scip-dotnet nuget . . Main/Properties#Init.
//                 documentation ```cs\nprivate string? Properties.Init { get; init; }\n```
  }

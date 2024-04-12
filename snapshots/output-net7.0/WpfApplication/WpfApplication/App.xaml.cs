  using System.Windows;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^ reference scip-dotnet nuget . . Windows/

  namespace WpfApplication
//          ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . WpfApplication/
  {
      public partial class App : Application
//                         ^^^ definition scip-dotnet nuget . . WpfApplication/App#
//                             documentation ```cs\nclass App\n```
//                             relationship implementation scip-dotnet nuget . . ``/Application#
      {
      }
  }

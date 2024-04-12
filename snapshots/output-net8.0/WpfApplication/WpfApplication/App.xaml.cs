  using System.Windows;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^ reference scip-dotnet nuget . . Windows/

  namespace WpfApplication
//          ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . WpfApplication/
  {
      public partial class App : Application
//                         ^^^ definition scip-dotnet nuget . . WpfApplication/App#
//                             documentation ```cs\nclass App\n```
//                             relationship implementation scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/Application#
//                             relationship implementation scip-dotnet nuget WindowsBase 7.0.0.0 Threading/DispatcherObject#
//                             relationship implementation scip-dotnet nuget System.Xaml 7.0.0.0 Markup/IQueryAmbient#
//                               ^^^^^^^^^^^ reference scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/Application#
      {
      }
  }

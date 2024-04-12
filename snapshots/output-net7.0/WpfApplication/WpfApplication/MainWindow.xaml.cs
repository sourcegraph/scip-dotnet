  using System.Windows;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^ reference scip-dotnet nuget . . Windows/

  namespace WpfApplication
//          ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . WpfApplication/
  {
      public partial class MainWindow : Window
//                         ^^^^^^^^^^ definition scip-dotnet nuget . . WpfApplication/MainWindow#
//                                    documentation ```cs\nclass MainWindow\n```
//                                    relationship implementation scip-dotnet nuget . . ``/Window#
      {
          public MainWindow()
//               ^^^^^^^^^^ definition scip-dotnet nuget . . WpfApplication/MainWindow#`.ctor`().
//                          documentation ```cs\npublic MainWindow.MainWindow()\n```
          {
              InitializeComponent();
          }
      }
  }

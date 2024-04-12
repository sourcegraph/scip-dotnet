  using System.Windows;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^ reference scip-dotnet nuget . . Windows/

  namespace WpfApplication
//          ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . WpfApplication/
  {
      public partial class MainWindow : Window
//                         ^^^^^^^^^^ definition scip-dotnet nuget . . WpfApplication/MainWindow#
//                                    documentation ```cs\nclass MainWindow\n```
//                                    relationship implementation scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/Window#
//                                    relationship implementation scip-dotnet nuget PresentationFramework 7.0.0.0 Controls/ContentControl#
//                                    relationship implementation scip-dotnet nuget PresentationFramework 7.0.0.0 Controls/Control#
//                                    relationship implementation scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/FrameworkElement#
//                                    relationship implementation scip-dotnet nuget PresentationCore 7.0.0.0 Windows/UIElement#
//                                    relationship implementation scip-dotnet nuget PresentationCore 7.0.0.0 Media/Visual#
//                                    relationship implementation scip-dotnet nuget WindowsBase 7.0.0.0 Windows/DependencyObject#
//                                    relationship implementation scip-dotnet nuget WindowsBase 7.0.0.0 Threading/DispatcherObject#
//                                    relationship implementation scip-dotnet nuget PresentationCore 7.0.0.0 Animation/IAnimatable#
//                                    relationship implementation scip-dotnet nuget System.ComponentModel.Primitives 7.0.0.0 ComponentModel/ISupportInitialize#
//                                    relationship implementation scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/IFrameworkInputElement#
//                                    relationship implementation scip-dotnet nuget PresentationCore 7.0.0.0 Windows/IInputElement#
//                                    relationship implementation scip-dotnet nuget System.Xaml 7.0.0.0 Markup/IQueryAmbient#
//                                    relationship implementation scip-dotnet nuget PresentationCore 7.0.0.0 Markup/IAddChild#
//                                      ^^^^^^ reference scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/Window#
      {
          public MainWindow()
//               ^^^^^^^^^^ definition scip-dotnet nuget . . WpfApplication/MainWindow#`.ctor`().
//                          documentation ```cs\npublic MainWindow.MainWindow()\n```
          {
              InitializeComponent();
          }
      }
  }

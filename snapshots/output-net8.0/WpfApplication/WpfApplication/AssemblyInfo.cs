  using System.Windows;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^ reference scip-dotnet nuget . . Windows/

  [assembly: ThemeInfo(
//           ^^^^^^^^^ reference scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/ThemeInfoAttribute#`.ctor`().
      ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/ResourceDictionaryLocation#
//                               ^^^^ reference scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/ResourceDictionaryLocation#None.
                                       //(used if a resource is not found in the page,
                                       // or application resource dictionaries)
      ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/ResourceDictionaryLocation#
//                               ^^^^^^^^^^^^^^ reference scip-dotnet nuget PresentationFramework 7.0.0.0 Windows/ResourceDictionaryLocation#SourceAssembly.
                                                //(used if a resource is not found in the page,
                                                // app, or any theme specific resource dictionaries)
  )]

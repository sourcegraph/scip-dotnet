  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 8.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Preprocessors
//             ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Preprocessors#
//                           documentation ```cs\nclass Preprocessors\n```
  {
      string OS()
//           ^^ definition scip-dotnet nuget . . Main/Preprocessors#OS().
//              documentation ```cs\nprivate string Preprocessors.OS()\n```
      {
  #if WIN32
          string os = "Win32";
  #warning This class is bad.
  #error Okay, just stop.
  #elif MACOS
          string os = "MacOS";
  #else
          string os = "Unknown";
//               ^^ definition local 0
//                  documentation ```cs\nstring os\n```
  #endif
          return os;
//               ^^ reference local 0
      }
  }

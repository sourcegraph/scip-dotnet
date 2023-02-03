  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  public class Preprocessors
//             ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Preprocessors#
//                           documentation ```cs\nclass Main.Preprocessors\n```
//                           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
  {
      string OS()
//           ^^ definition scip-dotnet nuget . . Main/Preprocessors#OS().
//              documentation ```cs\nprivate System.String Main.Preprocessors.OS()\n```
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
//                  documentation ```cs\nSystem.String os\n```
  #endif
          return os;
//               ^^ reference local 0
      }
  }

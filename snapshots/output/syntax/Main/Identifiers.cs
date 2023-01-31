  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  #pragma warning disable CS0219
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Identifiers
//             ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Identifiers#
//                         documentation ```cs\nclass Main.Identifiers\n```
//                         relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
  {
      void SpecialNames()
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Identifiers#SpecialNames().
//                      documentation ```cs\nprivate void Main.Identifiers.SpecialNames()\n```
      {
          var @const = 42;
//            ^^^^^^ definition local 0
//                   documentation ```cs\nSystem.Int32 const\n```
          int @var = @const;
//            ^^^^ definition local 1
//                 documentation ```cs\nSystem.Int32 var\n```
//                   ^^^^^^ reference local 0
          var under_score = 0;
//            ^^^^^^^^^^^ definition local 2
//                        documentation ```cs\nSystem.Int32 under_score\n```
          var with1number = 0;
//            ^^^^^^^^^^^ definition local 3
//                        documentation ```cs\nSystem.Int32 with1number\n```
          var varæble = 0;
//            ^^^^^^^ definition local 4
//                    documentation ```cs\nSystem.Int32 varæble\n```
          var Переменная = 0;
//            ^^^^^^^^^^ definition local 5
//                       documentation ```cs\nSystem.Int32 Переменная\n```
          var first‿letter = 0;
//            ^^^^^^^^^^^^ definition local 6
//                         documentation ```cs\nSystem.Int32 first‿letter\n```
          var ග්‍රහලෝකය = 0;
//            ^^^^^^^^^ definition local 7
//                      documentation ```cs\nSystem.Int32 ග්රහලෝකය\n```
          var _كوكبxxx = 0;
//            ^^^^^^^^ definition local 8
//                     documentation ```cs\nSystem.Int32 _كوكبxxx\n```
      }
  }
  #pragma warning restore CS0219

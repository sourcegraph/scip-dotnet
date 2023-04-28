  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  #pragma warning disable CS0219
  [SuppressMessage("ReSharper", "all")]
  public class Identifiers
//             ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Identifiers#
//                         documentation ```cs\nclass Identifiers\n```
  {
      void SpecialNames()
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Identifiers#SpecialNames().
//                      documentation ```cs\nprivate void Identifiers.SpecialNames()\n```
      {
          var @const = 42;
//            ^^^^^^ definition local 0
//                   documentation ```cs\nint? @const\n```
          int @var = @const;
//            ^^^^ definition local 1
//                 documentation ```cs\nint var\n```
//                   ^^^^^^ reference local 0
          var under_score = 0;
//            ^^^^^^^^^^^ definition local 2
//                        documentation ```cs\nint? under_score\n```
          var with1number = 0;
//            ^^^^^^^^^^^ definition local 3
//                        documentation ```cs\nint? with1number\n```
          var varæble = 0;
//            ^^^^^^^ definition local 4
//                    documentation ```cs\nint? varæble\n```
          var Переменная = 0;
//            ^^^^^^^^^^ definition local 5
//                       documentation ```cs\nint? Переменная\n```
          var first‿letter = 0;
//            ^^^^^^^^^^^^ definition local 6
//                         documentation ```cs\nint? first‿letter\n```
          var ග්‍රහලෝකය = 0;
//            ^^^^^^^^^ definition local 7
//                      documentation ```cs\nint? ග්රහලෝකය\n```
          var _كوكبxxx = 0;
//            ^^^^^^^^ definition local 8
//                     documentation ```cs\nint? _كوكبxxx\n```
      }
  }
  #pragma warning restore CS0219

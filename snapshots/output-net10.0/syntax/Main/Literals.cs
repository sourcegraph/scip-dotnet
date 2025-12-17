  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 10.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Literals
//             ^^^^^^^^ definition scip-dotnet nuget . . Main/Literals#
//                      documentation ```cs\nclass Literals\n```
  {
      string Interpolation()
//           ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Literals#Interpolation().
//                         documentation ```cs\nprivate string Literals.Interpolation()\n```
      {
          var a = 1;
//            ^ definition local 0
//              documentation ```cs\nint a\n```
          var b = 2;
//            ^ definition local 1
//              documentation ```cs\nint b\n```
          var c = 3;
//            ^ definition local 2
//              documentation ```cs\nint c\n```
          var d = 3;
//            ^ definition local 3
//              documentation ```cs\nint d\n```
          return $"a={a} b={b:0.00} c={c,24} d={d:g}";
//                    ^ reference local 0
//                          ^ reference local 1
//                                     ^ reference local 2
//                                              ^ reference local 3
      }
  }

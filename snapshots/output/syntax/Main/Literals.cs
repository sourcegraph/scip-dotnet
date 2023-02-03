  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  public class Literals
//             ^^^^^^^^ definition scip-dotnet nuget . . Main/Literals#
//                      documentation ```cs\nclass Main.Literals\n```
//                      relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
  {
      string Interpolation()
//           ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Literals#Interpolation().
//                         documentation ```cs\nprivate System.String Main.Literals.Interpolation()\n```
      {
          var a = 1;
//            ^ definition local 0
//              documentation ```cs\nSystem.Int32 a\n```
          var b = 2;
//            ^ definition local 1
//              documentation ```cs\nSystem.Int32 b\n```
          var c = 3;
//            ^ definition local 2
//              documentation ```cs\nSystem.Int32 c\n```
          var d = 3;
//            ^ definition local 3
//              documentation ```cs\nSystem.Int32 d\n```
          return $"a={a} b={b:0.00} c={c,24} d={d:g}";
//                    ^ reference local 0
//                          ^ reference local 1
//                                     ^ reference local 2
//                                              ^ reference local 3
      }
  }

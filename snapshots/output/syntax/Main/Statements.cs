  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  using System.Net;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^ reference scip-dotnet nuget . . Net/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Statements
//             ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#
//                        documentation ```cs\nclass Main.Statements\n```
//                        relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
  {
      void Try()
//         ^^^ definition scip-dotnet nuget . . Main/Statements#Try().
//             documentation ```cs\nprivate void Main.Statements.Try()\n```
      {
          try
          {
              File.ReadLines("asd");
//            ^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/File#
//                 ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/File#ReadLines().
          }
          catch (Exception err)
//               ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/Exception#
//                         ^^^ definition local 0
//                             documentation ```cs\nSystem.Exception err\n```
          {
              Console.WriteLine(err);
//            ^^^^^^^ reference scip-dotnet nuget System.Console 6.0.0.0 System/Console#
//                    ^^^^^^^^^ reference scip-dotnet nuget System.Console 6.0.0.0 System/Console#WriteLine(+9).
//                              ^^^ reference local 0
          }
      }
  
      (string a, bool b) Default()
//                       ^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Default().
//                               documentation ```cs\nprivate (System.String a, System.Boolean b) Main.Statements.Default()\n```
      {
          (string a, bool b) c = default;
//                           ^ definition local 1
//                             documentation ```cs\n(System.String a, System.Boolean b) c\n```
          return c;
//               ^ reference local 1
      }
  
      void Deconstruction()
//         ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Deconstruction().
//                        documentation ```cs\nprivate void Main.Statements.Deconstruction()\n```
      {
          var point = (1, 2);
//            ^^^^^ definition local 2
//                  documentation ```cs\n(System.Int32, System.Int32) point\n```
          int x = 0;
//            ^ definition local 3
//              documentation ```cs\nSystem.Int32 x\n```
          (x, int y) = point;
//         ^ reference local 3
//                     ^^^^^ reference local 2
      }
  
      record Inferred(int F1, int F2);
//           ^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Inferred#
//                    documentation ```cs\nrecord Main.Statements.Inferred\n```
//                    relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                    relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IEquatable#
//                        ^^ definition scip-dotnet nuget . . Main/Statements#Inferred#`.ctor`().(F1)
//                           documentation ```cs\nSystem.Int32 F1\n```
//                                ^^ definition scip-dotnet nuget . . Main/Statements#Inferred#`.ctor`().(F2)
//                                   documentation ```cs\nSystem.Int32 F2\n```
  
      void InferredTuples()
//         ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#InferredTuples().
//                        documentation ```cs\nprivate void Main.Statements.InferredTuples()\n```
      {
          var list = new List<Inferred>();
//            ^^^^ definition local 4
//                 documentation ```cs\nSystem.Collections.Generic.List<Main.Statements.Inferred> list\n```
//                            ^^^^^^^^ reference scip-dotnet nuget . . Main/Statements#Inferred#
          var result = list.Select(c => (c.F1, c.F2)).Where(t => t.F2 == 1);
//            ^^^^^^ definition local 5
//                   documentation ```cs\nSystem.Collections.Generic.IEnumerable<(System.Int32 F1, System.Int32 F2)> result\n```
//                     ^^^^ reference local 4
//                          ^^^^^^ reference scip-dotnet nuget System.Linq 6.0.0.0 Linq/Enumerable#Select().
//                                 ^ definition local 7
//                                   documentation ```cs\nMain.Statements.Inferred c\n```
//                                       ^ reference local 7
//                                         ^^ reference scip-dotnet nuget . . Main/Statements#Inferred#F1.
//                                             ^ reference local 7
//                                               ^^ reference scip-dotnet nuget . . Main/Statements#Inferred#F2.
//                                                    ^^^^^ reference scip-dotnet nuget System.Linq 6.0.0.0 Linq/Enumerable#Where().
//                                                          ^ definition local 9
//                                                            documentation ```cs\n(System.Int32 F1, System.Int32 F2) t\n```
//                                                               ^ reference local 9
//                                                                 ^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/ValueTuple#F2.
      }
  
      int MultipleInitializers()
//        ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MultipleInitializers().
//                             documentation ```cs\nprivate System.Int32 Main.Statements.MultipleInitializers()\n```
      {
          int a = 1, b = 2;
//            ^ definition local 10
//              documentation ```cs\nSystem.Int32 a\n```
//                   ^ definition local 11
//                     documentation ```cs\nSystem.Int32 b\n```
          return a + b;
//               ^ reference local 10
//                   ^ reference local 11
      }
  
      void RefVariable()
//         ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#RefVariable().
//                     documentation ```cs\nprivate void Main.Statements.RefVariable()\n```
      {
          var data = new int[] { 1, 2 };
//            ^^^^ definition local 12
//                 documentation ```cs\nSystem.Int32[] data\n```
          ref var value = ref data[0];
//                ^^^^^ definition local 13
//                      documentation ```cs\nref System.Int32 value\n```
//                            ^^^^ reference local 12
      }
  
      class MyDisposable : IDisposable
//          ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MyDisposable#
//                       documentation ```cs\nclass Main.Statements.MyDisposable\n```
//                       relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                       relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IDisposable#
//                         ^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/IDisposable#
      {
          public void Dispose()
//                    ^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MyDisposable#Dispose().
//                            documentation ```cs\npublic void Main.Statements.MyDisposable.Dispose()\n```
//                            relationship implementation reference scip-dotnet nuget System.Runtime 6.0.0.0 System/IDisposable#Dispose().
          {
          }
      }
  
      MyDisposable Using()
//    ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Statements#MyDisposable#
//                 ^^^^^ definition scip-dotnet nuget . . Main/Statements#Using().
//                       documentation ```cs\nprivate Main.Statements.MyDisposable Main.Statements.Using()\n```
      {
          var b = new MyDisposable();
//            ^ definition local 14
//              documentation ```cs\nMain.Statements.MyDisposable b\n```
//                    ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Statements#MyDisposable#
          using (var a = b)
//                   ^ definition local 15
//                     documentation ```cs\nMain.Statements.MyDisposable a\n```
//                       ^ reference local 14
          {
              return a;
//                   ^ reference local 15
          }
      }
  
      long MultipleUsing()
//         ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MultipleUsing().
//                       documentation ```cs\nprivate System.Int64 Main.Statements.MultipleUsing()\n```
      {
          using (Stream a = File.OpenRead("a"), b = File.OpenRead("a"))
//               ^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/Stream#
//                      ^ definition local 16
//                        documentation ```cs\nSystem.IO.Stream a\n```
//                          ^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/File#
//                               ^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/File#OpenRead().
//                                              ^ definition local 17
//                                                documentation ```cs\nSystem.IO.Stream b\n```
//                                                  ^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/File#
//                                                       ^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/File#OpenRead().
          {
              return a.Length + b.Length;
//                   ^ reference local 16
//                     ^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/Stream#Length.
//                              ^ reference local 17
//                                ^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 IO/Stream#Length.
          }
      }
  
      int Foreach()
//        ^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Foreach().
//                documentation ```cs\nprivate System.Int32 Main.Statements.Foreach()\n```
      {
          var y = new int[] { 1 };
//            ^ definition local 18
//              documentation ```cs\nSystem.Int32[] y\n```
          var z = 0;
//            ^ definition local 19
//              documentation ```cs\nSystem.Int32 z\n```
          foreach (int x in y)
//                          ^ reference local 18
              z += x;
//            ^ reference local 19
//                 ^ reference local 20
          return z;
//               ^ reference local 19
      }
  }

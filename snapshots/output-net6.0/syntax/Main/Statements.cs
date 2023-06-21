  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  public class Statements
//             ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#
//                        documentation ```cs\nclass Statements\n```
  {
      void Try()
//         ^^^ definition scip-dotnet nuget . . Main/Statements#Try().
//             documentation ```cs\nprivate void Statements.Try()\n```
      {
          try
          {
              File.ReadLines("asd");
          }
          catch (Exception err)
//                         ^^^ definition local 0
//                             documentation ```cs\nException err\n```
          {
              Console.WriteLine(err);
//                              ^^^ reference local 0
          }
      }

      (string a, bool b) Default()
//                       ^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Default().
//                               documentation ```cs\nprivate (string a, bool b) Statements.Default()\n```
      {
          (string a, bool b) c = default;
//                           ^ definition local 1
//                             documentation ```cs\n(string a, bool b) c\n```
          return c;
//               ^ reference local 1
      }

      void Deconstruction()
//         ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Deconstruction().
//                        documentation ```cs\nprivate void Statements.Deconstruction()\n```
      {
          var point = (1, 2);
//            ^^^^^ definition local 2
//                  documentation ```cs\n(int, int)? point\n```
          int x = 0;
//            ^ definition local 3
//              documentation ```cs\nint x\n```
          (x, int y) = point;
//         ^ reference local 3
//                ^ definition local 4
//                  documentation ```cs\nint y\n```
//                     ^^^^^ reference local 2
      }

      record Inferred(int F1, int F2);
//           ^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Inferred#
//                    documentation ```cs\nrecord Inferred\n```
//                    relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//                        ^^ definition scip-dotnet nuget . . Main/Statements#Inferred#`.ctor`().(F1)
//                           documentation ```cs\nint F1\n```
//                                ^^ definition scip-dotnet nuget . . Main/Statements#Inferred#`.ctor`().(F2)
//                                   documentation ```cs\nint F2\n```

      void InferredTuples()
//         ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#InferredTuples().
//                        documentation ```cs\nprivate void Statements.InferredTuples()\n```
      {
          var list = new List<Inferred>();
//            ^^^^ definition local 5
//                 documentation ```cs\nList<Inferred>? list\n```
//                            ^^^^^^^^ reference scip-dotnet nuget . . Main/Statements#Inferred#
          var result = list.Select(c => (c.F1, c.F2)).Where(t => t.F2 == 1);
//            ^^^^^^ definition local 6
//                   documentation ```cs\n? result\n```
//                     ^^^^ reference local 5
//                                 ^ definition local 8
//                                   documentation ```cs\n c\n```
//                                       ^ reference local 8
//                                             ^ reference local 8
//                                                          ^ definition local 10
//                                                            documentation ```cs\n t\n```
//                                                               ^ reference local 10
      }

      int MultipleInitializers()
//        ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MultipleInitializers().
//                             documentation ```cs\nprivate int Statements.MultipleInitializers()\n```
      {
          int a = 1, b = 2;
//            ^ definition local 11
//              documentation ```cs\nint a\n```
//                   ^ definition local 12
//                     documentation ```cs\nint b\n```
          return a + b;
//               ^ reference local 11
//                   ^ reference local 12
      }

      void RefVariable()
//         ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#RefVariable().
//                     documentation ```cs\nprivate void Statements.RefVariable()\n```
      {
          var data = new int[] { 1, 2 };
//            ^^^^ definition local 13
//                 documentation ```cs\nint[]? data\n```
          ref var value = ref data[0];
//                ^^^^^ definition local 14
//                      documentation ```cs\nref int? value\n```
//                            ^^^^ reference local 13
      }

      class MyDisposable : IDisposable
//          ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MyDisposable#
//                       documentation ```cs\nclass MyDisposable\n```
//                       relationship implementation scip-dotnet nuget . . ``/IDisposable#
      {
          public void Dispose()
//                    ^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MyDisposable#Dispose().
//                            documentation ```cs\npublic void MyDisposable.Dispose()\n```
          {
          }
      }

      MyDisposable Using()
//    ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Statements#MyDisposable#
//                 ^^^^^ definition scip-dotnet nuget . . Main/Statements#Using().
//                       documentation ```cs\nprivate MyDisposable Statements.Using()\n```
      {
          var b = new MyDisposable();
//            ^ definition local 15
//              documentation ```cs\nMyDisposable? b\n```
//                    ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Statements#MyDisposable#
          using (var a = b)
//                   ^ definition local 16
//                     documentation ```cs\nMyDisposable? a\n```
//                       ^ reference local 15
          {
              return a;
//                   ^ reference local 16
          }
      }

      long MultipleUsing()
//         ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Statements#MultipleUsing().
//                       documentation ```cs\nprivate long Statements.MultipleUsing()\n```
      {
          using (Stream a = File.OpenRead("a"), b = File.OpenRead("a"))
//                      ^ definition local 17
//                        documentation ```cs\nStream a\n```
//                                              ^ definition local 18
//                                                documentation ```cs\nStream b\n```
          {
              return a.Length + b.Length;
//                   ^ reference local 17
//                              ^ reference local 18
          }
      }

      int Foreach()
//        ^^^^^^^ definition scip-dotnet nuget . . Main/Statements#Foreach().
//                documentation ```cs\nprivate int Statements.Foreach()\n```
      {
          var y = new int[] { 1 };
//            ^ definition local 19
//              documentation ```cs\nint[]? y\n```
          var z = 0;
//            ^ definition local 20
//              documentation ```cs\nint? z\n```
          foreach (int x in y)
//                          ^ reference local 19
              z += x;
//            ^ reference local 20
//                 ^ reference local 21
          return z;
//               ^ reference local 20
      }
  }

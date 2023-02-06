  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class QuerySyntax
//             ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#
//                         documentation ```cs\nclass QuerySyntax\n```
  {
      List<IGeneric> sourceA = new List<IGeneric>();
//         ^^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#
//                   ^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                           documentation ```cs\nprivate List<IGeneric> QuerySyntax.sourceA\n```
//                                      ^^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#
      List<IGeneric> sourceB = new List<IGeneric>();
//         ^^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#
//                   ^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#sourceB.
//                           documentation ```cs\nprivate List<IGeneric> QuerySyntax.sourceB\n```
//                                      ^^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#

      interface IGeneric
//              ^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#IGeneric#
//                       documentation ```cs\ninterface IGeneric\n```
      {
          string Method();
//               ^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                      documentation ```cs\nstring IGeneric.Method()\n```
      }

      void Select()
//         ^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Select().
//                documentation ```cs\nprivate void QuerySyntax.Select()\n```
      {
          var x = from a in sourceA select a.Method();
//            ^ definition local 0
//              documentation ```cs\nIEnumerable<string>? x\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                         ^ reference scip-dotnet nuget . . Main/QuerySyntax#Select().a.
//                                           ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
      }

      void Projection()
//         ^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Projection().
//                    documentation ```cs\nprivate void QuerySyntax.Projection()\n```
      {
          var x = from a in sourceA select new { Name = a.Method() };
//            ^ definition local 1
//              documentation ```cs\nIEnumerable<<anonymous type: string Name>>? x\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                               ^^^^ reference local 3
//                                                      ^ reference scip-dotnet nuget . . Main/QuerySyntax#Projection().a.
//                                                        ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
          var b = from a in x select a.Name;
//            ^ definition local 4
//              documentation ```cs\nIEnumerable<string>? b\n```
//                          ^ reference local 1
//                                   ^ reference scip-dotnet nuget . . Main/QuerySyntax#Projection().a.
//                                     ^^^^ reference local 3
      }

      void Where()
//         ^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Where().
//               documentation ```cs\nprivate void QuerySyntax.Where()\n```
      {
          var x = from a in sourceA where a.Method().StartsWith("a") select a;
//            ^ definition local 5
//              documentation ```cs\nIEnumerable<IGeneric>? x\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                        ^ reference scip-dotnet nuget . . Main/QuerySyntax#Where().a.
//                                          ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                                   ^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/String#StartsWith(+1).
//                                                                          ^ reference scip-dotnet nuget . . Main/QuerySyntax#Where().a.
      }

      void Let()
//         ^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Let().
//             documentation ```cs\nprivate void QuerySyntax.Let()\n```
      {
          var x = from a in sourceA
//            ^ definition local 6
//              documentation ```cs\nIEnumerable<<anonymous type: string A, string B>>? x\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  let z = new { A = a.Method(), B = a.Method() }
//                              ^ reference local 8
//                                  ^ reference scip-dotnet nuget . . Main/QuerySyntax#Let().a.
//                                    ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                              ^ reference local 9
//                                                  ^ reference scip-dotnet nuget . . Main/QuerySyntax#Let().a.
//                                                    ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
                  select z;
//                       ^ reference scip-dotnet nuget . . Main/QuerySyntax#Let().z.
      }

      void Join()
//         ^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Join().
//              documentation ```cs\nprivate void QuerySyntax.Join()\n```
      {
          var x = from a in sourceA
//            ^ definition local 10
//              documentation ```cs\nIEnumerable<<anonymous type: string A, string B>>? x\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  join b in sourceB on a.Method() equals b.Method()
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceB.
//                                     ^ reference scip-dotnet nuget . . Main/QuerySyntax#Join().a.
//                                       ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                                       ^ reference scip-dotnet nuget . . Main/QuerySyntax#Join().b.
//                                                         ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
                  select new { A = a.Method(), B = b.Method() };
//                             ^ reference local 8
//                                 ^ reference scip-dotnet nuget . . Main/QuerySyntax#Join().a.
//                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                             ^ reference local 9
//                                                 ^ reference scip-dotnet nuget . . Main/QuerySyntax#Join().b.
//                                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
      }

      void MultipleFrom()
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#MultipleFrom().
//                      documentation ```cs\nprivate void QuerySyntax.MultipleFrom()\n```
      {
          var x = from a in sourceA
//            ^ definition local 11
//              documentation ```cs\nIEnumerable<<anonymous type: string A, string B>>? x\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  from b in sourceB
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceB.
                  where a.Method() == b.Method()
//                      ^ reference scip-dotnet nuget . . Main/QuerySyntax#MultipleFrom().a.
//                        ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                    ^ reference scip-dotnet nuget . . Main/QuerySyntax#MultipleFrom().b.
//                                      ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
                  select new { A = a.Method(), B = b.Method() };
//                             ^ reference local 8
//                                 ^ reference scip-dotnet nuget . . Main/QuerySyntax#MultipleFrom().a.
//                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                             ^ reference local 9
//                                                 ^ reference scip-dotnet nuget . . Main/QuerySyntax#MultipleFrom().b.
//                                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
      }
  }

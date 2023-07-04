  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
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
//              documentation ```cs\n? x\n```
//                     ^ definition local 1
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                         ^ reference local 1
      }

      void Projection()
//         ^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Projection().
//                    documentation ```cs\nprivate void QuerySyntax.Projection()\n```
      {
          var x = from a in sourceA select new { Name = a.Method() };
//            ^ definition local 2
//              documentation ```cs\n? x\n```
//                     ^ definition local 3
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                               ^^^^ reference local 5
//                                                      ^ reference local 3
          var b = from a in x select a.Name;
//            ^ definition local 6
//              documentation ```cs\n? b\n```
//                     ^ definition local 7
//                       documentation ```cs\n? a\n```
//                          ^ reference local 2
//                                   ^ reference local 7
      }

      void Where()
//         ^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Where().
//               documentation ```cs\nprivate void QuerySyntax.Where()\n```
      {
          var x = from a in sourceA where a.Method().StartsWith("a") select a;
//            ^ definition local 8
//              documentation ```cs\n? x\n```
//                     ^ definition local 9
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                        ^ reference local 9
//                                                                          ^ reference local 9
      }

      void Let()
//         ^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Let().
//             documentation ```cs\nprivate void QuerySyntax.Let()\n```
      {
          var x = from a in sourceA
//            ^ definition local 10
//              documentation ```cs\n? x\n```
//                     ^ definition local 11
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  let z = new { A = a.Method(), B = a.Method() }
//                    ^ definition local 12
//                      documentation ```cs\n? z\n```
//                              ^ reference local 14
//                                  ^ reference local 11
//                                              ^ reference local 15
//                                                  ^ reference local 11
                  select z;
//                       ^ reference local 12
      }

      void Join()
//         ^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Join().
//              documentation ```cs\nprivate void QuerySyntax.Join()\n```
      {
          var x = from a in sourceA
//            ^ definition local 16
//              documentation ```cs\n? x\n```
//                     ^ definition local 17
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  join b in sourceB on a.Method() equals b.Method()
//                     ^ definition local 18
//                       documentation ```cs\n? b\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceB.
//                                     ^ reference local 17
//                                                       ^ reference local 18
                  select new { A = a.Method(), B = b.Method() };
//                             ^ reference local 14
//                                 ^ reference local 17
//                                             ^ reference local 15
//                                                 ^ reference local 18
      }

      void MultipleFrom()
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#MultipleFrom().
//                      documentation ```cs\nprivate void QuerySyntax.MultipleFrom()\n```
      {
          var x = from a in sourceA
//            ^ definition local 19
//              documentation ```cs\n? x\n```
//                     ^ definition local 20
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  from b in sourceB
//                     ^ definition local 21
//                       documentation ```cs\n? b\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceB.
                  where a.Method() == b.Method()
//                      ^ reference local 20
//                                    ^ reference local 21
                  select new { A = a.Method(), B = b.Method() };
//                             ^ reference local 14
//                                 ^ reference local 20
//                                             ^ reference local 15
//                                                 ^ reference local 21
      }

      void JoinInto(List<Student> students1, List<Student> students2)
//         ^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#JoinInto().
//                  documentation ```cs\nprivate void QuerySyntax.JoinInto(List<Student> students1, List<Student> students2)\n```
//                       ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#
//                                ^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#JoinInto().(students1)
//                                          documentation ```cs\nList<Student> students1\n```
//                                                ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#
//                                                         ^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#JoinInto().(students2)
//                                                                   documentation ```cs\nList<Student> students2\n```
      {
          var innerGroupJoinQuery =
//            ^^^^^^^^^^^^^^^^^^^ definition local 22
//                                documentation ```cs\n? innerGroupJoinQuery\n```
              from student1 in students1
//                 ^^^^^^^^ definition local 23
//                          documentation ```cs\n? student1\n```
//                             ^^^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#JoinInto().(students1)
              join student2 in students2 on student1.ID equals student2.ID into studentGroup
//                 ^^^^^^^^ definition local 24
//                          documentation ```cs\n? student2\n```
//                             ^^^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#JoinInto().(students2)
//                                          ^^^^^^^^ reference local 23
//                                                             ^^^^^^^^ reference local 24
//                                                                              ^^^^^^^^^^^^ definition local 25
//                                                                                           documentation ```cs\n? studentGroup\n```
              select new { Student = student1.First, Students = studentGroup };
//                         ^^^^^^^ reference local 27
//                                   ^^^^^^^^ reference local 23
//                                                   ^^^^^^^^ reference local 28
//                                                              ^^^^^^^^^^^^ reference local 25
      }

      void Continuation(List<Student> students)
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Continuation().
//                      documentation ```cs\nprivate void QuerySyntax.Continuation(List<Student> students)\n```
//                           ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#
//                                    ^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Continuation().(students)
//                                             documentation ```cs\nList<Student> students\n```
      {
          var sortedGroups =
//            ^^^^^^^^^^^^ definition local 29
//                         documentation ```cs\n? sortedGroups\n```
              from student in students
//                 ^^^^^^^ definition local 30
//                         documentation ```cs\n? student\n```
//                            ^^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Continuation().(students)
              orderby student.Last, student.First
//                    ^^^^^^^ reference local 30
//                                  ^^^^^^^ reference local 30
              group student by student.Last[0] into newGroup
//                  ^^^^^^^ reference local 30
//                             ^^^^^^^ reference local 30
//                                                  ^^^^^^^^ definition local 31
//                                                           documentation ```cs\n? newGroup\n```
              orderby newGroup.Key
//                    ^^^^^^^^ reference local 31
              select newGroup;
//                   ^^^^^^^^ reference local 31
      }

      private class Student
//                  ^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Student#
//                          documentation ```cs\nclass Student\n```
      {
          public string First { get; set; }
//                      ^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Student#First.
//                            documentation ```cs\npublic string Student.First { get; set; }\n```
          public string Last { get; set; }
//                      ^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Student#Last.
//                           documentation ```cs\npublic string Student.Last { get; set; }\n```
          public int ID { get; set; }
//                   ^^ definition scip-dotnet nuget . . Main/QuerySyntax#Student#ID.
//                      documentation ```cs\npublic int Student.ID { get; set; }\n```
      }

  }

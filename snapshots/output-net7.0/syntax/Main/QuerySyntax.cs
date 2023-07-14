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
//                     ^ definition local 1
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                         ^ reference local 1
//                                           ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
      }

      void Projection()
//         ^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Projection().
//                    documentation ```cs\nprivate void QuerySyntax.Projection()\n```
      {
          var x = from a in sourceA select new { Name = a.Method() };
//            ^ definition local 2
//              documentation ```cs\nIEnumerable<<anonymous type: string Name>>? x\n```
//                     ^ definition local 3
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                               ^^^^ reference local 5
//                                                      ^ reference local 3
//                                                        ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
          var b = from a in x select a.Name;
//            ^ definition local 6
//              documentation ```cs\nIEnumerable<string>? b\n```
//                     ^ definition local 7
//                       documentation ```cs\n? a\n```
//                          ^ reference local 2
//                                   ^ reference local 7
//                                     ^^^^ reference local 5
      }

      void Where()
//         ^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Where().
//               documentation ```cs\nprivate void QuerySyntax.Where()\n```
      {
          var x = from a in sourceA where a.Method().StartsWith("a") select a;
//            ^ definition local 8
//              documentation ```cs\nIEnumerable<IGeneric>? x\n```
//                     ^ definition local 9
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
//                                        ^ reference local 9
//                                          ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                                   ^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/String#StartsWith(+1).
//                                                                          ^ reference local 9
      }

      void Let()
//         ^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Let().
//             documentation ```cs\nprivate void QuerySyntax.Let()\n```
      {
          var x = from a in sourceA
//            ^ definition local 10
//              documentation ```cs\nIEnumerable<<anonymous type: string A, string B>>? x\n```
//                     ^ definition local 11
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  let z = new { A = a.Method(), B = a.Method() }
//                    ^ definition local 12
//                      documentation ```cs\n? z\n```
//                              ^ reference local 14
//                                  ^ reference local 11
//                                    ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                              ^ reference local 15
//                                                  ^ reference local 11
//                                                    ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
                  select z;
//                       ^ reference local 12
      }

      void Join()
//         ^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Join().
//              documentation ```cs\nprivate void QuerySyntax.Join()\n```
      {
          var x = from a in sourceA
//            ^ definition local 16
//              documentation ```cs\nIEnumerable<<anonymous type: string A, string B>>? x\n```
//                     ^ definition local 17
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  join b in sourceB on a.Method() equals b.Method()
//                     ^ definition local 18
//                       documentation ```cs\n? b\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceB.
//                                     ^ reference local 17
//                                       ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                                       ^ reference local 18
//                                                         ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
                  select new { A = a.Method(), B = b.Method() };
//                             ^ reference local 14
//                                 ^ reference local 17
//                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                             ^ reference local 15
//                                                 ^ reference local 18
//                                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
      }

      void MultipleFrom()
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#MultipleFrom().
//                      documentation ```cs\nprivate void QuerySyntax.MultipleFrom()\n```
      {
          var x = from a in sourceA
//            ^ definition local 19
//              documentation ```cs\nIEnumerable<<anonymous type: string A, string B>>? x\n```
//                     ^ definition local 20
//                       documentation ```cs\n? a\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceA.
                  from b in sourceB
//                     ^ definition local 21
//                       documentation ```cs\n? b\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#sourceB.
                  where a.Method() == b.Method()
//                      ^ reference local 20
//                        ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                    ^ reference local 21
//                                      ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
                  select new { A = a.Method(), B = b.Method() };
//                             ^ reference local 14
//                                 ^ reference local 20
//                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
//                                             ^ reference local 15
//                                                 ^ reference local 21
//                                                   ^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#IGeneric#Method().
      }

      void JoinInto(List<Student> students1, List<Student> students2)
//         ^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#JoinInto().
//                  documentation ```cs\nprivate void QuerySyntax.JoinInto(List<Student> students1, List<Student> students2)\n```
//                       ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#
//                                ^^^^^^^^^ definition local 22
//                                          documentation ```cs\nList<Student> students1\n```
//                                                ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#
//                                                         ^^^^^^^^^ definition local 23
//                                                                   documentation ```cs\nList<Student> students2\n```
      {
          var innerGroupJoinQuery =
//            ^^^^^^^^^^^^^^^^^^^ definition local 24
//                                documentation ```cs\nIEnumerable<<anonymous type: string Student, interface IEnumerable<Student> Students>>? innerGroupJoinQuery\n```
              from student1 in students1
//                 ^^^^^^^^ definition local 25
//                          documentation ```cs\n? student1\n```
//                             ^^^^^^^^^ reference local 22
              join student2 in students2 on student1.ID equals student2.ID into studentGroup
//                 ^^^^^^^^ definition local 26
//                          documentation ```cs\n? student2\n```
//                             ^^^^^^^^^ reference local 23
//                                          ^^^^^^^^ reference local 25
//                                                   ^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#ID.
//                                                             ^^^^^^^^ reference local 26
//                                                                      ^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#ID.
//                                                                              ^^^^^^^^^^^^ definition local 27
//                                                                                           documentation ```cs\n? studentGroup\n```
              select new { Student = student1.First, Students = studentGroup };
//                         ^^^^^^^ reference local 29
//                                   ^^^^^^^^ reference local 25
//                                            ^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#First.
//                                                   ^^^^^^^^ reference local 30
//                                                              ^^^^^^^^^^^^ reference local 27
      }

      void Continuation(List<Student> students)
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/QuerySyntax#Continuation().
//                      documentation ```cs\nprivate void QuerySyntax.Continuation(List<Student> students)\n```
//                           ^^^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#
//                                    ^^^^^^^^ definition local 31
//                                             documentation ```cs\nList<Student> students\n```
      {
          var sortedGroups =
//            ^^^^^^^^^^^^ definition local 32
//                         documentation ```cs\nIOrderedEnumerable<IGrouping<char, Student>>? sortedGroups\n```
              from student in students
//                 ^^^^^^^ definition local 33
//                         documentation ```cs\n? student\n```
//                            ^^^^^^^^ reference local 31
              orderby student.Last, student.First
//                    ^^^^^^^ reference local 33
//                            ^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#Last.
//                                  ^^^^^^^ reference local 33
//                                          ^^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#First.
              group student by student.Last[0] into newGroup
//                  ^^^^^^^ reference local 33
//                             ^^^^^^^ reference local 33
//                                     ^^^^ reference scip-dotnet nuget . . Main/QuerySyntax#Student#Last.
//                                                  ^^^^^^^^ definition local 34
//                                                           documentation ```cs\n? newGroup\n```
              orderby newGroup.Key
//                    ^^^^^^^^ reference local 34
//                             ^^^ reference scip-dotnet nuget System.Linq 7.0.0.0 Linq/IGrouping#Key.
              select newGroup;
//                   ^^^^^^^^ reference local 34
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

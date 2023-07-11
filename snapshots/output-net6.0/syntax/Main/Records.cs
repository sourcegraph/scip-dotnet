  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  public class Records
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Records#
//                     documentation ```cs\nclass Records\n```
  {
      record Basic
//           ^^^^^ definition scip-dotnet nuget . . Main/Records#Basic#
//                 documentation ```cs\nrecord Basic\n```
//                 relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Basic#Age.
//                documentation ```cs\nprivate int Basic.Age { get; init; }\n```
      }

      record struct Struct
//                  ^^^^^^ definition scip-dotnet nuget . . Main/Records#Struct#
//                         documentation ```cs\nrecord struct Struct\n```
//                         relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Struct#Age.
//                documentation ```cs\nprivate int Struct.Age { get; init; }\n```
      }

      record class Class
//                 ^^^^^ definition scip-dotnet nuget . . Main/Records#Class#
//                       documentation ```cs\nrecord Class\n```
//                       relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Class#Age.
//                documentation ```cs\nprivate int Class.Age { get; init; }\n```
      }

      public record TypeParameterConstraint<T> where T : struct
//                  ^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#TypeParameterConstraint#
//                                          documentation ```cs\nrecord TypeParameterConstraint<T> where T : struct\n```
//                                          relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//                                          ^ definition local 0
//                                            documentation ```cs\nT\n```
//                                                   ^ reference local 0
      {
      }

      interface I1
//              ^^ definition scip-dotnet nuget . . Main/Records#I1#
//                 documentation ```cs\ninterface I1\n```
      {
      };

      interface I2
//              ^^ definition scip-dotnet nuget . . Main/Records#I2#
//                 documentation ```cs\ninterface I2\n```
      {
      };


      record Person(string FirstName, string LastName) : I1, I2
//           ^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#
//                  documentation ```cs\nrecord Person\n```
//                  relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                  relationship implementation scip-dotnet nuget . . Main/Records#I2#
//                  relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//                         ^^^^^^^^^ definition local 1
//                                   documentation ```cs\nstring FirstName\n```
//                                           ^^^^^^^^ definition local 2
//                                                    documentation ```cs\nstring LastName\n```
//                                                       ^^ reference scip-dotnet nuget . . Main/Records#I1#
//                                                           ^^ reference scip-dotnet nuget . . Main/Records#I2#
      {
          public Person(string FirstName) : this(FirstName, FirstName)
//               ^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).
//                      documentation ```cs\npublic Person.Person(string FirstName)\n```
//                             ^^^^^^^^^ definition local 3
//                                       documentation ```cs\nstring FirstName\n```
//                                               ^^^^^^^^^ reference local 3
//                                                          ^^^^^^^^^ reference local 3
          {
          }
      };

      record Teacher(string FirstName, string LastName, string Subject) : Person(FirstName, LastName), I1, I2;
//           ^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#
//                   documentation ```cs\nrecord Teacher\n```
//                   relationship implementation scip-dotnet nuget . . Main/Records#Person#
//                   relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//                   relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                   relationship implementation scip-dotnet nuget . . Main/Records#I2#
//                   relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//                          ^^^^^^^^^ definition local 4
//                                    documentation ```cs\nstring FirstName\n```
//                                            ^^^^^^^^ definition local 5
//                                                     documentation ```cs\nstring LastName\n```
//                                                             ^^^^^^^ definition local 6
//                                                                     documentation ```cs\nstring Subject\n```
//                                                                        ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
//                                                                               ^^^^^^^^^ reference local 4
//                                                                                          ^^^^^^^^ reference local 5
//                                                                                                     ^^ reference scip-dotnet nuget . . Main/Records#I1#
//                                                                                                         ^^ reference scip-dotnet nuget . . Main/Records#I2#

      void UsingRecords()
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#UsingRecords().
//                      documentation ```cs\nprivate void Records.UsingRecords()\n```
      {
          var person = new Person("a", "b");
//            ^^^^^^ definition local 7
//                   documentation ```cs\nPerson? person\n```
//                         ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
          var teacher = new Teacher("a", "b", "c");
//            ^^^^^^^ definition local 8
//                    documentation ```cs\nTeacher? teacher\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/Records#Teacher#
      }

      record I3<T>;
//           ^^ definition scip-dotnet nuget . . Main/Records#I3#
//              documentation ```cs\nrecord I3<T>\n```
//              relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//              ^ definition local 9
//                documentation ```cs\nT\n```

      record Teacher2() : I3<Person>(), I1;
//           ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher2#
//                    documentation ```cs\nrecord Teacher2\n```
//                    relationship implementation scip-dotnet nuget . . Main/Records#I3#
//                    relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//                    relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                    relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
//                           ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
//                                      ^^ reference scip-dotnet nuget . . Main/Records#I1#

      record SealedToString
//           ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#SealedToString#
//                          documentation ```cs\nrecord SealedToString\n```
//                          relationship implementation scip-dotnet nuget Main 0.0.0.0 System/IEquatable#
      {
          public sealed override string ToString()
//                                      ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#SealedToString#ToString().
//                                               documentation ```cs\npublic override sealed string SealedToString.ToString()\n```
          {
              return "";
          }
      }
  }

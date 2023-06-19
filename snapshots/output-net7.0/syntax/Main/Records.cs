  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Records
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Records#
//                     documentation ```cs\nclass Records\n```
  {
      record Basic
//           ^^^^^ definition scip-dotnet nuget . . Main/Records#Basic#
//                 documentation ```cs\nrecord Basic\n```
//                 relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Basic#Age.
//                documentation ```cs\nprivate int Basic.Age { get; init; }\n```
      }

      record struct Struct
//                  ^^^^^^ definition scip-dotnet nuget . . Main/Records#Struct#
//                         documentation ```cs\nrecord struct Struct\n```
//                         relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Struct#Age.
//                documentation ```cs\nprivate int Struct.Age { get; init; }\n```
      }

      record class Class
//                 ^^^^^ definition scip-dotnet nuget . . Main/Records#Class#
//                       documentation ```cs\nrecord Class\n```
//                       relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Class#Age.
//                documentation ```cs\nprivate int Class.Age { get; init; }\n```
      }

      public record TypeParameterConstraint<T> where T : struct
//                  ^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#TypeParameterConstraint#
//                                          documentation ```cs\nrecord TypeParameterConstraint<T> where T : struct\n```
//                                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                                          ^ definition scip-dotnet nuget . . Main/Records#TypeParameterConstraint#[T]
//                                            documentation ```cs\nT\n```
//                                                   ^ reference scip-dotnet nuget . . Main/Records#TypeParameterConstraint#[T]
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
//                  relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                         ^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`().(FirstName)
//                                   documentation ```cs\nstring FirstName\n```
//                                           ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`().(LastName)
//                                                    documentation ```cs\nstring LastName\n```
//                                                       ^^ reference scip-dotnet nuget . . Main/Records#I1#
//                                                           ^^ reference scip-dotnet nuget . . Main/Records#I2#
      {
          public Person(string FirstName) : this(FirstName, FirstName)
//               ^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).
//                      documentation ```cs\npublic Person.Person(string FirstName)\n```
//                             ^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).(FirstName)
//                                       documentation ```cs\nstring FirstName\n```
//                                               ^^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).(FirstName)
//                                                          ^^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).(FirstName)
          {
          }
      };

      record Teacher(string FirstName, string LastName, string Subject) : Person(FirstName, LastName), I1, I2;
//           ^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#
//                   documentation ```cs\nrecord Teacher\n```
//                   relationship implementation scip-dotnet nuget . . Main/Records#Person#
//                   relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                   relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                   relationship implementation scip-dotnet nuget . . Main/Records#I2#
//                   relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                          ^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(FirstName)
//                                    documentation ```cs\nstring FirstName\n```
//                                            ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(LastName)
//                                                     documentation ```cs\nstring LastName\n```
//                                                             ^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(Subject)
//                                                                     documentation ```cs\nstring Subject\n```
//                                                                        ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
//                                                                               ^^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(FirstName)
//                                                                                          ^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(LastName)
//                                                                                                     ^^ reference scip-dotnet nuget . . Main/Records#I1#
//                                                                                                         ^^ reference scip-dotnet nuget . . Main/Records#I2#

      void UsingRecords()
//         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#UsingRecords().
//                      documentation ```cs\nprivate void Records.UsingRecords()\n```
      {
          var person = new Person("a", "b");
//            ^^^^^^ definition local 0
//                   documentation ```cs\nPerson? person\n```
//                         ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
          var teacher = new Teacher("a", "b", "c");
//            ^^^^^^^ definition local 1
//                    documentation ```cs\nTeacher? teacher\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . Main/Records#Teacher#
      }

      record I3<T>;
//           ^^ definition scip-dotnet nuget . . Main/Records#I3#
//              documentation ```cs\nrecord I3<T>\n```
//              relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//              ^ definition scip-dotnet nuget . . Main/Records#I3#[T]
//                documentation ```cs\nT\n```

      record Teacher2() : I3<Person>(), I1;
//           ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher2#
//                    documentation ```cs\nrecord Teacher2\n```
//                    relationship implementation scip-dotnet nuget . . Main/Records#I3#
//                    relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                    relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                    relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                           ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
//                                      ^^ reference scip-dotnet nuget . . Main/Records#I1#

      record SealedToString
//           ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#SealedToString#
//                          documentation ```cs\nrecord SealedToString\n```
//                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          public sealed override string ToString()
//                                      ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#SealedToString#ToString().
//                                               documentation ```cs\npublic override sealed string SealedToString.ToString()\n```
//                                               relationship implementation reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#ToString().
          {
              return "";
          }
      }
  }

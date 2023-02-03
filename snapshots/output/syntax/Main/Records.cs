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
//                     documentation ```cs\nclass Main.Records\n```
//                     relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
  {
      record Basic
//           ^^^^^ definition scip-dotnet nuget . . Main/Records#Basic#
//                 documentation ```cs\nrecord Main.Records.Basic\n```
//                 relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                 relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Basic#Age.
//                documentation ```cs\nprivate System.Int32 Main.Records.Basic.Age { get; init; }\n```
      }
  
      record struct Struct
//                  ^^^^^^ definition scip-dotnet nuget . . Main/Records#Struct#
//                         documentation ```cs\nrecord struct Main.Records.Struct\n```
//                         relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/ValueType#
//                         relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                         relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Struct#Age.
//                documentation ```cs\nprivate System.Int32 Main.Records.Struct.Age { get; init; }\n```
      }
  
      record class Class
//                 ^^^^^ definition scip-dotnet nuget . . Main/Records#Class#
//                       documentation ```cs\nrecord Main.Records.Class\n```
//                       relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                       relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          int Age { get; init; }
//            ^^^ definition scip-dotnet nuget . . Main/Records#Class#Age.
//                documentation ```cs\nprivate System.Int32 Main.Records.Class.Age { get; init; }\n```
      }
  
      public record TypeParameterConstraint<T> where T : struct
//                  ^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#TypeParameterConstraint#
//                                          documentation ```cs\nrecord Main.Records.TypeParameterConstraint<T> where T : struct\n```
//                                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                                                   ^ reference scip-dotnet nuget . . Main/Records#TypeParameterConstraint#[T]
      {
      }
  
      interface I1
//              ^^ definition scip-dotnet nuget . . Main/Records#I1#
//                 documentation ```cs\ninterface Main.Records.I1\n```
      {
      };
  
      interface I2
//              ^^ definition scip-dotnet nuget . . Main/Records#I2#
//                 documentation ```cs\ninterface Main.Records.I2\n```
      {
      };
  
  
      record Person(string FirstName, string LastName) : I1, I2
//           ^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#
//                  documentation ```cs\nrecord Main.Records.Person\n```
//                  relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                  relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                  relationship implementation scip-dotnet nuget . . Main/Records#I2#
//                  relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                         ^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`().(FirstName)
//                                   documentation ```cs\nSystem.String FirstName\n```
//                                           ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`().(LastName)
//                                                    documentation ```cs\nSystem.String LastName\n```
//                                                       ^^ reference scip-dotnet nuget . . Main/Records#I1#
//                                                           ^^ reference scip-dotnet nuget . . Main/Records#I2#
      {
          public Person(string FirstName) : this(FirstName, FirstName)
//               ^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).
//                      documentation ```cs\npublic Main.Records.Person.Person(System.String FirstName)\n```
//                             ^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).(FirstName)
//                                       documentation ```cs\nSystem.String FirstName\n```
//                                               ^^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).(FirstName)
//                                                          ^^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#`.ctor`(+1).(FirstName)
          {
          }
      };
  
      record Teacher(string FirstName, string LastName, string Subject) : Person(FirstName, LastName), I1, I2;
//           ^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#
//                   documentation ```cs\nrecord Main.Records.Teacher\n```
//                   relationship implementation scip-dotnet nuget . . Main/Records#Person#
//                   relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                   relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                   relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                   relationship implementation scip-dotnet nuget . . Main/Records#I2#
//                   relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                          ^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(FirstName)
//                                    documentation ```cs\nSystem.String FirstName\n```
//                                            ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(LastName)
//                                                     documentation ```cs\nSystem.String LastName\n```
//                                                             ^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(Subject)
//                                                                     documentation ```cs\nSystem.String Subject\n```
//                                                                        ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
//                                                                               ^^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(FirstName)
//                                                                                          ^^^^^^^^ reference scip-dotnet nuget . . Main/Records#Teacher#`.ctor`().(LastName)
//                                                                                                     ^^ reference scip-dotnet nuget . . Main/Records#I1#
//                                                                                                         ^^ reference scip-dotnet nuget . . Main/Records#I2#
  
      record I3<T>;
//           ^^ definition scip-dotnet nuget . . Main/Records#I3#
//              documentation ```cs\nrecord Main.Records.I3<T>\n```
//              relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//              relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
  
      record Teacher2() : I3<Person>(), I1;
//           ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#Teacher2#
//                    documentation ```cs\nrecord Main.Records.Teacher2\n```
//                    relationship implementation scip-dotnet nuget . . Main/Records#I3#
//                    relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                    relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                    relationship implementation scip-dotnet nuget . . Main/Records#I1#
//                    relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
//                           ^^^^^^ reference scip-dotnet nuget . . Main/Records#Person#
//                                      ^^ reference scip-dotnet nuget . . Main/Records#I1#
  
      record SealedToString
//           ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Records#SealedToString#
//                          documentation ```cs\nrecord Main.Records.SealedToString\n```
//                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IEquatable#
      {
          public sealed override string ToString()
//                                      ^^^^^^^^ definition scip-dotnet nuget . . Main/Records#SealedToString#ToString().
//                                               documentation ```cs\npublic override sealed System.String Main.Records.SealedToString.ToString()\n```
//                                               relationship implementation reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#ToString().
          {
              return "";
          }
      }
  }

  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
// ^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeUsageAttribute#`.ctor`().
//                ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeTargets#
//                                 ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeTargets#Class.
//                                        ^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeUsageAttribute#AllowMultiple.
//                                                              ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/AttributeUsageAttribute#Inherited.
  public class GlobalAttributes : Attribute
//             ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#
//                              documentation ```cs\nclass GlobalAttributes\n```
//                              relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
//                                ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
  {
      class AuthorAttribute : Attribute
//          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#
//                          documentation ```cs\nclass AuthorAttribute\n```
//                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
//                            ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
      {
          public AuthorAttribute(string name)
//               ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
//                               documentation ```cs\npublic AuthorAttribute.AuthorAttribute(string name)\n```
//                                      ^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().(name)
//                                           documentation ```cs\nstring name\n```
          {
          }
      }

      [Author("PropertyAttribute")] public int Z;
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
//                                             ^ definition scip-dotnet nuget . . Main/GlobalAttributes#Z.
//                                               documentation ```cs\npublic int GlobalAttributes.Z\n```

      [Author("MethodAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      int Method1()
//        ^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#Method1().
//                documentation ```cs\nprivate int GlobalAttributes.Method1()\n```
      {
          return 0;
      }

      [Author("EnumAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      enum A
//         ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#
//           documentation ```cs\nenum A\n```
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IComparable#
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IConvertible#
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IFormattable#
      {
          B,
//        ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#B.
//          documentation ```cs\nA.B = 0\n```
          C
//        ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#C.
//          documentation ```cs\nA.C = 1\n```
      }

      [Author("EventAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      public event EventHandler SomeEvent
//                 ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#
//                              ^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#SomeEvent#
//                                        documentation ```cs\npublic event EventHandler GlobalAttributes.SomeEvent\n```
      {
          add { }
          remove { }
      }

      [Author("TypeParameterAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      public class InnerClass<[Author("ClassTypeParameter")] T>
//                 ^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#InnerClass#
//                            documentation ```cs\nclass InnerClass<T>\n```
//                             ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
//                                                           ^ definition local 0
//                                                             documentation ```cs\nT\n```
      {
          void Method<[Author("MethodTypeParameter")] T2>()
//             ^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#InnerClass#Method().
//                    documentation ```cs\nprivate void InnerClass<T>.Method<T2>()\n```
//                     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
//                                                    ^^ definition local 1
//                                                       documentation ```cs\nT2\n```
          {
          }
      }
  }

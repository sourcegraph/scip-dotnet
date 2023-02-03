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
//                              documentation ```cs\nclass Main.GlobalAttributes\n```
//                              relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
//                              relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                                ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
  {
      class AuthorAttribute : Attribute
//          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#
//                          documentation ```cs\nclass Main.GlobalAttributes.AuthorAttribute\n```
//                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
//                          relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                            ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Attribute#
      {
          public AuthorAttribute(string name)
//               ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
//                               documentation ```cs\npublic Main.GlobalAttributes.AuthorAttribute.AuthorAttribute(System.String name)\n```
//                                      ^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().(name)
//                                           documentation ```cs\nSystem.String name\n```
          {
          }
      }
  
      [Author("PropertyAttribute")] public int Z;
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
//                                             ^ definition scip-dotnet nuget . . Main/GlobalAttributes#Z.
//                                               documentation ```cs\npublic System.Int32 Main.GlobalAttributes.Z\n```
  
      [Author("MethodAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      int Method1()
//        ^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#Method1().
//                documentation ```cs\nprivate System.Int32 Main.GlobalAttributes.Method1()\n```
      {
          return 0;
      }
  
      [Author("EnumAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      enum A
//         ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#
//           documentation ```cs\nenum Main.GlobalAttributes.A\n```
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Enum#
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/ValueType#
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IComparable#
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IConvertible#
//           relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IFormattable#
      {
          B,
//        ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#B.
//          documentation ```cs\nMain.GlobalAttributes.A.B = 0\n```
          C
//        ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#C.
//          documentation ```cs\nMain.GlobalAttributes.A.C = 1\n```
      }
  
      [Author("EventAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      public event EventHandler SomeEvent
//                 ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#
//                              ^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#SomeEvent#
//                                        documentation ```cs\npublic event System.EventHandler Main.GlobalAttributes.SomeEvent\n```
      {
          add { }
          remove { }
      }
  
      [Author("TypeParameterAttribute")]
//     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      public class InnerClass<[Author("ClassTypeParameter")] T>
//                 ^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#InnerClass#
//                            documentation ```cs\nclass Main.GlobalAttributes.InnerClass<T>\n```
//                            relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
//                             ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
      {
          void Method<[Author("MethodTypeParameter")] T2>()
//             ^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#InnerClass#Method().
//                    documentation ```cs\nprivate void Main.GlobalAttributes.InnerClass<T>.Method<T2>()\n```
//                     ^^^^^^ reference scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#`.ctor`().
          {
          }
      }
  }

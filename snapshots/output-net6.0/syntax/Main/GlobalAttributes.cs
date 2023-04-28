  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
  public class GlobalAttributes : Attribute
//             ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#
//                              documentation ```cs\nclass GlobalAttributes\n```
//                              relationship implementation scip-dotnet nuget . . ``/Attribute#
  {
      class AuthorAttribute : Attribute
//          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#AuthorAttribute#
//                          documentation ```cs\nclass AuthorAttribute\n```
//                          relationship implementation scip-dotnet nuget . . ``/Attribute#
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
//                                             ^ definition scip-dotnet nuget . . Main/GlobalAttributes#Z.
//                                               documentation ```cs\npublic int GlobalAttributes.Z\n```

      [Author("MethodAttribute")]
      int Method1()
//        ^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#Method1().
//                documentation ```cs\nprivate int GlobalAttributes.Method1()\n```
      {
          return 0;
      }

      [Author("EnumAttribute")]
      enum A
//         ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#
//           documentation ```cs\nenum A\n```
      {
          B,
//        ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#B.
//          documentation ```cs\nA.B = 0\n```
          C
//        ^ definition scip-dotnet nuget . . Main/GlobalAttributes#A#C.
//          documentation ```cs\nA.C = 1\n```
      }

      [Author("EventAttribute")]
      public event EventHandler SomeEvent
//                              ^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#SomeEvent#
//                                        documentation ```cs\npublic event EventHandler GlobalAttributes.SomeEvent\n```
      {
          add { }
          remove { }
      }

      [Author("TypeParameterAttribute")]
      public class InnerClass<[Author("ClassTypeParameter")] T>
//                 ^^^^^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#InnerClass#
//                            documentation ```cs\nclass InnerClass<T>\n```
      {
          void Method<[Author("MethodTypeParameter")] T2>()
//             ^^^^^^ definition scip-dotnet nuget . . Main/GlobalAttributes#InnerClass#Method().
//                    documentation ```cs\nprivate void InnerClass<T>.Method<T2>()\n```
          {
          }
      }
  }

  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  public class Fields
//             ^^^^^^ definition scip-dotnet nuget . . Main/Fields#
//                    documentation ```cs\nclass Fields\n```
  {
      class Fields1
//          ^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#
//                  documentation ```cs\nclass Fields1\n```
      {
          private readonly int Property1;
//                             ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property1.
//                                       documentation ```cs\nprivate readonly int Fields1.Property1\n```
          private Int64 Property2, Property3;
//                      ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property2.
//                                documentation ```cs\nprivate Int64 Fields1.Property2\n```
//                                 ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property3.
//                                           documentation ```cs\nprivate Int64 Fields1.Property3\n```
          private Tuple<char, Nullable<int>> Property4;
//                                           ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property4.
//                                                     documentation ```cs\nprivate Tuple<char, Nullable<int>> Fields1.Property4\n```

          public Fields1(long field2, long field3, Tuple<char, int?> field4, int field1)
//               ^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().
//                       documentation ```cs\npublic Fields1.Fields1(long field2, long field3, Tuple<char, int?> field4, int field1)\n```
//                            ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field2)
//                                   documentation ```cs\nlong field2\n```
//                                         ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field3)
//                                                documentation ```cs\nlong field3\n```
//                                                                   ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field4)
//                                                                          documentation ```cs\nTuple<char, int?> field4\n```
//                                                                               ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field1)
//                                                                                      documentation ```cs\nint field1\n```
          {
              Property2 = field2;
//            ^^^^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#Property2.
//                        ^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field2)
              Property3 = field3;
//            ^^^^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#Property3.
//                        ^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field3)
              Property4 = field4;
//            ^^^^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#Property4.
//                        ^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field4)
              Property1 = field1;
//            ^^^^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#Property1.
//                        ^^^^^^ reference scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field1)
          }
      }

      class Fields2
//          ^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields2#
//                  documentation ```cs\nclass Fields2\n```
      {
          // Function pointer equivalent without calling convention
          unsafe delegate*<string, int> a;
//                                      ^ definition scip-dotnet nuget . . Main/Fields#Fields2#a.
//                                        documentation ```cs\nprivate delegate*<string, int> Fields2.a\n```
          unsafe delegate*<delegate*<in string, int>, delegate*<ref string, ref readonly int>> b;
//                                                                                             ^ definition scip-dotnet nuget . . Main/Fields#Fields2#b.
//                                                                                               documentation ```cs\nprivate delegate*<delegate*<in string, int>, delegate*<ref string, ref readonly int>> Fields2.b\n```

          // Function pointer equivalent with calling convention
          unsafe delegate* managed<string, int> c;
//                                              ^ definition scip-dotnet nuget . . Main/Fields#Fields2#c.
//                                                documentation ```cs\nprivate delegate*<string, int> Fields2.c\n```
      }
  }

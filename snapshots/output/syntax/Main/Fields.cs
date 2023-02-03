  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Fields
//             ^^^^^^ definition scip-dotnet nuget . . Main/Fields#
//                    documentation ```cs\nclass Main.Fields\n```
//                    relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
  {
      class Fields1
//          ^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#
//                  documentation ```cs\nclass Main.Fields.Fields1\n```
//                  relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
      {
          private readonly int Property1;
//                             ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property1.
//                                       documentation ```cs\nprivate readonly System.Int32 Main.Fields.Fields1.Property1\n```
          private Int64 Property2, Property3;
//                ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int64#
//                      ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property2.
//                                documentation ```cs\nprivate System.Int64 Main.Fields.Fields1.Property2\n```
//                                 ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property3.
//                                           documentation ```cs\nprivate System.Int64 Main.Fields.Fields1.Property3\n```
          private Tuple<char, Nullable<int>> Property4;
//                                           ^^^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#Property4.
//                                                     documentation ```cs\nprivate System.Tuple<System.Char, System.Nullable<System.Int32>> Main.Fields.Fields1.Property4\n```
  
          public Fields1(long field2, long field3, Tuple<char, int?> field4, int field1)
//               ^^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().
//                       documentation ```cs\npublic Main.Fields.Fields1.Fields1(System.Int64 field2, System.Int64 field3, System.Tuple<System.Char, System.Nullable<System.Int32>> field4, System.Int32 field1)\n```
//                            ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field2)
//                                   documentation ```cs\nSystem.Int64 field2\n```
//                                         ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field3)
//                                                documentation ```cs\nSystem.Int64 field3\n```
//                                                                   ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field4)
//                                                                          documentation ```cs\nSystem.Tuple<System.Char, System.Nullable<System.Int32>> field4\n```
//                                                                               ^^^^^^ definition scip-dotnet nuget . . Main/Fields#Fields1#`.ctor`().(field1)
//                                                                                      documentation ```cs\nSystem.Int32 field1\n```
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
//                  documentation ```cs\nclass Main.Fields.Fields2\n```
//                  relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
      {
          // Function pointer equivalent without calling convention
          unsafe delegate*<string, int> a;
//                                      ^ definition scip-dotnet nuget . . Main/Fields#Fields2#a.
//                                        documentation ```cs\nprivate delegate*<System.String, System.Int32> Main.Fields.Fields2.a\n```
          unsafe delegate*<delegate*<in string, int>, delegate*<ref string, ref readonly int>> b;
//                                                                                             ^ definition scip-dotnet nuget . . Main/Fields#Fields2#b.
//                                                                                               documentation ```cs\nprivate delegate*<delegate*<in System.String, System.Int32>, delegate*<ref System.String, ref readonly System.Int32>> Main.Fields.Fields2.b\n```
  
          // Function pointer equivalent with calling convention
          unsafe delegate* managed<string, int> c;
//                                              ^ definition scip-dotnet nuget . . Main/Fields#Fields2#c.
//                                                documentation ```cs\nprivate delegate*<System.String, System.Int32> Main.Fields.Fields2.c\n```
      }
  }

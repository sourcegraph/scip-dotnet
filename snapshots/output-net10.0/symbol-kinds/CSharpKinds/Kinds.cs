  namespace SymbolKinds
//          ^^^^^^^^^^^ reference scip-dotnet nuget . . SymbolKinds/
  {
      public interface IShape
//                     ^^^^^^ definition scip-dotnet nuget . . SymbolKinds/IShape#
//                            documentation ```cs\ninterface IShape\n```
      {
      }

      public struct Point
//                  ^^^^^ definition scip-dotnet nuget . . SymbolKinds/Point#
//                        documentation ```cs\nstruct Point\n```
      {
      }

      public enum Color
//                ^^^^^ definition scip-dotnet nuget . . SymbolKinds/Color#
//                      documentation ```cs\nenum Color\n```
//                      relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IComparable#
//                      relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IConvertible#
//                      relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/ISpanFormattable#
//                      relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IFormattable#
      {
          Red
//        ^^^ definition scip-dotnet nuget . . SymbolKinds/Color#Red.
//            documentation ```cs\nColor.Red = 0\n```
      }

      public delegate void Handler();
//                         ^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Handler#
//                                 documentation ```cs\ndelegate void Handler()\n```
//                                 relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/MulticastDelegate#
//                                 relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/Delegate#
//                                 relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/ICloneable#
//                                 relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 Serialization/ISerializable#

      public class Kinds
//                 ^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#
//                       documentation ```cs\nclass Kinds\n```
      {
          public const int Constant = 1;
//                         ^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#Constant.
//                                  documentation ```cs\npublic const int Kinds.Constant = 1\n```
          public int Field;
//                   ^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#Field.
//                         documentation ```cs\npublic int Kinds.Field\n```
          public static int StaticField;
//                          ^^^^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#StaticField.
//                                      documentation ```cs\npublic static int Kinds.StaticField\n```

          public Kinds()
//               ^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#`.ctor`().
//                     documentation ```cs\npublic Kinds.Kinds()\n```
          {
          }

          public int Property { get; set; }
//                   ^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#Property.
//                            documentation ```cs\npublic int Kinds.Property { get; set; }\n```
          public static int StaticProperty { get; set; }
//                          ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#StaticProperty.
//                                         documentation ```cs\npublic static int Kinds.StaticProperty { get; set; }\n```

          public event Handler? Event;
//                     ^^^^^^^ reference scip-dotnet nuget . . SymbolKinds/Handler#
//                              ^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#Event#
//                                    documentation ```cs\npublic event Handler? Kinds.Event\n```
          public static event Handler? StaticEvent;
//                            ^^^^^^^ reference scip-dotnet nuget . . SymbolKinds/Handler#
//                                     ^^^^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#StaticEvent#
//                                                 documentation ```cs\npublic static event Handler? Kinds.StaticEvent\n```

          public void Method()
//                    ^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#Method().
//                           documentation ```cs\npublic void Kinds.Method()\n```
          {
          }

          public static void StaticMethod()
//                           ^^^^^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/Kinds#StaticMethod().
//                                        documentation ```cs\npublic static void Kinds.StaticMethod()\n```
          {
          }
      }

      public static class KindsExtensions
//                        ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/KindsExtensions#
//                                        documentation ```cs\nclass KindsExtensions\n```
      {
          public static void Extension(this Kinds kinds)
//                           ^^^^^^^^^ definition scip-dotnet nuget . . SymbolKinds/KindsExtensions#Extension().
//                                     documentation ```cs\npublic void Kinds.Extension()\n```
//                                          ^^^^^ reference scip-dotnet nuget . . SymbolKinds/Kinds#
//                                                ^^^^^ definition scip-dotnet nuget . . SymbolKinds/KindsExtensions#Extension().(kinds)
//                                                      documentation ```cs\nKinds kinds\n```
          {
          }
      }
  }

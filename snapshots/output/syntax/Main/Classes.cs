  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Classes
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#
//                     documentation ```cs\nclass Main.Classes\n```
//                     relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
  {
      public string Name;
//                  ^^^^ definition scip-dotnet nuget . . Main/Classes#Name.
//                       documentation ```cs\npublic System.String Main.Classes.Name\n```
      public const int IntConstant = 1;
//                     ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#IntConstant.
//                                 documentation ```cs\npublic const System.Int32 Main.Classes.IntConstant = 1\n```
      public const string StringConstant = $"hello";
//                        ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#StringConstant.
//                                       documentation ```cs\npublic const System.String Main.Classes.StringConstant = "hello"\n```
  
      public Classes(int name)
//           ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`().
//                   documentation ```cs\npublic Main.Classes.Classes(System.Int32 name)\n```
//                       ^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`().(name)
//                            documentation ```cs\nSystem.Int32 name\n```
      {
          Name = "name";
//        ^^^^ reference scip-dotnet nuget . . Main/Classes#Name.
      }
  
      public Classes(string name) => Name = name;
//           ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`(+1).
//                   documentation ```cs\npublic Main.Classes.Classes(System.String name)\n```
//                          ^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`(+1).(name)
//                               documentation ```cs\nSystem.String name\n```
//                                   ^^^^ reference scip-dotnet nuget . . Main/Classes#Name.
//                                          ^^^^ reference scip-dotnet nuget . . Main/Classes#`.ctor`(+1).(name)
  
      ~Classes()
//     ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#Finalize().
//             documentation ```cs\nprotected Main.Classes.~Classes()\n```
      {
          Console.WriteLine(42);
//        ^^^^^^^ reference scip-dotnet nuget System.Console 6.0.0.0 System/Console#
//                ^^^^^^^^^ reference scip-dotnet nuget System.Console 6.0.0.0 System/Console#WriteLine(+7).
      }
  
  
      public class ObjectClass : object, SomeInterface
//                 ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ObjectClass#
//                             documentation ```cs\nclass Main.Classes.ObjectClass\n```
//                             relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                             relationship implementation scip-dotnet nuget . . Main/SomeInterface#
//                                       ^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/SomeInterface#
      {
      }
  
      public partial class PartialClass
//                         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#PartialClass#
//                                      documentation ```cs\nclass Main.Classes.PartialClass\n```
//                                      relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
      {
      }
  
      class TypeParameterClass<T>
//          ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#TypeParameterClass#
//                             documentation ```cs\nclass Main.Classes.TypeParameterClass<T>\n```
//                             relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
      {
      }
  
      internal class InternalMultipleTypeParametersClass<T1, T2>
//                   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#InternalMultipleTypeParametersClass#
//                                                       documentation ```cs\nclass Main.Classes.InternalMultipleTypeParametersClass<T1, T2>\n```
//                                                       relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
      {
      }
  
      interface ICovariantContravariant<in T1, out T2>
//              ^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#
//                                      documentation ```cs\ninterface Main.Classes.ICovariantContravariant<in T1, out T2>\n```
      {
          public void Method1(T1 t1)
//                    ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method1().
//                            documentation ```cs\nvoid Main.Classes.ICovariantContravariant<in T1, out T2>.Method1(T1 t1)\n```
//                            ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#[T1]
//                               ^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method1().(t1)
//                                  documentation ```cs\nT1 t1\n```
          {
              Console.WriteLine(t1);
//            ^^^^^^^ reference scip-dotnet nuget System.Console 6.0.0.0 System/Console#
//                    ^^^^^^^^^ reference scip-dotnet nuget System.Console 6.0.0.0 System/Console#WriteLine(+9).
//                              ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method1().(t1)
          }
  
          public T2? Method2()
//               ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#[T2]
//                   ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method2().
//                           documentation ```cs\nT2 Main.Classes.ICovariantContravariant<in T1, out T2>.Method2()\n```
          {
              return default(T2);
//                           ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#[T2]
          }
      }
  
      public class StructConstraintClass<T> where T : struct
//                 ^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#StructConstraintClass#
//                                       documentation ```cs\nclass Main.Classes.StructConstraintClass<T> where T : struct\n```
//                                       relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                                                ^ reference scip-dotnet nuget . . Main/Classes#StructConstraintClass#[T]
      {
      }
  
      public class UnmanagedConstraintClass<T> where T : unmanaged
//                 ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#UnmanagedConstraintClass#
//                                          documentation ```cs\nclass Main.Classes.UnmanagedConstraintClass<T> where T : unmanaged\n```
//                                          relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                                                   ^ reference scip-dotnet nuget . . Main/Classes#UnmanagedConstraintClass#[T]
      {
      }
  
      public class ClassConstraintClass<T> where T : class
//                 ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ClassConstraintClass#
//                                      documentation ```cs\nclass Main.Classes.ClassConstraintClass<T> where T : class\n```
//                                      relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                                               ^ reference scip-dotnet nuget . . Main/Classes#ClassConstraintClass#[T]
      {
      }
  
      public class NonNullableConstraintClass<T> where T : notnull
//                 ^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#NonNullableConstraintClass#
//                                            documentation ```cs\nclass Main.Classes.NonNullableConstraintClass<T> where T : notnull\n```
//                                            relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                                                     ^ reference scip-dotnet nuget . . Main/Classes#NonNullableConstraintClass#[T]
      {
      }
  
      public class NewConstraintClass<T> where T : new()
//                 ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#NewConstraintClass#
//                                    documentation ```cs\nclass Main.Classes.NewConstraintClass<T> where T : new()\n```
//                                    relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                                             ^ reference scip-dotnet nuget . . Main/Classes#NewConstraintClass#[T]
      {
      }
  
      public class TypeParameterConstraintClass<T> where T : SomeInterface
//                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#TypeParameterConstraintClass#
//                                              documentation ```cs\nclass Main.Classes.TypeParameterConstraintClass<T> where T : Main.SomeInterface\n```
//                                              relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                                                       ^ reference scip-dotnet nuget . . Main/Classes#TypeParameterConstraintClass#[T]
//                                                           ^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/SomeInterface#
      {
      }
  
      private class MultipleTypeParameterConstraintsClass<T1, T2> where T1 : SomeInterface, SomeInterface2, new()
//                  ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#MultipleTypeParameterConstraintsClass#
//                                                        documentation ```cs\nclass Main.Classes.MultipleTypeParameterConstraintsClass<T1, T2> where T1 : Main.SomeInterface, Main.SomeInterface2, new() where T2 : Main.SomeInterface2\n```
//                                                        relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                                                                      ^^ reference scip-dotnet nuget . . Main/Classes#MultipleTypeParameterConstraintsClass#[T1]
//                                                                           ^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/SomeInterface#
//                                                                                          ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/SomeInterface2#
          where T2 : SomeInterface2
//              ^^ reference scip-dotnet nuget . . Main/Classes#MultipleTypeParameterConstraintsClass#[T2]
//                   ^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/SomeInterface2#
      {
      }
  
      class IndexClass
//          ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#IndexClass#
//                     documentation ```cs\nclass Main.Classes.IndexClass\n```
//                     relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
      {
          private bool a;
//                     ^ definition scip-dotnet nuget . . Main/Classes#IndexClass#a.
//                       documentation ```cs\nprivate System.Boolean Main.Classes.IndexClass.a\n```
  
          public bool this[int index]
//                             ^^^^^ definition scip-dotnet nuget . . Main/Classes#IndexClass#`this[]`.(index)
//                                   documentation ```cs\nSystem.Int32 index\n```
          {
              get { return a; }
//                         ^ reference scip-dotnet nuget . . Main/Classes#IndexClass#a.
              set { a = value; }
//                  ^ reference scip-dotnet nuget . . Main/Classes#IndexClass#a.
//                      ^^^^^ reference scip-dotnet nuget . . Main/Classes#IndexClass#set_Item().(value)
          }
      }
  
  }
  
  public interface SomeInterface
//                 ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/SomeInterface#
//                               documentation ```cs\ninterface Main.SomeInterface\n```
  {
  }
  
  internal interface SomeInterface2
//                   ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/SomeInterface2#
//                                  documentation ```cs\ninterface Main.SomeInterface2\n```
  {
  }

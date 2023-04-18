  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  public class Classes
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#
//                     documentation ```cs\nclass Classes\n```
  {
      public string Name;
//                  ^^^^ definition scip-dotnet nuget . . Main/Classes#Name.
//                       documentation ```cs\npublic string Classes.Name\n```
      public const int IntConstant = 1;
//                     ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#IntConstant.
//                                 documentation ```cs\npublic const int Classes.IntConstant\n```
      public const string StringConstant = $"hello";
//                        ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#StringConstant.
//                                       documentation ```cs\npublic const string Classes.StringConstant\n```

      public Classes(int name)
//           ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`().
//                   documentation ```cs\npublic Classes.Classes(int name)\n```
//                       ^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`().(name)
//                            documentation ```cs\nint name\n```
      {
          Name = "name";
//        ^^^^ reference scip-dotnet nuget . . Main/Classes#Name.
      }

      public Classes(string name) => Name = name;
//           ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`(+1).
//                   documentation ```cs\npublic Classes.Classes(string name)\n```
//                          ^^^^ definition scip-dotnet nuget . . Main/Classes#`.ctor`(+1).(name)
//                               documentation ```cs\nstring name\n```
//                                   ^^^^ reference scip-dotnet nuget . . Main/Classes#Name.
//                                          ^^^^ reference scip-dotnet nuget . . Main/Classes#`.ctor`(+1).(name)

      ~Classes()
//     ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#Finalize().
//             documentation ```cs\nprotected Classes.~Classes()\n```
      {
          Console.WriteLine(42);
      }


      public class ObjectClass : object, SomeInterface
//                 ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ObjectClass#
//                             documentation ```cs\nclass ObjectClass\n```
//                             relationship implementation scip-dotnet nuget . . Main/SomeInterface#
//                                       ^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/SomeInterface#
      {
      }

      public partial class PartialClass
//                         ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#PartialClass#
//                                      documentation ```cs\nclass PartialClass\n```
      {
      }

      class TypeParameterClass<T>
//          ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#TypeParameterClass#
//                             documentation ```cs\nclass TypeParameterClass<T>\n```
      {
      }

      internal class InternalMultipleTypeParametersClass<T1, T2>
//                   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#InternalMultipleTypeParametersClass#
//                                                       documentation ```cs\nclass InternalMultipleTypeParametersClass<T1, T2>\n```
      {
      }

      interface ICovariantContravariant<in T1, out T2>
//              ^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#
//                                      documentation ```cs\ninterface ICovariantContravariant<in T1, out T2>\n```
      {
          public void Method1(T1 t1)
//                    ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method1().
//                            documentation ```cs\nvoid ICovariantContravariant<in T1, out T2>.Method1(T1 t1)\n```
//                            ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#[T1]
//                               ^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method1().(t1)
//                                  documentation ```cs\nT1 t1\n```
          {
              Console.WriteLine(t1);
//                              ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method1().(t1)
          }

          public T2? Method2()
//               ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#[T2]
//                   ^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ICovariantContravariant#Method2().
//                           documentation ```cs\nT2? ICovariantContravariant<in T1, out T2>.Method2()\n```
          {
              return default(T2);
//                           ^^ reference scip-dotnet nuget . . Main/Classes#ICovariantContravariant#[T2]
          }
      }

      public class StructConstraintClass<T> where T : struct
//                 ^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#StructConstraintClass#
//                                       documentation ```cs\nclass StructConstraintClass<T> where T : struct\n```
//                                                ^ reference scip-dotnet nuget . . Main/Classes#StructConstraintClass#[T]
      {
      }

      public class UnmanagedConstraintClass<T> where T : unmanaged
//                 ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#UnmanagedConstraintClass#
//                                          documentation ```cs\nclass UnmanagedConstraintClass<T> where T : unmanaged\n```
//                                                   ^ reference scip-dotnet nuget . . Main/Classes#UnmanagedConstraintClass#[T]
      {
      }

      public class ClassConstraintClass<T> where T : class
//                 ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#ClassConstraintClass#
//                                      documentation ```cs\nclass ClassConstraintClass<T> where T : class\n```
//                                               ^ reference scip-dotnet nuget . . Main/Classes#ClassConstraintClass#[T]
      {
      }

      public class NonNullableConstraintClass<T> where T : notnull
//                 ^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#NonNullableConstraintClass#
//                                            documentation ```cs\nclass NonNullableConstraintClass<T> where T : notnull\n```
//                                                     ^ reference scip-dotnet nuget . . Main/Classes#NonNullableConstraintClass#[T]
      {
      }

      public class NewConstraintClass<T> where T : new()
//                 ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#NewConstraintClass#
//                                    documentation ```cs\nclass NewConstraintClass<T> where T : new()\n```
//                                             ^ reference scip-dotnet nuget . . Main/Classes#NewConstraintClass#[T]
      {
      }

      public class TypeParameterConstraintClass<T> where T : SomeInterface
//                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#TypeParameterConstraintClass#
//                                              documentation ```cs\nclass TypeParameterConstraintClass<T> where T : SomeInterface\n```
//                                                       ^ reference scip-dotnet nuget . . Main/Classes#TypeParameterConstraintClass#[T]
//                                                           ^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/SomeInterface#
      {
      }

      private class MultipleTypeParameterConstraintsClass<T1, T2> where T1 : SomeInterface, SomeInterface2, new()
//                  ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Classes#MultipleTypeParameterConstraintsClass#
//                                                        documentation ```cs\nclass MultipleTypeParameterConstraintsClass<T1, T2> where T1 : SomeInterface, SomeInterface2, new() where T2 : SomeInterface2\n```
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
//                     documentation ```cs\nclass IndexClass\n```
      {
          private bool a;
//                     ^ definition scip-dotnet nuget . . Main/Classes#IndexClass#a.
//                       documentation ```cs\nprivate bool IndexClass.a\n```

          public bool this[int index]
//                             ^^^^^ definition scip-dotnet nuget . . Main/Classes#IndexClass#`this[]`.(index)
//                                   documentation ```cs\nint index\n```
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
//                               documentation ```cs\ninterface SomeInterface\n```
  {
  }

  internal interface SomeInterface2
//                   ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/SomeInterface2#
//                                  documentation ```cs\ninterface SomeInterface2\n```
  {
  }

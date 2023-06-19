  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  public class Methods
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Methods#
//                     documentation ```cs\nclass Methods\n```
  {
      int SingleParameter(int b)
//        ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#SingleParameter().
//                        documentation ```cs\nprivate int Methods.SingleParameter(int b)\n```
//                            ^ definition scip-dotnet nuget . . Main/Methods#SingleParameter().(b)
//                              documentation ```cs\nint b\n```
      {
          return b;
//               ^ reference scip-dotnet nuget . . Main/Methods#SingleParameter().(b)
      }

      int TwoParameters(int a, int b)
//        ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#TwoParameters().
//                      documentation ```cs\nprivate int Methods.TwoParameters(int a, int b)\n```
//                          ^ definition scip-dotnet nuget . . Main/Methods#TwoParameters().(a)
//                            documentation ```cs\nint a\n```
//                                 ^ definition scip-dotnet nuget . . Main/Methods#TwoParameters().(b)
//                                   documentation ```cs\nint b\n```
      {
          return a + b;
//               ^ reference scip-dotnet nuget . . Main/Methods#TwoParameters().(a)
//                   ^ reference scip-dotnet nuget . . Main/Methods#TwoParameters().(b)
      }

      int Overload1(int a)
//        ^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#Overload1().
//                  documentation ```cs\nprivate int Methods.Overload1(int a)\n```
//                      ^ definition scip-dotnet nuget . . Main/Methods#Overload1().(a)
//                        documentation ```cs\nint a\n```
      {
          return a;
//               ^ reference scip-dotnet nuget . . Main/Methods#Overload1().(a)
      }

      int Overload1(int a, int b)
//        ^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#Overload1(+1).
//                  documentation ```cs\nprivate int Methods.Overload1(int a, int b)\n```
//                      ^ definition scip-dotnet nuget . . Main/Methods#Overload1(+1).(a)
//                        documentation ```cs\nint a\n```
//                             ^ definition scip-dotnet nuget . . Main/Methods#Overload1(+1).(b)
//                               documentation ```cs\nint b\n```
      {
          return a + b;
//               ^ reference scip-dotnet nuget . . Main/Methods#Overload1(+1).(a)
//                   ^ reference scip-dotnet nuget . . Main/Methods#Overload1(+1).(b)
      }

      T Generic<T>(T param)
//    ^ reference scip-dotnet nuget . . Main/Methods#Generic().[T]
//      ^^^^^^^ definition scip-dotnet nuget . . Main/Methods#Generic().
//              documentation ```cs\nprivate T Methods.Generic<T>(T param)\n```
//              ^ definition scip-dotnet nuget . . Main/Methods#Generic().[T]
//                documentation ```cs\nT\n```
//                 ^ reference scip-dotnet nuget . . Main/Methods#Generic().[T]
//                   ^^^^^ definition scip-dotnet nuget . . Main/Methods#Generic().(param)
//                         documentation ```cs\nT param\n```
      {
          return param;
//               ^^^^^ reference scip-dotnet nuget . . Main/Methods#Generic().(param)
      }

      T GenericConstraint<T>(T param) where T : new()
//    ^ reference scip-dotnet nuget . . Main/Methods#GenericConstraint().[T]
//      ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#GenericConstraint().
//                        documentation ```cs\nprivate T Methods.GenericConstraint<T>(T param) where T : new()\n```
//                        ^ definition scip-dotnet nuget . . Main/Methods#GenericConstraint().[T]
//                          documentation ```cs\nT\n```
//                           ^ reference scip-dotnet nuget . . Main/Methods#GenericConstraint().[T]
//                             ^^^^^ definition scip-dotnet nuget . . Main/Methods#GenericConstraint().(param)
//                                   documentation ```cs\nT param\n```
//                                          ^ reference scip-dotnet nuget . . Main/Methods#GenericConstraint().[T]
      {
          return param;
//               ^^^^^ reference scip-dotnet nuget . . Main/Methods#GenericConstraint().(param)
      }

      void DefaultParameter(int a = 5)
//         ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#DefaultParameter().
//                          documentation ```cs\nprivate void Methods.DefaultParameter([int a = 5])\n```
//                              ^ definition scip-dotnet nuget . . Main/Methods#DefaultParameter().(a)
//                                documentation ```cs\n[int a = 5]\n```
      {
      }

      int DefaultParameterOverload(int a = 5)
//        ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#DefaultParameterOverload().
//                                 documentation ```cs\nprivate int Methods.DefaultParameterOverload([int a = 5])\n```
//                                     ^ definition scip-dotnet nuget . . Main/Methods#DefaultParameterOverload().(a)
//                                       documentation ```cs\n[int a = 5]\n```
      {
          return DefaultParameterOverload(a, a);
//               ^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#DefaultParameterOverload(+1).
//                                        ^ reference scip-dotnet nuget . . Main/Methods#DefaultParameterOverload().(a)
//                                           ^ reference scip-dotnet nuget . . Main/Methods#DefaultParameterOverload().(a)
      }

      int DefaultParameterOverload(int a, int b)
//        ^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#DefaultParameterOverload(+1).
//                                 documentation ```cs\nprivate int Methods.DefaultParameterOverload(int a, int b)\n```
//                                     ^ definition scip-dotnet nuget . . Main/Methods#DefaultParameterOverload(+1).(a)
//                                       documentation ```cs\nint a\n```
//                                            ^ definition scip-dotnet nuget . . Main/Methods#DefaultParameterOverload(+1).(b)
//                                              documentation ```cs\nint b\n```
      {
          return DefaultParameterOverload();
//               ^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#DefaultParameterOverload().
      }

      interface IHello
//              ^^^^^^ definition scip-dotnet nuget . . Main/Methods#IHello#
//                     documentation ```cs\ninterface IHello\n```
      {
          string Hello();
//               ^^^^^ definition scip-dotnet nuget . . Main/Methods#IHello#Hello().
//                     documentation ```cs\nstring IHello.Hello()\n```
      }

      class ImplementsHello : IHello
//          ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#ImplementsHello#
//                          documentation ```cs\nclass ImplementsHello\n```
//                          relationship implementation scip-dotnet nuget . . Main/Methods#IHello#
//                            ^^^^^^ reference scip-dotnet nuget . . Main/Methods#IHello#
      {
          string IHello.Hello()
//               ^^^^^^ reference scip-dotnet nuget . . Main/Methods#IHello#
//                      ^^^^^ definition scip-dotnet nuget . . Main/Methods#ImplementsHello#`Main.Methods.IHello.Hello`().
//                            documentation ```cs\nprivate string ImplementsHello.IHello.Hello()\n```
//                            relationship implementation reference scip-dotnet nuget . . Main/Methods#IHello#Hello().
          {
              return "";
          }
      }

      class InheritedOverloads1
//          ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads1#
//                              documentation ```cs\nclass InheritedOverloads1\n```
      {
          public void Method()
//                    ^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads1#Method().
//                           documentation ```cs\npublic void InheritedOverloads1.Method()\n```
          {
          }
      }

      class InheritedOverloads2 : InheritedOverloads1
//          ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads2#
//                              documentation ```cs\nclass InheritedOverloads2\n```
//                              relationship implementation scip-dotnet nuget . . Main/Methods#InheritedOverloads1#
//                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads1#
      {
          public int Method(int parameter)
//                   ^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads2#Method().
//                          documentation ```cs\npublic int InheritedOverloads2.Method(int parameter)\n```
//                              ^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads2#Method().(parameter)
//                                        documentation ```cs\nint parameter\n```
          {
              return parameter;
//                   ^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads2#Method().(parameter)
          }
      }

      class InheritedOverloads3 : InheritedOverloads2
//          ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads3#
//                              documentation ```cs\nclass InheritedOverloads3\n```
//                              relationship implementation scip-dotnet nuget . . Main/Methods#InheritedOverloads2#
//                              relationship implementation scip-dotnet nuget . . Main/Methods#InheritedOverloads1#
//                                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads2#
      {
          public string Method(string parameter)
//                      ^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads3#Method().
//                             documentation ```cs\npublic string InheritedOverloads3.Method(string parameter)\n```
//                                    ^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads3#Method().(parameter)
//                                              documentation ```cs\nstring parameter\n```
          {
              return parameter;
//                   ^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads3#Method().(parameter)
          }
      }

      public static void InheritedOverloads()
//                       ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Methods#InheritedOverloads().
//                                          documentation ```cs\npublic static void Methods.InheritedOverloads()\n```
      {
          new InheritedOverloads1().Method();
//            ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads1#
//                                  ^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads1#Method().
          new InheritedOverloads2().Method();
//            ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads2#
//                                  ^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads1#Method().
          new InheritedOverloads2().Method(42);
//            ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads2#
//                                  ^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads2#Method().
          new InheritedOverloads3().Method();
//            ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads3#
//                                  ^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads1#Method().
          new InheritedOverloads3().Method(42);
//            ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads3#
//                                  ^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads2#Method().
          new InheritedOverloads3().Method("42");
//            ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads3#
//                                  ^^^^^^ reference scip-dotnet nuget . . Main/Methods#InheritedOverloads3#Method().
      }

  }

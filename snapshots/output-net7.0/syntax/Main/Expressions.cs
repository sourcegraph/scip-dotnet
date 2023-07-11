  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Expressions
//             ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#
//                         documentation ```cs\nclass Expressions\n```
  {
      void AssignmentToPrefixUnaryExpressions()
//         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#AssignmentToPrefixUnaryExpressions().
//                                            documentation ```cs\nprivate void Expressions.AssignmentToPrefixUnaryExpressions()\n```
      {
          var a = 42;
//            ^ definition local 0
//              documentation ```cs\nint a\n```
          var b = 42;
//            ^ definition local 1
//              documentation ```cs\nint b\n```
          a = +a;
//        ^ reference local 0
//             ^ reference local 0
          a = -a;
//        ^ reference local 0
//             ^ reference local 0
          a = ~a;
//        ^ reference local 0
//             ^ reference local 0
          a = ++a;
//        ^ reference local 0
//              ^ reference local 0
          a = --a;
//        ^ reference local 0
//              ^ reference local 0
          a = a++;
//        ^ reference local 0
//            ^ reference local 0
          a = a--;
//        ^ reference local 0
//            ^ reference local 0
          b = a!;
//        ^ reference local 1
//            ^ reference local 0

          var c = true;
//            ^ definition local 2
//              documentation ```cs\nbool c\n```
          c = !c;
//        ^ reference local 2
//             ^ reference local 2
      }

      void AssignmentToPrefixBinaryExpressions()
//         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#AssignmentToPrefixBinaryExpressions().
//                                             documentation ```cs\nprivate void Expressions.AssignmentToPrefixBinaryExpressions()\n```
      {
          var a = 42;
//            ^ definition local 3
//              documentation ```cs\nint a\n```
          a = a + a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a - a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a * a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a / a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a % a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a & a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a | a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a ^ a;
//        ^ reference local 3
//            ^ reference local 3
//                ^ reference local 3
          a = a >> a;
//        ^ reference local 3
//            ^ reference local 3
//                 ^ reference local 3
          a = a << a;
//        ^ reference local 3
//            ^ reference local 3
//                 ^ reference local 3
          a = a >>> a;
//        ^ reference local 3
//            ^ reference local 3
//                  ^ reference local 3
      }

      void AssignmentToBinaryEqualityExpression()
//         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#AssignmentToBinaryEqualityExpression().
//                                              documentation ```cs\nprivate void Expressions.AssignmentToBinaryEqualityExpression()\n```
      {
          var a = true;
//            ^ definition local 4
//              documentation ```cs\nbool a\n```
          var b = true;
//            ^ definition local 5
//              documentation ```cs\nbool b\n```
          var c = 42;
//            ^ definition local 6
//              documentation ```cs\nint c\n```
          var d = 42;
//            ^ definition local 7
//              documentation ```cs\nint d\n```
          a = a == b;
//        ^ reference local 4
//            ^ reference local 4
//                 ^ reference local 5
          a = a != b;
//        ^ reference local 4
//            ^ reference local 4
//                 ^ reference local 5
          a = c < d;
//        ^ reference local 4
//            ^ reference local 6
//                ^ reference local 7
          a = c <= d;
//        ^ reference local 4
//            ^ reference local 6
//                 ^ reference local 7
          a = c > d;
//        ^ reference local 4
//            ^ reference local 6
//                ^ reference local 7
          a = c >= d;
//        ^ reference local 4
//            ^ reference local 6
//                 ^ reference local 7
      }

      void AssignmentToBinaryExpression()
//         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#AssignmentToBinaryExpression().
//                                      documentation ```cs\nprivate void Expressions.AssignmentToBinaryExpression()\n```
      {
          var a = 42;
//            ^ definition local 8
//              documentation ```cs\nint a\n```
          a += a;
//        ^ reference local 8
//             ^ reference local 8
          a -= a;
//        ^ reference local 8
//             ^ reference local 8
          a *= a;
//        ^ reference local 8
//             ^ reference local 8
          a /= a;
//        ^ reference local 8
//             ^ reference local 8
          a %= a;
//        ^ reference local 8
//             ^ reference local 8
          a++;
//        ^ reference local 8
          a--;
//        ^ reference local 8
          a <<= a;
//        ^ reference local 8
//              ^ reference local 8
          a >>= a;
//        ^ reference local 8
//              ^ reference local 8
          a >>>= a;
//        ^ reference local 8
//               ^ reference local 8
      }

      struct Struct
//           ^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Struct#
//                  documentation ```cs\nstruct Struct\n```
      {
          public int Property;
//                   ^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Struct#Property.
//                            documentation ```cs\npublic int Struct.Property\n```
      }

      struct IndexedClass
//           ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#IndexedClass#
//                        documentation ```cs\nstruct IndexedClass\n```
      {
          public int Property;
//                   ^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#IndexedClass#Property.
//                            documentation ```cs\npublic int IndexedClass.Property\n```

          public int this[int index]
//                            ^^^^^ definition local 9
//                                  documentation ```cs\nint index\n```
          {
              get { return Property; }
//                         ^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IndexedClass#Property.
              set { Property = value; }
//                  ^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IndexedClass#Property.
//                             ^^^^^ reference local 10
          }
      }

      void AssignmentToLeftValueTypes()
//         ^^^^^^^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#AssignmentToLeftValueTypes().
//                                    documentation ```cs\nprivate void Expressions.AssignmentToLeftValueTypes()\n```
      {
          (var a, var b) = (1, 2);
//             ^ definition local 11
//               documentation ```cs\nint a\n```
//                    ^ definition local 12
//                      documentation ```cs\nint b\n```
          a = 1;
//        ^ reference local 11
          var c = new Struct { Property = 42 };
//            ^ definition local 13
//              documentation ```cs\nStruct c\n```
//                    ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Struct#
//                             ^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Struct#Property.
          c.Property = 1;
//        ^ reference local 13
//          ^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Struct#Property.
          var d = new IndexedClass();
//            ^ definition local 14
//              documentation ```cs\nIndexedClass d\n```
//                    ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IndexedClass#
          d[b] = 1;
//        ^ reference local 14
//          ^ reference local 12
          (a, b) = (1, 2);
//         ^ reference local 11
//            ^ reference local 12
          var x = new IndexedClass
//            ^ definition local 15
//              documentation ```cs\nIndexedClass x\n```
//                    ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IndexedClass#
          {
              Property = 1,
//            ^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IndexedClass#Property.
              [b] = 1
//             ^ reference local 12
          };
          (a) = 1;
//         ^ reference local 11
          unsafe
          {
              int myInt = 5;
//                ^^^^^ definition local 16
//                      documentation ```cs\nint myInt\n```
              int* p = &myInt;
//                 ^ definition local 17
//                   documentation ```cs\nint* p\n```
//                      ^^^^^ reference local 16
              Console.WriteLine("myInt = {0}, *p = {1}", myInt, *p);
//            ^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#
//                    ^^^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#WriteLine(+13).
//                                                       ^^^^^ reference local 16
//                                                               ^ reference local 17
          }
      }

      void TernaryExpression()
//         ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TernaryExpression().
//                           documentation ```cs\nprivate void Expressions.TernaryExpression()\n```
      {
          var x = true;
//            ^ definition local 18
//              documentation ```cs\nbool x\n```
          var y = x ? "foo" : "bar";
//            ^ definition local 19
//              documentation ```cs\nstring? y\n```
//                ^ reference local 18
          object z = true;
//               ^ definition local 20
//                 documentation ```cs\nobject z\n```
          var t = z is bool ? 42 : 41;
//            ^ definition local 21
//              documentation ```cs\nint t\n```
//                ^ reference local 20
      }

      class Cast
//          ^^^^ definition scip-dotnet nuget . . Main/Expressions#Cast#
//               documentation ```cs\nclass Cast\n```
      {
          public Cast nested;
//               ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//                    ^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Cast#nested.
//                           documentation ```cs\npublic Cast Cast.nested\n```
          public Cast2 nested2;
//               ^^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#Cast2#
//                     ^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Cast#nested2.
//                             documentation ```cs\npublic Cast2 Cast.nested2\n```

          public Cast plus(Cast other)
//               ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//                    ^^^^ definition scip-dotnet nuget . . Main/Expressions#Cast#plus().
//                         documentation ```cs\npublic Cast Cast.plus(Cast other)\n```
//                         ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//                              ^^^^^ definition local 22
//                                    documentation ```cs\nCast other\n```
          {
              nested = other;
//            ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#nested.
//                     ^^^^^ reference local 22
              return this;
          }

          public class Cast2
//                     ^^^^^ definition scip-dotnet nuget . . Main/Expressions#Cast#Cast2#
//                           documentation ```cs\nclass Cast2\n```
          {
          }
      }

      int CastExpressions()
//        ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#CastExpressions().
//                        documentation ```cs\nprivate int Expressions.CastExpressions()\n```
      {
          object a = new Cast();
//               ^ definition local 23
//                 documentation ```cs\nobject a\n```
//                       ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
          object b = new Cast();
//               ^ definition local 24
//                 documentation ```cs\nobject b\n```
//                       ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
          Cast c = ((Cast)a).plus((Cast)b);
//        ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//             ^ definition local 25
//               documentation ```cs\nCast c\n```
//                   ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//                        ^ reference local 23
//                           ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#plus().
//                                 ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//                                      ^ reference local 24
          Cast d = (Cast)new object[] { a, b }[0];
//        ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//             ^ definition local 26
//               documentation ```cs\nCast d\n```
//                  ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//                                      ^ reference local 23
//                                         ^ reference local 24
          var e = (Cast.Cast2)(c.nested.nested2);
//            ^ definition local 27
//              documentation ```cs\nCast2? e\n```
//                 ^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#
//                      ^^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#Cast2#
//                             ^ reference local 25
//                               ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#nested.
//                                      ^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Cast#nested2.
          var f = (Int32)(1);
//            ^ definition local 28
//              documentation ```cs\nint f\n```
//                 ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int32#
          var g = (Int32)(1);
//            ^ definition local 29
//              documentation ```cs\nint g\n```
//                 ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int32#
          var h = (Int32)((1));
//            ^ definition local 30
//              documentation ```cs\nint h\n```
//                 ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int32#
          return f + g + h;
//               ^ reference local 28
//                   ^ reference local 29
//                       ^ reference local 30
      }

      object AnonymousObject()
//           ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#AnonymousObject().
//                           documentation ```cs\nprivate object Expressions.AnonymousObject()\n```
      {
          var x = new { Helper = "" };
//            ^ definition local 31
//              documentation ```cs\n<anonymous type: string Helper>? x\n```
//                      ^^^^^^ reference local 33
          var y = new
//            ^ definition local 34
//              documentation ```cs\n<anonymous type: AnonymousType <anonymous type: string Helper> x>? y\n```
          {
              x
//            ^ reference local 31
          };
          return y.x.Helper;
//               ^ reference local 34
//                 ^ reference local 36
//                   ^^^^^^ reference local 33
      }

      class TargetType
//          ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TargetType#
//                     documentation ```cs\nclass TargetType\n```
      {
          public TargetType(string name)
//               ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TargetType#`.ctor`().
//                          documentation ```cs\npublic TargetType.TargetType(string name)\n```
//                                 ^^^^ definition local 37
//                                      documentation ```cs\nstring name\n```
          {
          }
      }

      TargetType TargetTypeNew()
//    ^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#TargetType#
//               ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TargetTypeNew().
//                             documentation ```cs\nprivate TargetType Expressions.TargetTypeNew()\n```
      {
          TargetType x = new("x");
//        ^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#TargetType#
//                   ^ definition local 38
//                     documentation ```cs\nTargetType x\n```
          return x;
//               ^ reference local 38
      }

      int Checked()
//        ^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Checked().
//                documentation ```cs\nprivate int Expressions.Checked()\n```
      {
          var three = checked(1 + 2);
//            ^^^^^ definition local 39
//                  documentation ```cs\nint three\n```
          return three;
//               ^^^^^ reference local 39
      }

      class ObjectCreationClass
//          ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#
//                              documentation ```cs\nclass ObjectCreationClass\n```
      {
          public D field;
//               ^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#D#
//                 ^^^^^ definition scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#field.
//                       documentation ```cs\npublic D ObjectCreationClass.field\n```

          public ObjectCreationClass(D field)
//               ^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#`.ctor`().
//                                   documentation ```cs\npublic ObjectCreationClass.ObjectCreationClass(D field)\n```
//                                   ^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#D#
//                                     ^^^^^ definition local 40
//                                           documentation ```cs\nD field\n```
          {
              this.field = field;
//                 ^^^^^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#field.
//                         ^^^^^ reference local 40
          }

          public class D
//                     ^ definition scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#D#
//                       documentation ```cs\nclass D\n```
          {
              public D(int a, string b)
//                   ^ definition scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#D#`.ctor`().
//                     documentation ```cs\npublic D.D(int a, string b)\n```
//                         ^ definition local 41
//                           documentation ```cs\nint a\n```
//                                   ^ definition local 42
//                                     documentation ```cs\nstring b\n```
              {
              }
          }
      }

      void ObjectCreation()
//         ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#ObjectCreation().
//                        documentation ```cs\nprivate void Expressions.ObjectCreation()\n```
      {
          var a = new ObjectCreationClass.D(1, "hi");
//            ^ definition local 43
//              documentation ```cs\nD? a\n```
//                    ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#
//                                        ^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#D#
          var b = new ObjectCreationClass(a)
//            ^ definition local 44
//              documentation ```cs\nObjectCreationClass? b\n```
//                    ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#
//                                        ^ reference local 43
          {
              field = a,
//            ^^^^^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#field.
//                    ^ reference local 43
          };
          b = new ObjectCreationClass(a);
//        ^ reference local 44
//                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#
//                                    ^ reference local 43
          b = new ObjectCreationClass(a) { };
//        ^ reference local 44
//                ^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#ObjectCreationClass#
//                                    ^ reference local 43
      }

      class NamedParametersClass
//          ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#NamedParametersClass#
//                               documentation ```cs\nclass NamedParametersClass\n```
      {
          public int A;
//                   ^ definition scip-dotnet nuget . . Main/Expressions#NamedParametersClass#A.
//                     documentation ```cs\npublic int NamedParametersClass.A\n```
          public string B;
//                      ^ definition scip-dotnet nuget . . Main/Expressions#NamedParametersClass#B.
//                        documentation ```cs\npublic string NamedParametersClass.B\n```

          public NamedParametersClass(int a, string b)
//               ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#NamedParametersClass#`.ctor`().
//                                    documentation ```cs\npublic NamedParametersClass.NamedParametersClass(int a, string b)\n```
//                                        ^ definition local 45
//                                          documentation ```cs\nint a\n```
//                                                  ^ definition local 46
//                                                    documentation ```cs\nstring b\n```
          {
              A = a;
//            ^ reference scip-dotnet nuget . . Main/Expressions#NamedParametersClass#A.
//                ^ reference local 45
              B = b;
//            ^ reference scip-dotnet nuget . . Main/Expressions#NamedParametersClass#B.
//                ^ reference local 46
          }

          public void Update(int a, string b)
//                    ^^^^^^ definition scip-dotnet nuget . . Main/Expressions#NamedParametersClass#Update().
//                           documentation ```cs\npublic void NamedParametersClass.Update(int a, string b)\n```
//                               ^ definition local 47
//                                 documentation ```cs\nint a\n```
//                                         ^ definition local 48
//                                           documentation ```cs\nstring b\n```
          {
              A = a;
//            ^ reference scip-dotnet nuget . . Main/Expressions#NamedParametersClass#A.
//                ^ reference local 47
              B = b;
//            ^ reference scip-dotnet nuget . . Main/Expressions#NamedParametersClass#B.
//                ^ reference local 48
          }
      }

      NamedParametersClass NamedParameters()
//    ^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#NamedParametersClass#
//                         ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#NamedParameters().
//                                         documentation ```cs\nprivate NamedParametersClass Expressions.NamedParameters()\n```
      {
          var a = new NamedParametersClass(b: "hi", a: 1);
//            ^ definition local 49
//              documentation ```cs\nNamedParametersClass? a\n```
//                    ^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#NamedParametersClass#
//                                         ^ reference local 46
//                                                  ^ reference local 45
          a.Update(b: "foo", a: 42);
//        ^ reference local 49
//          ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#NamedParametersClass#Update().
//                 ^ reference local 48
//                           ^ reference local 47
          return a;
//               ^ reference local 49
      }

      Func<int, int> AnonymousFunction()
//                   ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#AnonymousFunction().
//                                     documentation ```cs\nprivate Func<int, int> Expressions.AnonymousFunction()\n```
      {
          var d = delegate (int _, int _) { return 42; };
//            ^ definition local 50
//              documentation ```cs\nFunc<int, int, int>? d\n```
//                              ^ definition local 51
//                                documentation ```cs\nint _\n```
//                                     ^ definition local 52
//                                       documentation ```cs\nint _\n```
          return delegate (int a) { return a + d.Invoke(a, a); };
//                             ^ definition local 53
//                               documentation ```cs\nint a\n```
//                                         ^ reference local 53
//                                             ^ reference local 50
//                                               ^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Func#Invoke().
//                                                      ^ reference local 53
//                                                         ^ reference local 53
      }

      class Lambda
//          ^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Lambda#
//                 documentation ```cs\nclass Lambda\n```
      {
          public string func(Lambda x)
//                      ^^^^ definition scip-dotnet nuget . . Main/Expressions#Lambda#func().
//                           documentation ```cs\npublic string Lambda.func(Lambda x)\n```
//                           ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Lambda#
//                                  ^ definition local 54
//                                    documentation ```cs\nLambda x\n```
          {
              return "";
          }
      }

      void LambdaExpressions()
//         ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#LambdaExpressions().
//                           documentation ```cs\nprivate void Expressions.LambdaExpressions()\n```
      {
          var a = (string x) => x + 1;
//            ^ definition local 55
//              documentation ```cs\nFunc<string, string>? a\n```
//                        ^ definition local 56
//                          documentation ```cs\nstring x\n```
//                              ^ reference local 56
          var b = (Lambda a, Lambda b) => { return a.func(b); };
//            ^ definition local 57
//              documentation ```cs\nFunc<Lambda, Lambda, string>? b\n```
//                 ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Lambda#
//                        ^ definition local 58
//                          documentation ```cs\nLambda a\n```
//                           ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Lambda#
//                                  ^ definition local 59
//                                    documentation ```cs\nLambda b\n```
//                                                 ^ reference local 58
//                                                   ^^^^ reference scip-dotnet nuget . . Main/Expressions#Lambda#func().
//                                                        ^ reference local 59
          var c = string (Lambda a, Lambda _) => { return "hi"; };
//            ^ definition local 60
//              documentation ```cs\nFunc<Lambda, Lambda, string>? c\n```
//                        ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Lambda#
//                               ^ definition local 61
//                                 documentation ```cs\nLambda a\n```
//                                  ^^^^^^ reference scip-dotnet nuget . . Main/Expressions#Lambda#
//                                         ^ definition local 62
//                                           documentation ```cs\nLambda _\n```
      }

      void TupleExpressions()
//         ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TupleExpressions().
//                          documentation ```cs\nprivate void Expressions.TupleExpressions()\n```
      {
          var a = (1, 2, "");
//            ^ definition local 63
//              documentation ```cs\n(int, int, string) a\n```
      }

      void ArrayCreation()
//         ^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#ArrayCreation().
//                       documentation ```cs\nprivate void Expressions.ArrayCreation()\n```
      {
          var a = new[,] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
//            ^ definition local 64
//              documentation ```cs\nint[*,*]? a\n```
          Span<int> b = stackalloc[] { 1, 2, 3 };
//                  ^ definition local 65
//                    documentation ```cs\nSpan<int> b\n```
          Span<int> c = stackalloc int[] { 1, 2, 3 };
//                  ^ definition local 66
//                    documentation ```cs\nSpan<int> c\n```
          var d = new int[3] { 1, 2, 3 };
//            ^ definition local 67
//              documentation ```cs\nint[]? d\n```
          var e = new byte[,] { { 1, 2 }, { 2, 3 } };
//            ^ definition local 68
//              documentation ```cs\nbyte[*,*]? e\n```
          var f = new int[3, 2] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
//            ^ definition local 69
//              documentation ```cs\nint[*,*]? f\n```
          var g = new (string b, string c)[3];
//            ^ definition local 70
//              documentation ```cs\n(string b, string c)[]? g\n```
      }

      void MakeRef()
//         ^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#MakeRef().
//                 documentation ```cs\nprivate void Expressions.MakeRef()\n```
      {
          var g = "";
//            ^ definition local 71
//              documentation ```cs\nstring? g\n```
          var a = __makeref(g);
//            ^ definition local 72
//              documentation ```cs\nTypedReference a\n```
//                          ^ reference local 71
      }

      void SizeOf()
//         ^^^^^^ definition scip-dotnet nuget . . Main/Expressions#SizeOf().
//                documentation ```cs\nprivate void Expressions.SizeOf()\n```
      {
          var a = sizeof(int);
//            ^ definition local 73
//              documentation ```cs\nint a\n```
      }

      void TypeOf()
//         ^^^^^^ definition scip-dotnet nuget . . Main/Expressions#TypeOf().
//                documentation ```cs\nprivate void Expressions.TypeOf()\n```
      {
          var a = typeof(int);
//            ^ definition local 74
//              documentation ```cs\nType? a\n```
          var b = typeof(List<string>.Enumerator);
//            ^ definition local 75
//              documentation ```cs\nType? b\n```
//                                    ^^^^^^^^^^ reference scip-dotnet nuget System.Collections 7.0.0.0 Generic/List#Enumerator#
          var c = typeof(Dictionary<,>);
//            ^ definition local 76
//              documentation ```cs\nType? c\n```
          var d = typeof(Tuple<,,,>);
//            ^ definition local 77
//              documentation ```cs\nType? d\n```
      }

      interface IAnimal
//              ^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#IAnimal#
//                      documentation ```cs\ninterface IAnimal\n```
      {
          string Sound();
//               ^^^^^ definition scip-dotnet nuget . . Main/Expressions#IAnimal#Sound().
//                     documentation ```cs\nstring IAnimal.Sound()\n```
      }

      public class Dog : IAnimal
//                 ^^^ definition scip-dotnet nuget . . Main/Expressions#Dog#
//                     documentation ```cs\nclass Dog\n```
//                     relationship implementation scip-dotnet nuget . . Main/Expressions#IAnimal#
//                       ^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IAnimal#
      {
          public string Sound()
//                      ^^^^^ definition scip-dotnet nuget . . Main/Expressions#Dog#Sound().
//                            documentation ```cs\npublic string Dog.Sound()\n```
//                            relationship implementation reference scip-dotnet nuget . . Main/Expressions#IAnimal#Sound().
          {
              return "woof";
          }
      }

      public class Cat : IAnimal
//                 ^^^ definition scip-dotnet nuget . . Main/Expressions#Cat#
//                     documentation ```cs\nclass Cat\n```
//                     relationship implementation scip-dotnet nuget . . Main/Expressions#IAnimal#
//                       ^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IAnimal#
      {
          public string Sound()
//                      ^^^^^ definition scip-dotnet nuget . . Main/Expressions#Cat#Sound().
//                            documentation ```cs\npublic string Cat.Sound()\n```
//                            relationship implementation reference scip-dotnet nuget . . Main/Expressions#IAnimal#Sound().
          {
              return "meow";
          }
      }

      void Switch()
//         ^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Switch().
//                documentation ```cs\nprivate void Expressions.Switch()\n```
      {
          int some = 42;
//            ^^^^ definition local 78
//                 documentation ```cs\nint some\n```
          var a = some switch
//            ^ definition local 79
//              documentation ```cs\nstring? a\n```
//                ^^^^ reference local 78
          {
              1 => "one",
              2 => "two",
              _ => "more"
          };
          IAnimal dog = new Dog();
//        ^^^^^^^ reference scip-dotnet nuget . . Main/Expressions#IAnimal#
//                ^^^ definition local 80
//                    documentation ```cs\nIAnimal dog\n```
//                          ^^^ reference scip-dotnet nuget . . Main/Expressions#Dog#
          var b = dog switch
//            ^ definition local 81
//              documentation ```cs\nstring? b\n```
//                ^^^ reference local 80
          {
              Cat c => c.Sound(),
//            ^^^ reference scip-dotnet nuget . . Main/Expressions#Cat#
//                ^ definition local 82
//                  documentation ```cs\nCat c\n```
//                     ^ reference local 82
//                       ^^^^^ reference scip-dotnet nuget . . Main/Expressions#Cat#Sound().
              Dog c => c.Sound(),
//            ^^^ reference scip-dotnet nuget . . Main/Expressions#Dog#
//                ^ definition local 83
//                  documentation ```cs\nDog c\n```
//                     ^ reference local 83
//                       ^^^^^ reference scip-dotnet nuget . . Main/Expressions#Dog#Sound().
              _ => throw new ArgumentOutOfRangeException()
//                           ^^^^^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/ArgumentOutOfRangeException#
          };
      }

      void Dictionary()
//         ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Expressions#Dictionary().
//                    documentation ```cs\nprivate void Expressions.Dictionary()\n```
      {
          var a = new Dictionary<string, int> { ["a"] = 65 };
//            ^ definition local 84
//              documentation ```cs\nDictionary<string, int>? a\n```
      }

      void Is()
//         ^^ definition scip-dotnet nuget . . Main/Expressions#Is().
//            documentation ```cs\nprivate void Expressions.Is()\n```
      {
          object s = "s";
//               ^ definition local 85
//                 documentation ```cs\nobject s\n```
          if (s is string s2)
//            ^ reference local 85
//                        ^^ definition local 86
//                           documentation ```cs\nstring s2\n```
          {
              Console.WriteLine(s2);
//            ^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#
//                    ^^^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#WriteLine(+11).
//                              ^^ reference local 86
          }

          var c = s is "test";
//            ^ definition local 87
//              documentation ```cs\nbool c\n```
//                ^ reference local 85
          var a = s is int.MaxValue;
//            ^ definition local 88
//              documentation ```cs\nbool a\n```
//                ^ reference local 85
//                         ^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int32#MaxValue.
          var d = s is nameof(a);
//            ^ definition local 89
//              documentation ```cs\nbool d\n```
//                ^ reference local 85
//                            ^ reference local 88
      }
  }

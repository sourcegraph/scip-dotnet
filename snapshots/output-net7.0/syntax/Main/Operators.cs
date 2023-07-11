  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Operators
//             ^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#
//                       documentation ```cs\nclass Operators\n```
  {
      class PlusMinus
//          ^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#PlusMinus#
//                    documentation ```cs\nclass PlusMinus\n```
      {
          public static int operator +(PlusMinus a)
//                                     ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                               ^ definition local 0
//                                                 documentation ```cs\nPlusMinus a\n```
          {
              return 0;
          }

          public static int operator +(PlusMinus a, PlusMinus b)
//                                     ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                               ^ definition local 1
//                                                 documentation ```cs\nPlusMinus a\n```
//                                                  ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                                            ^ definition local 2
//                                                              documentation ```cs\nPlusMinus b\n```
          {
              return 0;
          }

          public static int operator -(PlusMinus a)
//                                     ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                               ^ definition local 3
//                                                 documentation ```cs\nPlusMinus a\n```
          {
              return 0;
          }
      }

      class TrueFalse
//          ^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#
//                    documentation ```cs\nclass TrueFalse\n```
      {
          protected bool Equals(TrueFalse other)
//                       ^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#Equals().
//                              documentation ```cs\nprotected bool TrueFalse.Equals(TrueFalse other)\n```
//                              ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                        ^^^^^ definition local 4
//                                              documentation ```cs\nTrueFalse other\n```
          {
              throw new NotImplementedException();
//                      ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
          }

          public override bool Equals(object? obj)
//                             ^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#Equals(+1).
//                                    documentation ```cs\npublic override bool TrueFalse.Equals(object? obj)\n```
//                                    relationship implementation reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#Equals().
//                                            ^^^ definition local 5
//                                                documentation ```cs\nobject? obj\n```
          {
              if (ReferenceEquals(null, obj)) return false;
//                ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#ReferenceEquals().
//                                      ^^^ reference local 5
              if (ReferenceEquals(this, obj)) return true;
//                ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#ReferenceEquals().
//                                      ^^^ reference local 5
              if (obj.GetType() != this.GetType()) return false;
//                ^^^ reference local 5
//                    ^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#GetType().
//                                      ^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#GetType().
              return Equals((TrueFalse)obj);
//                   ^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#Equals().
//                           ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                     ^^^ reference local 5
          }

          public override int GetHashCode()
//                            ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#GetHashCode().
//                                        documentation ```cs\npublic override int TrueFalse.GetHashCode()\n```
//                                        relationship implementation reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#GetHashCode().
          {
              throw new NotImplementedException();
//                      ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
          }

          public static bool operator true(TrueFalse a)
//                                         ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                   ^ definition local 6
//                                                     documentation ```cs\nTrueFalse a\n```
          {
              return true;
          }

          public static bool operator false(TrueFalse a)
//                                          ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                    ^ definition local 7
//                                                      documentation ```cs\nTrueFalse a\n```
          {
              return false;
          }

          public static bool operator !=(TrueFalse a, TrueFalse b)
//                                       ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                 ^ definition local 8
//                                                   documentation ```cs\nTrueFalse a\n```
//                                                    ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                              ^ definition local 9
//                                                                documentation ```cs\nTrueFalse b\n```
          {
              return true;
          }

          public static bool operator ==(TrueFalse a, TrueFalse b)
//                                       ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                 ^ definition local 10
//                                                   documentation ```cs\nTrueFalse a\n```
//                                                    ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                              ^ definition local 11
//                                                                documentation ```cs\nTrueFalse b\n```
          {
              return true;
          }
      }
  }

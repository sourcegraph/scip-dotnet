  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Operators
//             ^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#
//                       documentation ```cs\nclass Main.Operators\n```
//                       relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
  {
      class PlusMinus
//          ^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#PlusMinus#
//                    documentation ```cs\nclass Main.Operators.PlusMinus\n```
//                    relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
      {
          public static int operator +(PlusMinus a)
//                                     ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                               ^ definition scip-dotnet nuget . . Main/Operators#PlusMinus#op_UnaryPlus().(a)
//                                                 documentation ```cs\nMain.Operators.PlusMinus a\n```
          {
              return 0;
          }
  
          public static int operator +(PlusMinus a, PlusMinus b)
//                                     ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                               ^ definition scip-dotnet nuget . . Main/Operators#PlusMinus#op_Addition().(a)
//                                                 documentation ```cs\nMain.Operators.PlusMinus a\n```
//                                                  ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                                            ^ definition scip-dotnet nuget . . Main/Operators#PlusMinus#op_Addition().(b)
//                                                              documentation ```cs\nMain.Operators.PlusMinus b\n```
          {
              return 0;
          }
  
          public static int operator -(PlusMinus a)
//                                     ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#PlusMinus#
//                                               ^ definition scip-dotnet nuget . . Main/Operators#PlusMinus#op_UnaryNegation().(a)
//                                                 documentation ```cs\nMain.Operators.PlusMinus a\n```
          {
              return 0;
          }
      }
  
      class TrueFalse
//          ^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#
//                    documentation ```cs\nclass Main.Operators.TrueFalse\n```
//                    relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
      {
          protected bool Equals(TrueFalse other)
//                       ^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#Equals().
//                              documentation ```cs\nprotected System.Boolean Main.Operators.TrueFalse.Equals(Main.Operators.TrueFalse other)\n```
//                              ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                        ^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#Equals().(other)
//                                              documentation ```cs\nMain.Operators.TrueFalse other\n```
          {
              throw new NotImplementedException();
//                      ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/NotImplementedException#
          }
  
          public override bool Equals(object? obj)
//                             ^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#Equals(+1).
//                                    documentation ```cs\npublic override System.Boolean Main.Operators.TrueFalse.Equals(System.Object obj)\n```
//                                    relationship implementation reference scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#Equals().
//                                            ^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#Equals(+1).(obj)
//                                                documentation ```cs\nSystem.Object obj\n```
          {
              if (ReferenceEquals(null, obj)) return false;
//                ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#ReferenceEquals().
//                                      ^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#Equals(+1).(obj)
              if (ReferenceEquals(this, obj)) return true;
//                ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#ReferenceEquals().
//                                      ^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#Equals(+1).(obj)
              if (obj.GetType() != this.GetType()) return false;
//                ^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#Equals(+1).(obj)
//                    ^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#GetType().
//                                      ^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#GetType().
              return Equals((TrueFalse)obj);
//                   ^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#Equals().
//                           ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                     ^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#Equals(+1).(obj)
          }
  
          public override int GetHashCode()
//                            ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#GetHashCode().
//                                        documentation ```cs\npublic override System.Int32 Main.Operators.TrueFalse.GetHashCode()\n```
//                                        relationship implementation reference scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#GetHashCode().
          {
              throw new NotImplementedException();
//                      ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 System/NotImplementedException#
          }
  
          public static bool operator true(TrueFalse a)
//                                         ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                   ^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#op_True().(a)
//                                                     documentation ```cs\nMain.Operators.TrueFalse a\n```
          {
              return true;
          }
  
          public static bool operator false(TrueFalse a)
//                                          ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                    ^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#op_False().(a)
//                                                      documentation ```cs\nMain.Operators.TrueFalse a\n```
          {
              return false;
          }
  
          public static bool operator !=(TrueFalse a, TrueFalse b)
//                                       ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                 ^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#op_Inequality().(a)
//                                                   documentation ```cs\nMain.Operators.TrueFalse a\n```
//                                                    ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                              ^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#op_Inequality().(b)
//                                                                documentation ```cs\nMain.Operators.TrueFalse b\n```
          {
              return true;
          }
  
          public static bool operator ==(TrueFalse a, TrueFalse b)
//                                       ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                 ^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#op_Equality().(a)
//                                                   documentation ```cs\nMain.Operators.TrueFalse a\n```
//                                                    ^^^^^^^^^ reference scip-dotnet nuget . . Main/Operators#TrueFalse#
//                                                              ^ definition scip-dotnet nuget . . Main/Operators#TrueFalse#op_Equality().(b)
//                                                                documentation ```cs\nMain.Operators.TrueFalse b\n```
          {
              return true;
          }
      }
  }

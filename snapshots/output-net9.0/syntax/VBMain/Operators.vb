  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Operators
'                  ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#
'                            documentation ```vb\nClass Operators\n```
          Public Class PlusMinus
'                      ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#PlusMinus#
'                                documentation ```vb\nClass PlusMinus\n```
              Public Shared Operator +(A As PlusMinus)
'                                      ^ definition scip-dotnet nuget . . VBMain/Operators#PlusMinus#op_UnaryPlus().(A)
'                                        documentation ```vb\nA As PlusMinus\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
                  Return 0
              End Operator

              Public Shared Operator +(A As PlusMinus, B As PlusMinus)
'                                      ^ definition scip-dotnet nuget . . VBMain/Operators#PlusMinus#op_Addition().(A)
'                                        documentation ```vb\nA As PlusMinus\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
'                                                      ^ definition scip-dotnet nuget . . VBMain/Operators#PlusMinus#op_Addition().(B)
'                                                        documentation ```vb\nB As PlusMinus\n```
'                                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
                  Return 0
              End Operator

              Public Shared Operator -(A As PlusMinus)
'                                      ^ definition scip-dotnet nuget . . VBMain/Operators#PlusMinus#op_UnaryNegation().(A)
'                                        documentation ```vb\nA As PlusMinus\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
                  Return 0
              End Operator
          End Class

          Public Class TrueFalse
'                      ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#
'                                documentation ```vb\nClass TrueFalse\n```
              Public Shared Operator IsTrue(A As TrueFalse) As Boolean
'                                           ^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#op_True().(A)
'                                             documentation ```vb\nA As TrueFalse\n```
'                                                ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return True
              End Operator

              Public Shared Operator IsFalse(A As TrueFalse) As Boolean
'                                            ^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#op_False().(A)
'                                              documentation ```vb\nA As TrueFalse\n```
'                                                 ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return False
              End Operator

              Public Shared Operator =(A As TrueFalse, B As TrueFalse) As Boolean
'                                      ^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#op_Equality().(A)
'                                        documentation ```vb\nA As TrueFalse\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
'                                                      ^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#op_Equality().(B)
'                                                        documentation ```vb\nB As TrueFalse\n```
'                                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return True
              End Operator

              Public Shared Operator <>(A As TrueFalse, B As TrueFalse) As Boolean
'                                       ^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#op_Inequality().(A)
'                                         documentation ```vb\nA As TrueFalse\n```
'                                            ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
'                                                       ^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#op_Inequality().(B)
'                                                         documentation ```vb\nB As TrueFalse\n```
'                                                            ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return True
              End Operator

              Public Overrides Function Equals(obj As Object) As Boolean
'                                       ^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().
'                                              documentation ```vb\nPublic Overrides Function TrueFalse.Equals(obj As Object) As Boolean\n```
'                                              relationship implementation reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Object#Equals().
'                                              ^^^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().(obj)
'                                                  documentation ```vb\nobj As Object\n```
                  If ReferenceEquals(Nothing, obj) Then Return False
'                    ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Object#ReferenceEquals().
'                                             ^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().(obj)
                  If ReferenceEquals(Me, obj) Then Return True
'                    ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Object#ReferenceEquals().
'                                        ^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().(obj)
                  If obj.GetType() <> Me.GetType() Then Return False
'                    ^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().(obj)
'                        ^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Object#GetType().
'                                        ^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Object#GetType().
                  Return Equals(CType(obj, TrueFalse))
'                        ^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().
'                                     ^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().(obj)
'                                          ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
              End Function

              Public Overrides Function GetHashCode() As Integer
'                                       ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#GetHashCode().
'                                                   documentation ```vb\nPublic Overrides Function TrueFalse.GetHashCode() As Integer\n```
'                                                   relationship implementation reference scip-dotnet nuget System.Runtime 9.0.0.0 System/Object#GetHashCode().
                  Throw New NotImplementedException()
'                           ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/NotImplementedException#
              End Function

          End Class
      End Class
  End Namespace

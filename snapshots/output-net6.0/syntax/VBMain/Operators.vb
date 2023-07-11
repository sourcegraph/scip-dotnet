  Imports System.Diagnostics.CodeAnalysis

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Class Operators
'                  ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#
'                            documentation ```vb\nClass Operators\n```
          Public Class PlusMinus
'                      ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#PlusMinus#
'                                documentation ```vb\nClass PlusMinus\n```
              Public Shared Operator +(A As PlusMinus)
'                                      ^ definition local 0
'                                        documentation ```vb\nA As PlusMinus\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
                  Return 0
              End Operator

              Public Shared Operator +(A As PlusMinus, B As PlusMinus)
'                                      ^ definition local 1
'                                        documentation ```vb\nA As PlusMinus\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
'                                                      ^ definition local 2
'                                                        documentation ```vb\nB As PlusMinus\n```
'                                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
                  Return 0
              End Operator

              Public Shared Operator -(A As PlusMinus)
'                                      ^ definition local 3
'                                        documentation ```vb\nA As PlusMinus\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#PlusMinus#
                  Return 0
              End Operator
          End Class

          Public Class TrueFalse
'                      ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#
'                                documentation ```vb\nClass TrueFalse\n```
              Public Shared Operator IsTrue(A As TrueFalse) As Boolean
'                                           ^ definition local 4
'                                             documentation ```vb\nA As TrueFalse\n```
'                                                ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return True
              End Operator

              Public Shared Operator IsFalse(A As TrueFalse) As Boolean
'                                            ^ definition local 5
'                                              documentation ```vb\nA As TrueFalse\n```
'                                                 ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return False
              End Operator

              Public Shared Operator =(A As TrueFalse, B As TrueFalse) As Boolean
'                                      ^ definition local 6
'                                        documentation ```vb\nA As TrueFalse\n```
'                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
'                                                      ^ definition local 7
'                                                        documentation ```vb\nB As TrueFalse\n```
'                                                           ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return True
              End Operator

              Public Shared Operator <>(A As TrueFalse, B As TrueFalse) As Boolean
'                                       ^ definition local 8
'                                         documentation ```vb\nA As TrueFalse\n```
'                                            ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
'                                                       ^ definition local 9
'                                                         documentation ```vb\nB As TrueFalse\n```
'                                                            ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
                  Return True
              End Operator

              Public Overrides Function Equals(obj As Object) As Boolean
'                                       ^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#Equals().
'                                              documentation ```vb\nPublic Overrides Function TrueFalse.Equals(obj As Object) As Boolean\n```
'                                              ^^^ definition local 10
'                                                  documentation ```vb\nobj As Object\n```
                  If ReferenceEquals(Nothing, obj) Then Return False
'                                             ^^^ reference local 10
                  If ReferenceEquals(Me, obj) Then Return True
'                                        ^^^ reference local 10
                  If obj.GetType() <> Me.GetType() Then Return False
'                    ^^^ reference local 10
                  Return Equals(CType(obj, TrueFalse))
'                                     ^^^ reference local 10
'                                          ^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Operators#TrueFalse#
              End Function

              Public Overrides Function GetHashCode() As Integer
'                                       ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Operators#TrueFalse#GetHashCode().
'                                                   documentation ```vb\nPublic Overrides Function TrueFalse.GetHashCode() As Integer\n```
                  Throw New NotImplementedException()
              End Function

          End Class
      End Class
  End Namespace

  Imports System.Diagnostics.CodeAnalysis

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Class Interfaces
'                  ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#
'                             documentation ```vb\nClass Interfaces\n```
          Interface IOne
'                   ^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IOne#
'                        documentation ```vb\nInterface IOne\n```
          End Interface

          Interface ITwo
'                   ^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#ITwo#
'                        documentation ```vb\nInterface ITwo\n```
          End Interface

          Interface IThree
'                   ^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IThree#
'                          documentation ```vb\nInterface IThree\n```
          End Interface

          Interface IProperties
'                   ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IProperties#
'                               documentation ```vb\nInterface IProperties\n```
              ReadOnly Property [Get] As Byte
'                               ^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IProperties#Get.
'                                     documentation ```vb\nReadOnly Property IProperties.Get As Byte\n```
              WriteOnly Property [Set] As Char
'                                ^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IProperties#Set.
'                                      documentation ```vb\nWriteOnly Property IProperties.Set As Char\n```
              Property GetSet As UInteger
'                      ^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IProperties#GetSet.
'                             documentation ```vb\nProperty IProperties.GetSet As UInteger\n```
              Property SetGet As Long
'                      ^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IProperties#SetGet.
'                             documentation ```vb\nProperty IProperties.SetGet As Long\n```
          End Interface

          Interface IMethods
'                   ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IMethods#
'                            documentation ```vb\nInterface IMethods\n```
              Sub [Nothing]()
'                 ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IMethods#Nothing().
'                           documentation ```vb\nSub IMethods.Nothing()\n```
              Function Output() As Integer
'                      ^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IMethods#Output().
'                             documentation ```vb\nFunction IMethods.Output() As Integer\n```
              Sub Input(ByVal a As String)
'                 ^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IMethods#Input().
'                       documentation ```vb\nSub IMethods.Input(a As String)\n```
'                             ^ definition scip-dotnet nuget . . VBMain/Interfaces#IMethods#Input().(a)
'                               documentation ```vb\na As String\n```
              Function InputOutput(ByVal a As String) As Integer
'                      ^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IMethods#InputOutput().
'                                  documentation ```vb\nFunction IMethods.InputOutput(a As String) As Integer\n```
'                                        ^ definition scip-dotnet nuget . . VBMain/Interfaces#IMethods#InputOutput().(a)
'                                          documentation ```vb\na As String\n```
          End Interface

          Interface IEvent
'                   ^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IEvent#
'                          documentation ```vb\nInterface IEvent\n```
              Event SomeEvent As EventHandler(Of Integer)
'                   ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IEvent#SomeEvent#
'                             documentation ```vb\nEvent IEvent.SomeEvent As EventHandler\n```
          End Interface

          Interface IIndex
'                   ^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IIndex#
'                          documentation ```vb\nInterface IIndex\n```
              Default Property Item(ByVal index As Integer) As Boolean
'                              ^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IIndex#Item.
'                                   documentation ```vb\nDefault Property IIndex.Item(index As Integer) As Boolean\n```
'                                         ^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IIndex#Item.(index)
'                                               documentation ```vb\nindex As Integer\n```
          End Interface

          Private Interface IInherit
'                           ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Interfaces#IInherit#
'                                    documentation ```vb\nInterface IInherit\n```
'                                    relationship implementation scip-dotnet nuget . . VBMain/Interfaces#IOne#
'                                    relationship implementation scip-dotnet nuget . . VBMain/Interfaces#ITwo#
              Inherits IOne, ITwo
'                      ^^^^ reference scip-dotnet nuget . . VBMain/Interfaces#IOne#
'                            ^^^^ reference scip-dotnet nuget . . VBMain/Interfaces#ITwo#
          End Interface
      End Class
  End Namespace

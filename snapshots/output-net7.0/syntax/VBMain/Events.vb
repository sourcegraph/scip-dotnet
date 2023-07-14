  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Events
'                  ^^^^^^ definition scip-dotnet nuget . . VBMain/Events#
'                         documentation ```vb\nClass Events\n```
          Private EventHandlerList As New ArrayList
'                 ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                  documentation ```vb\nPrivate Events.EventHandlerList As ArrayList\n```
'                                         ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 Collections/ArrayList#

          Public Event Event1 As EventHandler(Of Integer)
'                      ^^^^^^ definition scip-dotnet nuget . . VBMain/Events#Event1#
'                             documentation ```vb\nPublic Event Events.Event1 As EventHandler(Of Integer)\n```

          Public Custom Event Event2 As EventHandler
'                             ^^^^^^ definition scip-dotnet nuget . . VBMain/Events#Event2#
'                                    documentation ```vb\nPublic Event Events.Event2 As EventHandler\n```
'                                       ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#

              AddHandler(ByVal value As EventHandler)
'                              ^^^^^ definition local 0
'                                    documentation ```vb\nvalue As EventHandler\n```
'                                       ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#
                  EventHandlerList.Add(value)
'                 ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                  ^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 Collections/ArrayList#Add().
'                                      ^^^^^ reference local 0
              End AddHandler

              RemoveHandler(ByVal value As EventHandler)
'                                 ^^^^^ definition local 1
'                                       documentation ```vb\nvalue As EventHandler\n```
'                                          ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#
                  EventHandlerList.Remove(value)
'                 ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                  ^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 Collections/ArrayList#Remove().
'                                         ^^^^^ reference local 1
              End RemoveHandler

              RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
'                              ^^^^^^ definition local 2
'                                     documentation ```vb\nsender As Object\n```
'                                                      ^ definition local 3
'                                                        documentation ```vb\ne As EventArgs\n```
'                                                           ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventArgs#
                  For Each handler As EventHandler In EventHandlerList
'                          ^^^^^^^ definition local 4
'                                  documentation ```vb\nhandler As Delegate Sub EventHandler(sender As Object, e As EventArgs)\n```
'                                     ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#
'                                                     ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
                      If handler IsNot Nothing Then
'                        ^^^^^^^ reference local 4
                          handler.BeginInvoke(sender, e, Nothing, Nothing)
'                         ^^^^^^^ reference local 4
'                                 ^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#BeginInvoke().
'                                             ^^^^^^ reference local 2
'                                                     ^ reference local 3
                      End If
                  Next
              End RaiseEvent
          End Event

          Private Sub Event1Handler() Handles Me.Event1
'                     ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Events#Event1Handler().
'                                   documentation ```vb\nPrivate Sub Events.Event1Handler()\n```
'                                                ^^^^^^ reference scip-dotnet nuget . . VBMain/Events#Event1#
              Throw New NotImplementedException()
'                       ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
          End Sub
      End Class
  End Namespace

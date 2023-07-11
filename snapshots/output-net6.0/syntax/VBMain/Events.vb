  Imports System.Diagnostics.CodeAnalysis

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Class Events
'                  ^^^^^^ definition scip-dotnet nuget . . VBMain/Events#
'                         documentation ```vb\nClass Events\n```
          Private EventHandlerList As New ArrayList
'                 ^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                  documentation ```vb\nPrivate Events.EventHandlerList As ArrayList\n```

          Public Event Event1 As EventHandler(Of Integer)
'                      ^^^^^^ definition scip-dotnet nuget . . VBMain/Events#Event1#
'                             documentation ```vb\nPublic Event Events.Event1 As EventHandler\n```

          Public Custom Event Event2 As EventHandler
'                             ^^^^^^ definition scip-dotnet nuget . . VBMain/Events#Event2#
'                                    documentation ```vb\nPublic Event Events.Event2 As EventHandler\n```

              AddHandler(ByVal value As EventHandler)
'                              ^^^^^ definition local 0
'                                    documentation ```vb\nvalue As EventHandler\n```
                  EventHandlerList.Add(value)
'                 ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                      ^^^^^ reference local 0
              End AddHandler

              RemoveHandler(ByVal value As EventHandler)
'                                 ^^^^^ definition local 1
'                                       documentation ```vb\nvalue As EventHandler\n```
                  EventHandlerList.Remove(value)
'                 ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                         ^^^^^ reference local 1
              End RemoveHandler

              RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
'                              ^^^^^^ definition local 2
'                                     documentation ```vb\nsender As Object\n```
'                                                      ^ definition local 3
'                                                        documentation ```vb\ne As EventArgs\n```
                  For Each handler As EventHandler In EventHandlerList
'                          ^^^^^^^ definition local 4
'                                  documentation ```vb\nhandler As EventHandler\n```
'                                                     ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
                      If handler IsNot Nothing Then
'                        ^^^^^^^ reference local 4
                          handler.BeginInvoke(sender, e, Nothing, Nothing)
'                         ^^^^^^^ reference local 4
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
          End Sub
      End Class
  End Namespace

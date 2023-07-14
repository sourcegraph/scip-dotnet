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
'                              ^^^^^ definition scip-dotnet nuget . . VBMain/Events#add_Event2().(value)
'                                    documentation ```vb\nvalue As EventHandler\n```
                  EventHandlerList.Add(value)
'                 ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                      ^^^^^ reference scip-dotnet nuget . . VBMain/Events#add_Event2().(value)
              End AddHandler

              RemoveHandler(ByVal value As EventHandler)
'                                 ^^^^^ definition scip-dotnet nuget . . VBMain/Events#remove_Event2().(value)
'                                       documentation ```vb\nvalue As EventHandler\n```
                  EventHandlerList.Remove(value)
'                 ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
'                                         ^^^^^ reference scip-dotnet nuget . . VBMain/Events#remove_Event2().(value)
              End RemoveHandler

              RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
'                              ^^^^^^ definition scip-dotnet nuget . . VBMain/Events#raise_Event2().(sender)
'                                     documentation ```vb\nsender As Object\n```
'                                                      ^ definition scip-dotnet nuget . . VBMain/Events#raise_Event2().(e)
'                                                        documentation ```vb\ne As EventArgs\n```
                  For Each handler As EventHandler In EventHandlerList
'                          ^^^^^^^ definition local 0
'                                  documentation ```vb\nhandler As EventHandler\n```
'                                                     ^^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Events#EventHandlerList.
                      If handler IsNot Nothing Then
'                        ^^^^^^^ reference local 0
                          handler.BeginInvoke(sender, e, Nothing, Nothing)
'                         ^^^^^^^ reference local 0
'                                             ^^^^^^ reference scip-dotnet nuget . . VBMain/Events#raise_Event2().(sender)
'                                                     ^ reference scip-dotnet nuget . . VBMain/Events#raise_Event2().(e)
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

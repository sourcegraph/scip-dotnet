Imports System.Diagnostics.CodeAnalysis

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Events
        Private EventHandlerList As New ArrayList

        Public Event Event1 As EventHandler(Of Integer)

        Public Custom Event Event2 As EventHandler

            AddHandler(ByVal value As EventHandler)
                EventHandlerList.Add(value)
            End AddHandler
            
            RemoveHandler(ByVal value As EventHandler)
                EventHandlerList.Remove(value)
            End RemoveHandler
            
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
            
                For Each handler As EventHandler In EventHandlerList
                    If handler IsNot Nothing Then
                    handler.BeginInvoke(sender, e, Nothing, Nothing)
                    End If
                Next
            End RaiseEvent
        End Event

        Private Sub Event1Handler() Handles Me.Event1
            Throw New NotImplementedException()
        End Sub
    End Class
End Namespace

Imports System.Diagnostics.CodeAnalysis
Imports System.IO

Namespace VBMain
    <SuppressMessage("ReSharper", "all")>
    Public Class Statements
        Private Sub [Try]()
            Try
                File.ReadLines("asd")
            Catch err As Exception
                Console.WriteLine(err)
            End Try
        End Sub

        Private Function [Default]() As (A As String, B As Boolean)
            Dim C As (A As String, B As Boolean) = ("42", 42)
            Return C
        End Function

        Public Class Inferred
            Property F1 As Int32
            Property F2 As Int32
        End Class

        Private Sub InferredTuples()
            Dim List = New List(Of Inferred)()
            Dim Result = List.Select(Function(c) (c.F1, c.F2)).Where(Function(t) t.F2 = 1)
        End Sub

        Private Function MultipleInitializers() As Integer
            Dim a As Integer = 1, b As Integer = 2
            Return a + b
        End Function

        Class MyDisposable
            Implements IDisposable

            Private Sub Dispose() Implements IDisposable.Dispose
                Throw New NotImplementedException()
            End Sub
        End Class

        Private Function [Using]() As MyDisposable
            Dim b = New MyDisposable()

            Using a = b
                Return a
            End Using
        End Function

        Private Function MultipleUsing() As Long
            Using a As Stream = File.OpenRead("a"), b As Stream = File.OpenRead("a")
                Return a.Length + b.Length
            End Using
        End Function

        Private Function Foreach() As Integer
            Dim y = New Integer() {1}
            Dim z = 0

            For Each x As Integer In y
                z += x
            Next

            Return z
        End Function

    End Class
End Namespace

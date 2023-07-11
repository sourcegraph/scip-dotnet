  Imports System.Diagnostics.CodeAnalysis
  Imports System.IO

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
      Public Class Statements
'                  ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#
'                             documentation ```vb\nClass Statements\n```
          Private Sub [Try]()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Try().
'                           documentation ```vb\nPrivate Sub Statements.Try()\n```
              Try
                  File.ReadLines("asd")
              Catch err As Exception
'                   ^^^ definition local 0
'                       documentation ```vb\nerr As Exception\n```
'                   ^^^ reference local 0
                  Console.WriteLine(err)
'                                   ^^^ reference local 0
              End Try
          End Sub

          Private Function [Default]() As (A As String, B As Boolean)
'                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Default().
'                                    documentation ```vb\nPrivate Function Statements.Default() As (A As String, B As Boolean)\n```
              Dim C As (A As String, B As Boolean) = ("42", 42)
'                 ^ definition local 1
'                   documentation ```vb\nC As (A As String, B As Boolean)\n```
              Return C
'                    ^ reference local 1
          End Function

          Public Class Inferred
'                      ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Inferred#
'                               documentation ```vb\nClass Inferred\n```
              Property F1 As Int32
'                      ^^ definition scip-dotnet nuget . . VBMain/Statements#Inferred#F1.
'                         documentation ```vb\nPublic Property Inferred.F1 As Int32\n```
              Property F2 As Int32
'                      ^^ definition scip-dotnet nuget . . VBMain/Statements#Inferred#F2.
'                         documentation ```vb\nPublic Property Inferred.F2 As Int32\n```
          End Class

          Private Sub InferredTuples()
'                     ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#InferredTuples().
'                                    documentation ```vb\nPrivate Sub Statements.InferredTuples()\n```
              Dim List = New List(Of Inferred)()
'                 ^^^^ definition local 2
'                      documentation ```vb\nList As List\n```
'                                    ^^^^^^^^ reference scip-dotnet nuget . . VBMain/Statements#Inferred#
              Dim Result = List.Select(Function(c) (c.F1, c.F2)).Where(Function(t) t.F2 = 1)
'                 ^^^^^^ definition local 3
'                        documentation ```vb\nResult As \n```
'                          ^^^^ reference local 2
'                                               ^ definition local 4
'                                                 documentation ```vb\nc As Object\n```
'                                                   ^ reference local 4
'                                                         ^ reference local 4
'                                                                               ^ definition local 5
'                                                                                 documentation ```vb\nt As Object\n```
'                                                                                  ^ reference local 5
          End Sub

          Private Function MultipleInitializers() As Integer
'                          ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MultipleInitializers().
'                                               documentation ```vb\nPrivate Function Statements.MultipleInitializers() As Integer\n```
              Dim a As Integer = 1, b As Integer = 2
'                 ^ definition local 6
'                   documentation ```vb\na As Integer\n```
'                                   ^ definition local 7
'                                     documentation ```vb\nb As Integer\n```
              Return a + b
'                    ^ reference local 6
'                        ^ reference local 7
          End Function

          Class MyDisposable
'               ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MyDisposable#
'                            documentation ```vb\nClass MyDisposable\n```
'                            relationship implementation IDisposable#
              Implements IDisposable

              Private Sub Dispose() Implements IDisposable.Dispose
'                         ^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MyDisposable#Dispose().
'                                 documentation ```vb\nPrivate Sub MyDisposable.Dispose()\n```
                  Throw New NotImplementedException()
              End Sub
          End Class

          Private Function [Using]() As MyDisposable
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Using().
'                                  documentation ```vb\nPrivate Function Statements.Using() As MyDisposable\n```
'                                       ^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Statements#MyDisposable#
              Dim b = New MyDisposable()
'                 ^ definition local 8
'                   documentation ```vb\nb As Class MyDisposable\n```
'                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Statements#MyDisposable#

              Using a = b
'                   ^ definition local 9
'                     documentation ```vb\na As Class MyDisposable\n```
'                       ^ reference local 8
                  Return a
'                        ^ reference local 9
              End Using
          End Function

          Private Function MultipleUsing() As Long
'                          ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MultipleUsing().
'                                        documentation ```vb\nPrivate Function Statements.MultipleUsing() As Long\n```
              Using a As Stream = File.OpenRead("a"), b As Stream = File.OpenRead("a")
'                   ^ definition local 10
'                     documentation ```vb\na As Stream\n```
'                                                     ^ definition local 11
'                                                       documentation ```vb\nb As Stream\n```
                  Return a.Length + b.Length
'                        ^ reference local 10
'                                   ^ reference local 11
              End Using
          End Function

          Private Function Foreach() As Integer
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Foreach().
'                                  documentation ```vb\nPrivate Function Statements.Foreach() As Integer\n```
              Dim y = New Integer() {1}
'                 ^ definition local 12
'                   documentation ```vb\ny As Integer()\n```
              Dim z = 0
'                 ^ definition local 13
'                   documentation ```vb\nz As Integer\n```

              For Each x As Integer In y
'                      ^ definition local 14
'                        documentation ```vb\nx As Integer\n```
'                                      ^ reference local 12
                  z += x
'                 ^ reference local 13
'                      ^ reference local 14
              Next

              Return z
'                    ^ reference local 13
          End Function

      End Class
  End Namespace

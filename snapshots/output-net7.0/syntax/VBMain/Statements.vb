  Imports System.Diagnostics.CodeAnalysis
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
'                            ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  Imports System.IO
'         ^^^^^^ reference scip-dotnet nuget . . System/
'                ^^ reference scip-dotnet nuget . . IO/

  Namespace VBMain
'           ^^^^^^ reference scip-dotnet nuget . . VBMain/
      <SuppressMessage("ReSharper", "all")>
'      ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
      Public Class Statements
'                  ^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#
'                             documentation ```vb\nClass Statements\n```
          Private Sub [Try]()
'                     ^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Try().
'                           documentation ```vb\nPrivate Sub Statements.Try()\n```
              Try
                  File.ReadLines("asd")
'                 ^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/File#
'                      ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/File#ReadLines().
              Catch err As Exception
'                   ^^^ definition local 0
'                       documentation ```vb\nerr As Class Exception\n```
'                   ^^^ reference local 0
'                          ^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Exception#
                  Console.WriteLine(err)
'                 ^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#
'                         ^^^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#WriteLine(+9).
'                                   ^^^ reference local 0
              End Try
          End Sub

          Private Function [Default]() As (A as String, B as Boolean)
'                          ^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Default().
'                                    documentation ```vb\nPrivate Function Statements.Default() As (A As String, B As Boolean)\n```
              Dim C As (A As String, B As Boolean) = ("42", 42)
'                 ^ definition local 1
'                   documentation ```vb\nC As (A As String, B As Boolean)\n```
              Return C
'                    ^ reference local 1
          End Function

         Public class Inferred
'                     ^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Inferred#
'                              documentation ```vb\nClass Inferred\n```
              Property F1 As Int32
'                      ^^ definition scip-dotnet nuget . . VBMain/Statements#Inferred#F1.
'                         documentation ```vb\nPublic Property Inferred.F1 As Integer\n```
'                            ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int32#
              Property F2 As Int32
'                      ^^ definition scip-dotnet nuget . . VBMain/Statements#Inferred#F2.
'                         documentation ```vb\nPublic Property Inferred.F2 As Integer\n```
'                            ^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/Int32#
         End Class

          Private Sub InferredTuples()
'                     ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#InferredTuples().
'                                    documentation ```vb\nPrivate Sub Statements.InferredTuples()\n```
              Dim List = New List(Of Inferred)()
'                 ^^^^ definition local 2
'                      documentation ```vb\nList As Class List(Of Inferred)\n```
'                                    ^^^^^^^^ reference scip-dotnet nuget . . VBMain/Statements#Inferred#
              Dim Result = List.Select(Function(c) (c.F1, c.F2)).Where(Function(t) t.F2 = 1)
'                 ^^^^^^ definition local 3
'                        documentation ```vb\nResult As Interface IEnumerable(Of (F1 As Integer, F2 As Integer))\n```
'                          ^^^^ reference local 2
'                               ^^^^^^ reference scip-dotnet nuget System.Linq 7.0.0.0 Linq/Enumerable#Select().
'                                               ^ definition local 5
'                                                 documentation ```vb\nc As Inferred\n```
'                                                   ^ reference local 5
'                                                     ^^ reference scip-dotnet nuget . . VBMain/Statements#Inferred#F1.
'                                                         ^ reference local 5
'                                                           ^^ reference scip-dotnet nuget . . VBMain/Statements#Inferred#F2.
'                                                                ^^^^^ reference scip-dotnet nuget System.Linq 7.0.0.0 Linq/Enumerable#Where().
'                                                                               ^ definition local 7
'                                                                                 documentation ```vb\nt As (F1 As Integer, F2 As Integer)\n```
'                                                                                  ^ reference local 7
'                                                                                    ^^ reference local 9
          End Sub

          Private Function MultipleInitializers() As Integer
'                          ^^^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MultipleInitializers().
'                                               documentation ```vb\nPrivate Function Statements.MultipleInitializers() As Integer\n```
              Dim a As Integer = 1, b As Integer = 2
'                 ^ definition local 10
'                   documentation ```vb\na As Integer\n```
'                                   ^ definition local 11
'                                     documentation ```vb\nb As Integer\n```
              Return a + b
'                    ^ reference local 10
'                        ^ reference local 11
          End Function

          Class MyDisposable
'               ^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MyDisposable#
'                            documentation ```vb\nClass MyDisposable\n```
'                            relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/IDisposable#
              Implements IDisposable
'                        ^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/IDisposable#

              Private Sub Dispose() Implements IDisposable.Dispose
'                         ^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MyDisposable#Dispose().
'                                 documentation ```vb\nPrivate Sub MyDisposable.Dispose()\n```
'                                 relationship implementation reference scip-dotnet nuget System.Runtime 7.0.0.0 System/IDisposable#Dispose().
'                                              ^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/IDisposable#
'                                                          ^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/IDisposable#Dispose().
                  Throw New NotImplementedException()
'                           ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
              End Sub
          End Class

          Private Function [Using]() As MyDisposable
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Using().
'                                  documentation ```vb\nPrivate Function Statements.Using() As MyDisposable\n```
'                                       ^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Statements#MyDisposable#
              Dim b = New MyDisposable()
'                 ^ definition local 12
'                   documentation ```vb\nb As Class MyDisposable\n```
'                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . VBMain/Statements#MyDisposable#

              Using a = b
'                   ^ definition local 13
'                     documentation ```vb\na As Class MyDisposable\n```
'                       ^ reference local 12
                  Return a
'                        ^ reference local 13
              End Using
          End Function

          Private Function MultipleUsing() As Long
'                          ^^^^^^^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#MultipleUsing().
'                                        documentation ```vb\nPrivate Function Statements.MultipleUsing() As Long\n```
              Using a As Stream = File.OpenRead("a"), b As Stream = File.OpenRead("a")
'                   ^ definition local 14
'                     documentation ```vb\na As Class Stream\n```
'                        ^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/Stream#
'                                 ^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/File#
'                                      ^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/File#OpenRead().
'                                                     ^ definition local 15
'                                                       documentation ```vb\nb As Class Stream\n```
'                                                          ^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/Stream#
'                                                                   ^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/File#
'                                                                        ^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/File#OpenRead().
                  Return a.Length + b.Length
'                        ^ reference local 14
'                          ^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/Stream#Length.
'                                   ^ reference local 15
'                                     ^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 IO/Stream#Length.
              End Using
          End Function

          Private Function Foreach() As Integer
'                          ^^^^^^^ definition scip-dotnet nuget . . VBMain/Statements#Foreach().
'                                  documentation ```vb\nPrivate Function Statements.Foreach() As Integer\n```
          Dim y = New Integer() {1}
'             ^ definition local 16
'               documentation ```vb\ny As Integer()\n```
              Dim z = 0
'                 ^ definition local 17
'                   documentation ```vb\nz As Integer\n```

              For Each x As Integer In y
'                      ^ definition local 18
'                        documentation ```vb\nx As Integer\n```
'                                      ^ reference local 16
                  z += x
'                 ^ reference local 17
'                      ^ reference local 18
              Next

              Return z
'                    ^ reference local 17
          End Function

      End Class
  End Namespace

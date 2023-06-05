  Module Program
'        ^^^^^^^ definition scip-dotnet nuget . . VBMain/Program#
'                documentation ```vb\nModule Program\n```
      Sub Main(args As String())
'         ^^^^ definition scip-dotnet nuget . . VBMain/Program#Main().
'              documentation ```vb\nPublic Sub Program.Main(args As String())\n```
'              ^^^^ definition scip-dotnet nuget . . VBMain/Program#Main().(args)
'                   documentation ```vb\nargs As String()\n```

          Console.WriteLine("Hello, World!")
'         ^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#
'                 ^^^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#WriteLine(+11).
      End Sub
  End Module

  namespace SlnxTest;
//          ^^^^^^^^ reference scip-dotnet nuget . . SlnxTest/

  public class Greeter
//             ^^^^^^^ definition scip-dotnet nuget . . SlnxTest/Greeter#
//                     documentation ```cs\nclass Greeter\n```
  {
      public string Greet(string name) => $"Hello, {name}!";
//                  ^^^^^ definition scip-dotnet nuget . . SlnxTest/Greeter#Greet().
//                        documentation ```cs\npublic string Greeter.Greet(string name)\n```
//                               ^^^^ definition scip-dotnet nuget . . SlnxTest/Greeter#Greet().(name)
//                                    documentation ```cs\nstring name\n```
//                                                  ^^^^ reference scip-dotnet nuget . . SlnxTest/Greeter#Greet().(name)
  }

  public static class Program
//                    ^^^^^^^ definition scip-dotnet nuget . . SlnxTest/Program#
//                            documentation ```cs\nclass Program\n```
  {
      public static void Main()
//                       ^^^^ definition scip-dotnet nuget . . SlnxTest/Program#Main().
//                            documentation ```cs\npublic static void Program.Main()\n```
      {
          var greeter = new Greeter();
//            ^^^^^^^ definition local 0
//                    documentation ```cs\nGreeter? greeter\n```
//                          ^^^^^^^ reference scip-dotnet nuget . . SlnxTest/Greeter#
          Console.WriteLine(greeter.Greet("World"));
//        ^^^^^^^ reference scip-dotnet nuget System.Console 10.0.0.0 System/Console#
//                ^^^^^^^^^ reference scip-dotnet nuget System.Console 10.0.0.0 System/Console#WriteLine(+11).
//                          ^^^^^^^ reference local 0
//                                  ^^^^^ reference scip-dotnet nuget . . SlnxTest/Greeter#Greet().
      }
  }

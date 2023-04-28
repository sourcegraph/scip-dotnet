  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  public class Events
//             ^^^^^^ definition scip-dotnet nuget . . Main/Events#
//                    documentation ```cs\nclass Events\n```
  {
      public event EventHandler<int> Event1
//                                   ^^^^^^ definition scip-dotnet nuget . . Main/Events#Event1#
//                                          documentation ```cs\npublic event EventHandler<int> Events.Event1\n```
      {
          add { }
          remove { }
      }

      public event EventHandler Event2
//                              ^^^^^^ definition scip-dotnet nuget . . Main/Events#Event2#
//                                     documentation ```cs\npublic event EventHandler Events.Event2\n```
      {
          add => addSomething();
//               ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Events#addSomething().
          remove => removeSomething();
//                  ^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Events#removeSomething().
      }

      private void removeSomething()
//                 ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Events#removeSomething().
//                                 documentation ```cs\nprivate void Events.removeSomething()\n```
      {
          throw new NotImplementedException();
      }

      private void addSomething()
//                 ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Events#addSomething().
//                              documentation ```cs\nprivate void Events.addSomething()\n```
      {
          throw new NotImplementedException();
      }
  }

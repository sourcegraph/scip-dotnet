  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Events
//             ^^^^^^ definition scip-dotnet nuget . . Main/Events#
//                    documentation ```cs\nclass Main.Events\n```
//                    relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
  {
      public event EventHandler<int> Event1
//                                   ^^^^^^ definition scip-dotnet nuget . . Main/Events#Event1#
//                                          documentation ```cs\npublic event System.EventHandler<System.Int32> Main.Events.Event1\n```
      {
          add { }
          remove { }
      }
  
      public event EventHandler Event2
//                 ^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/EventHandler#
//                              ^^^^^^ definition scip-dotnet nuget . . Main/Events#Event2#
//                                     documentation ```cs\npublic event System.EventHandler Main.Events.Event2\n```
      {
          add => addSomething();
//               ^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Events#addSomething().
          remove => removeSomething();
//                  ^^^^^^^^^^^^^^^ reference scip-dotnet nuget . . Main/Events#removeSomething().
      }
  
      private void removeSomething()
//                 ^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Events#removeSomething().
//                                 documentation ```cs\nprivate void Main.Events.removeSomething()\n```
      {
          throw new NotImplementedException();
//                  ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
      }
  
      private void addSomething()
//                 ^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Events#addSomething().
//                              documentation ```cs\nprivate void Main.Events.addSomething()\n```
      {
          throw new NotImplementedException();
//                  ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
      }
  }

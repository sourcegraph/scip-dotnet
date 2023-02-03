  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Interfaces
//             ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#
//                        documentation ```cs\nclass Main.Interfaces\n```
//                        relationship implementation scip-dotnet nuget System.Runtime 7.0.0.0 System/Object#
  {
      public interface IOne
//                     ^^^^ definition scip-dotnet nuget . . Main/Interfaces#IOne#
//                          documentation ```cs\ninterface Main.Interfaces.IOne\n```
      {
      };
  
      public interface ITwo
//                     ^^^^ definition scip-dotnet nuget . . Main/Interfaces#ITwo#
//                          documentation ```cs\ninterface Main.Interfaces.ITwo\n```
      {
      };
  
      public interface IThree
//                     ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IThree#
//                            documentation ```cs\ninterface Main.Interfaces.IThree\n```
      {
      };
  
      public interface IProperties
//                     ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#
//                                 documentation ```cs\ninterface Main.Interfaces.IProperties\n```
      {
          byte Get { get; }
//             ^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#Get.
//                 documentation ```cs\nSystem.Byte Main.Interfaces.IProperties.Get { get; }\n```
          char Set { set; }
//             ^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#Set.
//                 documentation ```cs\nSystem.Char Main.Interfaces.IProperties.Set { set; }\n```
          uint GetSet { get; set; }
//             ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#GetSet.
//                    documentation ```cs\nSystem.UInt32 Main.Interfaces.IProperties.GetSet { get; set; }\n```
          long SetGet { set; get; }
//             ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#SetGet.
//                    documentation ```cs\nSystem.Int64 Main.Interfaces.IProperties.SetGet { get; set; }\n```
      }
  
      interface IMethods
//              ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#
//                       documentation ```cs\ninterface Main.Interfaces.IMethods\n```
      {
          void Nothing();
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Nothing().
//                     documentation ```cs\nvoid Main.Interfaces.IMethods.Nothing()\n```
          int Output();
//            ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Output().
//                   documentation ```cs\nSystem.Int32 Main.Interfaces.IMethods.Output()\n```
          void Input(string a);
//             ^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Input().
//                   documentation ```cs\nvoid Main.Interfaces.IMethods.Input(System.String a)\n```
//                          ^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Input().(a)
//                            documentation ```cs\nSystem.String a\n```
          int InputOutput(string a);
//            ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#InputOutput().
//                        documentation ```cs\nSystem.Int32 Main.Interfaces.IMethods.InputOutput(System.String a)\n```
//                               ^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#InputOutput().(a)
//                                 documentation ```cs\nSystem.String a\n```
      };
  
      interface IEvent
//              ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IEvent#
//                     documentation ```cs\ninterface Main.Interfaces.IEvent\n```
      {
          event EventHandler<int> SomeEvent;
//                                ^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IEvent#SomeEvent#
//                                          documentation ```cs\nevent System.EventHandler<System.Int32> Main.Interfaces.IEvent.SomeEvent\n```
      }
  
      interface IIndex
//              ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IIndex#
//                     documentation ```cs\ninterface Main.Interfaces.IIndex\n```
      {
          bool this[int index] { get; set; }
//                      ^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IIndex#`this[]`.(index)
//                            documentation ```cs\nSystem.Int32 index\n```
      }
  
      interface IDefault
//              ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IDefault#
//                       documentation ```cs\ninterface Main.Interfaces.IDefault\n```
      {
          void Log(string message)
//             ^^^ definition scip-dotnet nuget . . Main/Interfaces#IDefault#Log().
//                 documentation ```cs\nvoid Main.Interfaces.IDefault.Log(System.String message)\n```
//                        ^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IDefault#Log().(message)
//                                documentation ```cs\nSystem.String message\n```
          {
              Console.WriteLine(message);
//            ^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#
//                    ^^^^^^^^^ reference scip-dotnet nuget System.Console 7.0.0.0 System/Console#WriteLine(+11).
//                              ^^^^^^^ reference scip-dotnet nuget . . Main/Interfaces#IDefault#Log().(message)
          }
      }
  
  
      private interface IInherit : IOne, ITwo
//                      ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IInherit#
//                               documentation ```cs\ninterface Main.Interfaces.IInherit\n```
//                               relationship implementation scip-dotnet nuget . . Main/Interfaces#IOne#
//                               relationship implementation scip-dotnet nuget . . Main/Interfaces#ITwo#
//                                 ^^^^ reference scip-dotnet nuget . . Main/Interfaces#IOne#
//                                       ^^^^ reference scip-dotnet nuget . . Main/Interfaces#ITwo#
      {
      }
  
      public interface IGetNext<T> where T : IGetNext<T>
//                     ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IGetNext#
//                              documentation ```cs\ninterface Main.Interfaces.IGetNext<T> where T : Main.Interfaces.IGetNext<T>\n```
//                                       ^ reference scip-dotnet nuget . . Main/Interfaces#IGetNext#[T]
//                                                    ^ reference scip-dotnet nuget . . Main/Interfaces#IGetNext#[T]
      {
          static T operator ++(IGetNext<T> other)
//               ^ reference scip-dotnet nuget . . Main/Interfaces#IGetNext#[T]
//                                      ^ reference scip-dotnet nuget . . Main/Interfaces#IGetNext#[T]
//                                         ^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IGetNext#op_Increment().(other)
//                                               documentation ```cs\nMain.Interfaces.IGetNext<T> other\n```
          {
              throw new NotImplementedException();
//                      ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 System/NotImplementedException#
          }
      }
  
      private interface ITypeParameter<T1, T2> : ITwo where T1 : IOne where T2 : IThree
//                      ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#ITypeParameter#
//                                     documentation ```cs\ninterface Main.Interfaces.ITypeParameter<T1, T2> where T1 : Main.Interfaces.IOne where T2 : Main.Interfaces.IThree\n```
//                                     relationship implementation scip-dotnet nuget . . Main/Interfaces#ITwo#
//                                               ^^^^ reference scip-dotnet nuget . . Main/Interfaces#ITwo#
//                                                          ^^ reference scip-dotnet nuget . . Main/Interfaces#ITypeParameter#[T1]
//                                                               ^^^^ reference scip-dotnet nuget . . Main/Interfaces#IOne#
//                                                                          ^^ reference scip-dotnet nuget . . Main/Interfaces#ITypeParameter#[T2]
//                                                                               ^^^^^^ reference scip-dotnet nuget . . Main/Interfaces#IThree#
      {
      }
  }

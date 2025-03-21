  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Interfaces
//             ^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#
//                        documentation ```cs\nclass Interfaces\n```
  {
      public interface IOne
//                     ^^^^ definition scip-dotnet nuget . . Main/Interfaces#IOne#
//                          documentation ```cs\ninterface IOne\n```
      {
      };

      public interface ITwo
//                     ^^^^ definition scip-dotnet nuget . . Main/Interfaces#ITwo#
//                          documentation ```cs\ninterface ITwo\n```
      {
      };

      public interface IThree
//                     ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IThree#
//                            documentation ```cs\ninterface IThree\n```
      {
      };

      public interface IProperties
//                     ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#
//                                 documentation ```cs\ninterface IProperties\n```
      {
          byte Get { get; }
//             ^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#Get.
//                 documentation ```cs\nbyte IProperties.Get { get; }\n```
          char Set { set; }
//             ^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#Set.
//                 documentation ```cs\nchar IProperties.Set { set; }\n```
          uint GetSet { get; set; }
//             ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#GetSet.
//                    documentation ```cs\nuint IProperties.GetSet { get; set; }\n```
          long SetGet { set; get; }
//             ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IProperties#SetGet.
//                    documentation ```cs\nlong IProperties.SetGet { get; set; }\n```
      }

      interface IMethods
//              ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#
//                       documentation ```cs\ninterface IMethods\n```
      {
          void Nothing();
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Nothing().
//                     documentation ```cs\nvoid IMethods.Nothing()\n```
          int Output();
//            ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Output().
//                   documentation ```cs\nint IMethods.Output()\n```
          void Input(string a);
//             ^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Input().
//                   documentation ```cs\nvoid IMethods.Input(string a)\n```
//                          ^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#Input().(a)
//                            documentation ```cs\nstring a\n```
          int InputOutput(string a);
//            ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#InputOutput().
//                        documentation ```cs\nint IMethods.InputOutput(string a)\n```
//                               ^ definition scip-dotnet nuget . . Main/Interfaces#IMethods#InputOutput().(a)
//                                 documentation ```cs\nstring a\n```
      };

      interface IEvent
//              ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IEvent#
//                     documentation ```cs\ninterface IEvent\n```
      {
          event EventHandler<int> SomeEvent;
//                                ^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IEvent#SomeEvent#
//                                          documentation ```cs\nevent EventHandler<int> IEvent.SomeEvent\n```
      }

      interface IIndex
//              ^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IIndex#
//                     documentation ```cs\ninterface IIndex\n```
      {
          bool this[int index] { get; set; }
//                      ^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IIndex#`this[]`.(index)
//                            documentation ```cs\nint index\n```
      }

      interface IDefault
//              ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IDefault#
//                       documentation ```cs\ninterface IDefault\n```
      {
          void Log(string message)
//             ^^^ definition scip-dotnet nuget . . Main/Interfaces#IDefault#Log().
//                 documentation ```cs\nvoid IDefault.Log(string message)\n```
//                        ^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IDefault#Log().(message)
//                                documentation ```cs\nstring message\n```
          {
              Console.WriteLine(message);
//            ^^^^^^^ reference scip-dotnet nuget System.Console 9.0.0.0 System/Console#
//                    ^^^^^^^^^ reference scip-dotnet nuget System.Console 9.0.0.0 System/Console#WriteLine(+11).
//                              ^^^^^^^ reference scip-dotnet nuget . . Main/Interfaces#IDefault#Log().(message)
          }
      }


      private interface IInherit : IOne, ITwo
//                      ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IInherit#
//                               documentation ```cs\ninterface IInherit\n```
//                               relationship implementation scip-dotnet nuget . . Main/Interfaces#IOne#
//                               relationship implementation scip-dotnet nuget . . Main/Interfaces#ITwo#
//                                 ^^^^ reference scip-dotnet nuget . . Main/Interfaces#IOne#
//                                       ^^^^ reference scip-dotnet nuget . . Main/Interfaces#ITwo#
      {
      }

      public interface IGetNext<T> where T : IGetNext<T>
//                     ^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IGetNext#
//                              documentation ```cs\ninterface IGetNext<T> where T : IGetNext<T>\n```
//                              ^ definition local 0
//                                documentation ```cs\nT\n```
//                                       ^ reference local 0
//                                                    ^ reference local 0
      {
          static IGetNext<T> operator ++(IGetNext<T> other)
//                        ^ reference local 0
//                                                ^ reference local 0
//                                                   ^^^^^ definition scip-dotnet nuget . . Main/Interfaces#IGetNext#op_Increment().(other)
//                                                         documentation ```cs\nIGetNext<T> other\n```
          {
              throw new NotImplementedException();
//                      ^^^^^^^^^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 9.0.0.0 System/NotImplementedException#
          }
      }

      private interface ITypeParameter<T1, T2> : ITwo where T1 : IOne where T2 : IThree
//                      ^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Interfaces#ITypeParameter#
//                                     documentation ```cs\ninterface ITypeParameter<T1, T2> where T1 : IOne where T2 : IThree\n```
//                                     relationship implementation scip-dotnet nuget . . Main/Interfaces#ITwo#
//                                     ^^ definition local 1
//                                        documentation ```cs\nT1\n```
//                                         ^^ definition local 2
//                                            documentation ```cs\nT2\n```
//                                               ^^^^ reference scip-dotnet nuget . . Main/Interfaces#ITwo#
//                                                          ^^ reference local 1
//                                                               ^^^^ reference scip-dotnet nuget . . Main/Interfaces#IOne#
//                                                                          ^^ reference local 2
//                                                                               ^^^^^^ reference scip-dotnet nuget . . Main/Interfaces#IThree#
      {
      }
  }

  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/
  
  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 6.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Structs
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Structs#
//                     documentation ```cs\nclass Main.Structs\n```
//                     relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
  {
      struct BasicStruct
//           ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Structs#BasicStruct#
//                       documentation ```cs\nstruct Main.Structs.BasicStruct\n```
//                       relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/ValueType#
//                       relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
      {
          public int Property1;
//                   ^^^^^^^^^ definition scip-dotnet nuget . . Main/Structs#BasicStruct#Property1.
//                             documentation ```cs\npublic System.Int32 Main.Structs.BasicStruct.Property1\n```
  
          public BasicStruct(int field1)
//               ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Structs#BasicStruct#`.ctor`().
//                           documentation ```cs\npublic Main.Structs.BasicStruct.BasicStruct(System.Int32 field1)\n```
//                               ^^^^^^ definition scip-dotnet nuget . . Main/Structs#BasicStruct#`.ctor`().(field1)
//                                      documentation ```cs\nSystem.Int32 field1\n```
          {
              Property1 = field1;
//            ^^^^^^^^^ reference scip-dotnet nuget . . Main/Structs#BasicStruct#Property1.
//                        ^^^^^^ reference scip-dotnet nuget . . Main/Structs#BasicStruct#`.ctor`().(field1)
          }
      }
  }

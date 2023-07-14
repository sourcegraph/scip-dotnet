  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 7.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Structs
//             ^^^^^^^ definition scip-dotnet nuget . . Main/Structs#
//                     documentation ```cs\nclass Structs\n```
  {
      struct BasicStruct
//           ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Structs#BasicStruct#
//                       documentation ```cs\nstruct BasicStruct\n```
      {
          public int Property1;
//                   ^^^^^^^^^ definition scip-dotnet nuget . . Main/Structs#BasicStruct#Property1.
//                             documentation ```cs\npublic int BasicStruct.Property1\n```

          public BasicStruct(int field1)
//               ^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Structs#BasicStruct#`.ctor`().
//                           documentation ```cs\npublic BasicStruct.BasicStruct(int field1)\n```
//                               ^^^^^^ definition local 0
//                                      documentation ```cs\nint field1\n```
          {
              Property1 = field1;
//            ^^^^^^^^^ reference scip-dotnet nuget . . Main/Structs#BasicStruct#Property1.
//                        ^^^^^^ reference local 0
          }
      }
  }

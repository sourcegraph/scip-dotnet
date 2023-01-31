  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/
  
  public class Enums
//             ^^^^^ definition scip-dotnet nuget . . Main/Enums#
//                   documentation ```cs\nclass Main.Enums\n```
//                   relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
  {
      enum EnumWithIntValues
//         ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#
//                           documentation ```cs\nenum Main.Enums.EnumWithIntValues\n```
//                           relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Enum#
//                           relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/ValueType#
//                           relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                           relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IComparable#
//                           relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IConvertible#
//                           relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IFormattable#
      {
          Ten = 10,
//        ^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#Ten.
//            documentation ```cs\nMain.Enums.EnumWithIntValues.Ten = 10\n```
          Twenty = 20
//        ^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#Twenty.
//               documentation ```cs\nMain.Enums.EnumWithIntValues.Twenty = 20\n```
      }
  
      enum EnumWithByteValues
//         ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#
//                            documentation ```cs\nenum Main.Enums.EnumWithByteValues\n```
//                            relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Enum#
//                            relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/ValueType#
//                            relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/Object#
//                            relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IComparable#
//                            relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IConvertible#
//                            relationship implementation scip-dotnet nuget System.Runtime 6.0.0.0 System/IFormattable#
      {
          Five = 0x05,
//        ^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#Five.
//             documentation ```cs\nMain.Enums.EnumWithByteValues.Five = 5\n```
          Fifteen = 0x0F
//        ^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#Fifteen.
//                documentation ```cs\nMain.Enums.EnumWithByteValues.Fifteen = 15\n```
      }
  }

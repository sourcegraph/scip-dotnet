  using System.Diagnostics.CodeAnalysis;
//      ^^^^^^ reference scip-dotnet nuget . . System/
//             ^^^^^^^^^^^ reference scip-dotnet nuget . . Diagnostics/
//                         ^^^^^^^^^^^^ reference scip-dotnet nuget . . CodeAnalysis/

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
// ^^^^^^^^^^^^^^^ reference scip-dotnet nuget System.Runtime 8.0.0.0 CodeAnalysis/SuppressMessageAttribute#`.ctor`().
  public class Enums
//             ^^^^^ definition scip-dotnet nuget . . Main/Enums#
//                   documentation ```cs\nclass Enums\n```
  {
      enum EnumWithIntValues
//         ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#
//                           documentation ```cs\nenum EnumWithIntValues\n```
//                           relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IComparable#
//                           relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IConvertible#
//                           relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/ISpanFormattable#
//                           relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IFormattable#
      {
          Ten = 10,
//        ^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#Ten.
//            documentation ```cs\nEnumWithIntValues.Ten = 10\n```
          Twenty = 20
//        ^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#Twenty.
//               documentation ```cs\nEnumWithIntValues.Twenty = 20\n```
      }

      enum EnumWithByteValues
//         ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#
//                            documentation ```cs\nenum EnumWithByteValues\n```
//                            relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IComparable#
//                            relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IConvertible#
//                            relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/ISpanFormattable#
//                            relationship implementation scip-dotnet nuget System.Runtime 8.0.0.0 System/IFormattable#
      {
          Five = 0x05,
//        ^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#Five.
//             documentation ```cs\nEnumWithByteValues.Five = 5\n```
          Fifteen = 0x0F
//        ^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#Fifteen.
//                documentation ```cs\nEnumWithByteValues.Fifteen = 15\n```
      }
  }

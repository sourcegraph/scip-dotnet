  using System.Diagnostics.CodeAnalysis;

  namespace Main;
//          ^^^^ reference scip-dotnet nuget . . Main/

  [SuppressMessage("ReSharper", "all")]
  public class Enums
//             ^^^^^ definition scip-dotnet nuget . . Main/Enums#
//                   documentation ```cs\nclass Enums\n```
  {
      enum EnumWithIntValues
//         ^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#
//                           documentation ```cs\nenum EnumWithIntValues\n```
      {
          Ten = 10,
//        ^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#Ten.
//            documentation ```cs\nEnumWithIntValues.Ten\n```
          Twenty = 20
//        ^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithIntValues#Twenty.
//               documentation ```cs\nEnumWithIntValues.Twenty\n```
      }

      enum EnumWithByteValues
//         ^^^^^^^^^^^^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#
//                            documentation ```cs\nenum EnumWithByteValues\n```
      {
          Five = 0x05,
//        ^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#Five.
//             documentation ```cs\nEnumWithByteValues.Five\n```
          Fifteen = 0x0F
//        ^^^^^^^ definition scip-dotnet nuget . . Main/Enums#EnumWithByteValues#Fifteen.
//                documentation ```cs\nEnumWithByteValues.Fifteen\n```
      }
  }

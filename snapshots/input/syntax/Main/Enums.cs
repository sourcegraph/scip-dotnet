using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Enums
{
    enum EnumWithIntValues
    {
        Ten = 10,
        Twenty = 20
    }

    enum EnumWithByteValues
    {
        Five = 0x05,
        Fifteen = 0x0F
    }
}
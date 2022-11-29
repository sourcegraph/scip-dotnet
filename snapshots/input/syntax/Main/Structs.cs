using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Structs
{
    struct BasicStruct
    {
        public int Property1;

        public BasicStruct(int field1)
        {
            Property1 = field1;
        }
    }
}
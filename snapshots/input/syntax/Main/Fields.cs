using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Fields
{
    class Fields1
    {
        private readonly int Property1;
        private Int64 Property2, Property3;
        private Tuple<char, Nullable<int>> Property4;

        public Fields1(long field2, long field3, Tuple<char, int?> field4, int field1)
        {
            Property2 = field2;
            Property3 = field3;
            Property4 = field4;
            Property1 = field1;
        }
    }

    class Fields2
    {
        // Function pointer equivalent without calling convention
        unsafe delegate*<string, int> a;
        unsafe delegate*<delegate*<in string, int>, delegate*<ref string, ref readonly int>> b;

        // Function pointer equivalent with calling convention
        unsafe delegate* managed<string, int> c;
    }
}
using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class GlobalAttributes : Attribute
{
    class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
        }
    }

    [Author("PropertyAttribute")] public int Z;

    [Author("MethodAttribute")]
    int Method1()
    {
        return 0;
    }

    [Author("EnumAttribute")]
    enum A
    {
        B,
        C
    }

    [Author("EventAttribute")]
    public event EventHandler SomeEvent
    {
        add { }
        remove { }
    }

    [Author("TypeParameterAttribute")]
    public class InnerClass<[Author("ClassTypeParameter")] T>
    {
        void Method<[Author("MethodTypeParameter")] T2>()
        {
        }
    }
}
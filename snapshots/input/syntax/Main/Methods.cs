using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Methods
{
    int SingleParameter(int b)
    {
        return b;
    }

    int TwoParameters(int a, int b)
    {
        return a + b;
    }

    int Overload1(int a)
    {
        return a;
    }

    int Overload1(int a, int b)
    {
        return a + b;
    }

    T Generic<T>(T param)
    {
        return param;
    }

    T GenericConstraint<T>(T param) where T : new()
    {
        return param;
    }

    void DefaultParameter(int a = 5)
    {
    }

    int DefaultParameterOverload(int a = 5)
    {
        return DefaultParameterOverload(a, a);
    }

    int DefaultParameterOverload(int a, int b)
    {
        return DefaultParameterOverload();
    }

    interface IHello
    {
        string Hello();
    }

    class ImplementsHello : IHello
    {
        string IHello.Hello()
        {
            return "";
        }
    }

    class InheritedOverloads1
    {
        public void Method()
        {
        }
    }

    class InheritedOverloads2 : InheritedOverloads1
    {
        public int Method(int parameter)
        {
            return parameter;
        }
    }

    class InheritedOverloads3 : InheritedOverloads2
    {
        public string Method(string parameter)
        {
            return parameter;
        }
    }

    public static void InheritedOverloads()
    {
        new InheritedOverloads1().Method();
        new InheritedOverloads2().Method();
        new InheritedOverloads2().Method(42);
        new InheritedOverloads3().Method();
        new InheritedOverloads3().Method(42);
        new InheritedOverloads3().Method("42");
    }

}
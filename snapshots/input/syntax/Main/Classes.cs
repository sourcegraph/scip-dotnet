using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Classes
{
    public string Name;
    public const int IntConstant = 1;
    public const string StringConstant = $"hello";

    public Classes(int name)
    {
        Name = "name";
    }

    public Classes(string name) => Name = name;

    ~Classes()
    {
        Console.WriteLine(42);
    }

    public class ObjectClass : object, SomeInterface
    {
    }

    public partial class PartialClass
    {
    }

    class TypeParameterClass<T>
    {
    }

    internal class InternalMultipleTypeParametersClass<T1, T2>
    {
    }

    interface ICovariantContravariant<in T1, out T2>
    {
        public void Method1(T1 t1)
        {
            Console.WriteLine(t1);
        }

        public T2? Method2()
        {
            return default(T2);
        }
    }

    public class StructConstraintClass<T> where T : struct
    {
    }

    public class UnmanagedConstraintClass<T> where T : unmanaged
    {
    }

    public class ClassConstraintClass<T> where T : class
    {
    }

    public class NonNullableConstraintClass<T> where T : notnull
    {
    }

    public class NewConstraintClass<T> where T : new()
    {
    }

    public class TypeParameterConstraintClass<T> where T : SomeInterface
    {
    }

    private class MultipleTypeParameterConstraintsClass<T1, T2> where T1 : SomeInterface, SomeInterface2, new()
        where T2 : SomeInterface2
    {
    }

    class IndexClass
    {
        private bool a;

        public bool this[int index]
        {
            get { return a; }
            set { a = value; }
        }
    }

}

public interface SomeInterface
{
}

internal interface SomeInterface2
{
}
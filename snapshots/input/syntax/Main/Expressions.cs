using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Expressions
{
    void AssignmentToPrefixUnaryExpressions()
    {
        var a = 42;
        var b = 42;
        a = +a;
        a = -a;
        a = ~a;
        a = ++a;
        a = --a;
        a = a++;
        a = a--;
        b = a!;

        var c = true;
        c = !c;
    }

    void AssignmentToPrefixBinaryExpressions()
    {
        var a = 42;
        a = a + a;
        a = a - a;
        a = a * a;
        a = a / a;
        a = a % a;
        a = a & a;
        a = a | a;
        a = a ^ a;
        a = a >> a;
        a = a << a;
        a = a >>> a;
    }

    void AssignmentToBinaryEqualityExpression()
    {
        var a = true;
        var b = true;
        var c = 42;
        var d = 42;
        a = a == b;
        a = a != b;
        a = c < d;
        a = c <= d;
        a = c > d;
        a = c >= d;
    }

    void AssignmentToBinaryExpression()
    {
        var a = 42;
        a += a;
        a -= a;
        a *= a;
        a /= a;
        a %= a;
        a++;
        a--;
        a <<= a;
        a >>= a;
        a >>>= a;
    }

    struct Struct
    {
        public int Property;
    }

    struct IndexedClass
    {
        public int Property;

        public int this[int index]
        {
            get { return Property; }
            set { Property = value; }
        }
    }

    void AssignmentToLeftValueTypes()
    {
        (var a, var b) = (1, 2);
        a = 1;
        var c = new Struct { Property = 42 };
        c.Property = 1;
        var d = new IndexedClass();
        d[b] = 1;
        (a, b) = (1, 2);
        var x = new IndexedClass
        {
            Property = 1,
            [b] = 1
        };
        (a) = 1;
        unsafe
        {
            int myInt = 5;
            int* p = &myInt;
            Console.WriteLine("myInt = {0}, *p = {1}", myInt, *p);
        }
    }

    void TernaryExpression()
    {
        var x = true;
        var y = x ? "foo" : "bar";
        object z = true;
        var t = z is bool ? 42 : 41;
    }

    class Cast
    {
        public Cast nested;
        public Cast2 nested2;

        public Cast plus(Cast other)
        {
            nested = other;
            return this;
        }

        public class Cast2
        {
        }
    }

    int CastExpressions()
    {
        object a = new Cast();
        object b = new Cast();
        Cast c = ((Cast)a).plus((Cast)b);
        Cast d = (Cast)new object[] { a, b }[0];
        var e = (Cast.Cast2)(c.nested.nested2);
        var f = (Int32)(1);
        var g = (Int32)(1);
        var h = (Int32)((1));
        return f + g + h;
    }

    object AnonymousObject()
    {
        var x = new { Helper = "" };
        var y = new
        {
            x
        };
        return y.x.Helper;
    }

    class TargetType
    {
        public TargetType(string name)
        {
        }
    }

    TargetType TargetTypeNew()
    {
        TargetType x = new("x");
        return x;
    }

    int Checked()
    {
        var three = checked(1 + 2);
        return three;
    }

    class ObjectCreationClass
    {
        public D field;

        public ObjectCreationClass(D field)
        {
            this.field = field;
        }

        public class D
        {
            public D(int a, string b)
            {
            }
        }
    }

    void ObjectCreation()
    {
        var a = new ObjectCreationClass.D(1, "hi");
        var b = new ObjectCreationClass(a)
        {
            field = a,
        };
        b = new ObjectCreationClass(a);
        b = new ObjectCreationClass(a) { };
    }

    class NamedParametersClass
    {
        public int A;
        public string B;

        public NamedParametersClass(int a, string b)
        {
            A = a;
            B = b;
        }

        public void Update(int a, string b)
        {
            A = a;
            B = b;
        }
    }

    NamedParametersClass NamedParameters()
    {
        var a = new NamedParametersClass(b: "hi", a: 1);
        a.Update(b: "foo", a: 42);
        return a;
    }

    Func<int, int> AnonymousFunction()
    {
        var d = delegate (int _, int _) { return 42; };
        return delegate (int a) { return a + d.Invoke(a, a); };
    }

    class Lambda
    {
        public string func(Lambda x)
        {
            return "";
        }
    }

    void LambdaExpressions()
    {
        var a = (string x) => x + 1;
        var b = (Lambda a, Lambda b) => { return a.func(b); };
        var c = string (Lambda a, Lambda _) => { return a; };
    }

    void TupleExpressions()
    {
        var a = (1, 2, "");
    }

    void ArrayCreation()
    {
        var a = new[,] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
        Span<int> b = stackalloc[] { 1, 2, 3 };
        Span<int> c = stackalloc int[] { 1, 2, 3 };
        var d = new int[3] { 1, 2, 3 };
        var e = new byte[,] { { 1, 2 }, { 2, 3 } };
        var f = new int[3, 2] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
        var g = new (string b, string c)[3];
    }

    void MakeRef()
    {
        var g = "";
        var a = __makeref(g);
    }

    void SizeOf()
    {
        var a = sizeof(int);
    }

    void TypeOf()
    {
        var a = typeof(int);
        var b = typeof(List<string>.Enumerator);
        var c = typeof(Dictionary<,>);
        var d = typeof(Tuple<,,,>);
    }

    interface IAnimal
    {
        string Sound();
    }

    public class Dog : IAnimal
    {
        public string Sound()
        {
            return "woof";
        }
    }

    public class Cat : IAnimal
    {
        public string Sound()
        {
            return "meow";
        }
    }

    void Switch()
    {
        int some = 42;
        var a = some switch
        {
            1 => "one",
            2 => "two",
            _ => "more"
        };
        IAnimal dog = new Dog();
        var b = dog switch
        {
            Cat c => c.Sound(),
            Dog c => c.Sound(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    void Dictionary()
    {
        var a = new Dictionary<string, int> { ["a"] = 65 };
    }

    void Is()
    {
        object s = "s";
        if (s is string s2)
        {
            Console.WriteLine(s2);
        }

        var c = s is "test";
        var a = s is int.MaxValue;
        var d = s is nameof(a);
    }
}
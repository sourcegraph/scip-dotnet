using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Statements
{
    void Try()
    {
        try
        {
            File.ReadLines("asd");
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
        }
    }

    (string a, bool b) Default()
    {
        (string a, bool b) c = default;
        return c;
    }

    void Deconstruction()
    {
        var point = (1, 2);
        int x = 0;
        (x, int y) = point;
    }

    record Inferred(int F1, int F2);

    void InferredTuples()
    {
        var list = new List<Inferred>();
        var result = list.Select(c => (c.F1, c.F2)).Where(t => t.F2 == 1);
    }

    int MultipleInitializers()
    {
        int a = 1, b = 2;
        return a + b;
    }

    void RefVariable()
    {
        var data = new int[] { 1, 2 };
        ref var value = ref data[0];
    }

    class MyDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }

    MyDisposable Using()
    {
        var b = new MyDisposable();
        using (var a = b)
        {
            return a;
        }
    }

    long MultipleUsing()
    {
        using (Stream a = File.OpenRead("a"), b = File.OpenRead("a"))
        {
            return a.Length + b.Length;
        }
    }

    int Foreach()
    {
        var y = new int[] { 1 };
        var z = 0;
        foreach (int x in y)
            z += x;
        return z;
    }
}
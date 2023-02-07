using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Literals
{
    string Interpolation()
    {
        var a = 1;
        var b = 2;
        var c = 3;
        var d = 3;
        return $"a={a} b={b:0.00} c={c,24} d={d:g}";
    }
}
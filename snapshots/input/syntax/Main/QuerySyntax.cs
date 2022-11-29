using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class QuerySyntax
{
    List<IGeneric> sourceA = new List<IGeneric>();
    List<IGeneric> sourceB = new List<IGeneric>();

    interface IGeneric
    {
        string Method();
    }

    void Select()
    {
        var x = from a in sourceA select a.Method();
    }

    void Projection()
    {
        var x = from a in sourceA select new { Name = a.Method() };
        var b = from a in x select a.Name;
    }

    void Where()
    {
        var x = from a in sourceA where a.Method().StartsWith("a") select a;
    }

    void Let()
    {
        var x = from a in sourceA
                let z = new { A = a.Method(), B = a.Method() }
                select z;
    }

    void Join()
    {
        var x = from a in sourceA
                join b in sourceB on a.Method() equals b.Method()
                select new { A = a.Method(), B = b.Method() };
    }

    void MultipleFrom()
    {
        var x = from a in sourceA
                from b in sourceB
                where a.Method() == b.Method()
                select new { A = a.Method(), B = b.Method() };
    }
}
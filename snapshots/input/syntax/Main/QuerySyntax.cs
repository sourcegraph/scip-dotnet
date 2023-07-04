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

    void JoinInto(List<Student> students1, List<Student> students2)
    {
        var innerGroupJoinQuery =
            from student1 in students1
            join student2 in students2 on student1.ID equals student2.ID into studentGroup
            select new { Student = student1.First, Students = studentGroup };
    }

    void Continuation(List<Student> students)
    {
        var sortedGroups =
            from student in students
            orderby student.Last, student.First
            group student by student.Last[0] into newGroup
            orderby newGroup.Key
            select newGroup;
    }

    private class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
    }
}
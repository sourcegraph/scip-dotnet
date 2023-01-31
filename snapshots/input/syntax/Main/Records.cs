using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Records
{
    record Basic
    {
        int Age { get; init; }
    }

    record struct Struct
    {
        int Age { get; init; }
    }

    record class Class
    {
        int Age { get; init; }
    }

    public record TypeParameterConstraint<T> where T : struct
    {
    }

    interface I1
    {
    };

    interface I2
    {
    };


    record Person(string FirstName, string LastName) : I1, I2
    {
        public Person(string FirstName) : this(FirstName, FirstName)
        {
        }
    };

    record Teacher(string FirstName, string LastName, string Subject) : Person(FirstName, LastName), I1, I2;

    record I3<T>;

    record Teacher2() : I3<Person>(), I1;

    record SealedToString
    {
        public sealed override string ToString()
        {
            return "";
        }
    }
}
namespace ScipDotnet.Tests;

public record Position(int Line, int Character) : IComparable<Position>
{
    public int CompareTo(Position? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (other.Line != Line)
        {
            return Line - other.Line;
        }

        return Character - other.Character;
    }

}
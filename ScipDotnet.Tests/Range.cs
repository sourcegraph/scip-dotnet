using Scip;

namespace ScipDotnet.Tests;

public record Range(Position Start, Position End) : IComparable<Range>
{
    public int CompareTo(Range? other)
    {
        if (other == null)
        {
            return 1;
        }

        var byStart = Start.CompareTo(other.Start);
        if (byStart != 0)
        {
            return byStart;
        }

        return End.CompareTo(other.End);
    }

    public static Range FromOccurrence(Occurrence occ)
    {
        if (occ.Range.Count == 3)
            return new Range(new Position(occ.Range[0], occ.Range[1]), new Position(occ.Range[0], occ.Range[2]));

        if (occ.Range.Count == 4)
            return new Range(new Position(occ.Range[0], occ.Range[1]), new Position(occ.Range[2], occ.Range[3]));

        throw new ArgumentException($"occurrence.range must have length 3 or length 4, obtained {occ.Range}");
    }
}
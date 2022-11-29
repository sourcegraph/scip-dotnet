using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Operators
{
    class PlusMinus
    {
        public static int operator +(PlusMinus a)
        {
            return 0;
        }

        public static int operator +(PlusMinus a, PlusMinus b)
        {
            return 0;
        }

        public static int operator -(PlusMinus a)
        {
            return 0;
        }
    }

    class TrueFalse
    {
        protected bool Equals(TrueFalse other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TrueFalse)obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator true(TrueFalse a)
        {
            return true;
        }

        public static bool operator false(TrueFalse a)
        {
            return false;
        }

        public static bool operator !=(TrueFalse a, TrueFalse b)
        {
            return true;
        }

        public static bool operator ==(TrueFalse a, TrueFalse b)
        {
            return true;
        }
    }
}
namespace SymbolKinds
{
    public interface IShape
    {
    }

    public struct Point
    {
    }

    public enum Color
    {
        Red
    }

    public delegate void Handler();

    public class Kinds
    {
        public const int Constant = 1;
        public int Field;
        public static int StaticField;

        public Kinds()
        {
        }

        public int Property { get; set; }
        public static int StaticProperty { get; set; }

        public event Handler? Event;
        public static event Handler? StaticEvent;

        public void Method()
        {
        }

        public static void StaticMethod()
        {
        }
    }

    public static class KindsExtensions
    {
        public static void Extension(this Kinds kinds)
        {
        }
    }
}

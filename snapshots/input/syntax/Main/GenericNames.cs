namespace Main;

public static class GenericNames
{
    public static T Create<T>() where T : new() => new T();
    public static T Create<T>(T seed) => seed;
    public static TOut Convert<TIn, TOut>(TIn value, Func<TIn, TOut> convert) => convert(value);
}

public static class GenericNameExtensions
{
    public static T As<T>(this object value) where T : class => (T)value;
    public static T As<T>(this object value, T fallback) where T : class => value as T ?? fallback;
}

public class GenericNameUsage
{
    private readonly List<int> _items = new List<int>();
    private readonly Dictionary<string, List<int>> _index = new Dictionary<string, List<int>>();

    public void Invoke()
    {
        var created = GenericNames.Create<GenericNameUsage>();
        var seeded = GenericNames.Create<int>(1);
        var converted = GenericNames.Convert<int, string>(seeded, value => value.ToString());
        object boxed = this;
        var unboxed = boxed.As<GenericNameUsage>();
        var fallback = boxed.As<GenericNameUsage>(this);
        var inferredFallback = boxed.As(this);
        var inferredSeed = GenericNames.Create(seeded);
        var projected = _items.Select(item => item);
        var indexed = _items.Select((item, position) => item + position);
        T Echo<T>(T value) => value;
        var echoed = Echo<int>(1);
        var inferredEcho = Echo(2);
        var ints = _items.OfType<int>().ToList();
        var unbound = typeof(List<>);
        IEnumerable<int> sequence = _items;
        _index[converted] = ints;
    }
}

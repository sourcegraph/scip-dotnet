namespace SlnxTest;

public class Greeter
{
    public string Greet(string name) => $"Hello, {name}!";
}

public static class Program
{
    public static void Main()
    {
        var greeter = new Greeter();
        Console.WriteLine(greeter.Greet("World"));
    }
}

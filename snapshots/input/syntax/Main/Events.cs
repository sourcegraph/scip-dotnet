using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Events
{
    public event EventHandler<int> Event1
    {
        add { }
        remove { }
    }

    public event EventHandler Event2
    {
        add => addSomething();
        remove => removeSomething();
    }

    private void removeSomething()
    {
        throw new NotImplementedException();
    }

    private void addSomething()
    {
        throw new NotImplementedException();
    }
}
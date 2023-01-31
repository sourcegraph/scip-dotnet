using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Interfaces
{
    public interface IOne
    {
    };

    public interface ITwo
    {
    };

    public interface IThree
    {
    };

    public interface IProperties
    {
        byte Get { get; }
        char Set { set; }
        uint GetSet { get; set; }
        long SetGet { set; get; }
    }

    interface IMethods
    {
        void Nothing();
        int Output();
        void Input(string a);
        int InputOutput(string a);
    };

    interface IEvent
    {
        event EventHandler<int> SomeEvent;
    }

    interface IIndex
    {
        bool this[int index] { get; set; }
    }

    interface IDefault
    {
        void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


    private interface IInherit : IOne, ITwo
    {
    }

    public interface IGetNext<T> where T : IGetNext<T>
    {
        static T operator ++(IGetNext<T> other)
        {
            throw new NotImplementedException();
        }
    }

    private interface ITypeParameter<T1, T2> : ITwo where T1 : IOne where T2 : IThree
    {
    }
}
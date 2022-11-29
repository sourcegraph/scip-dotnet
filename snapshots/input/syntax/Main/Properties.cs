using System.Diagnostics.CodeAnalysis;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Properties
{
    byte Get { get; }

    char Set
    {
        set { throw new NotImplementedException(); }
    }

    uint GetSet { get; set; }
    long SetGet { set; get; }

    string? Init { get; init; }
}
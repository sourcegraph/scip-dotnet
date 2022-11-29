using System.Diagnostics.CodeAnalysis;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace Main;

[SuppressMessage("ReSharper", "all")]
public class Packages
{
    DiffPaneModel Diff()
    {
        return InlineDiffBuilder.Diff("a", "b");
    }
}
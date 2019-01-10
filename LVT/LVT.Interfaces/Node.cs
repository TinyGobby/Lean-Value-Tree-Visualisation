using System;
using System.Collections.Generic;
using System.Text;

namespace LVT.LVT.Interfaces
{
    public interface Node
    {
        string ID { get; }
        string Header { get; }
        string Content1 { get; }

        List<Node> Subnodes { get; }
    }
}

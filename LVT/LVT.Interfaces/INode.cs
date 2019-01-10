using System.Collections.Generic;

namespace LVT.LVT.Interfaces
{
    public interface INode
    {
        string Id { get; }
        string Type { get; }
        string ContentLineOne { get; }
        List<INode> Subnodes { get; }
    }
}

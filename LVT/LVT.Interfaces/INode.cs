using System;
using System.Collections.Generic;

namespace LVT.LVT.Interfaces
{
    public interface INode<T> where T : class
    {
        string NodeID { get; }
        string Title { get; set; }
        List<T> NodeList { get; set; }
    }

    public interface IVision : INode<Goal> { }
    public interface IGoal : INode<Bet> { }
}
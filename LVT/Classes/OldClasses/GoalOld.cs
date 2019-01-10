using System;
using System.Collections.Generic;
using LVT.LVT.Interfaces;

namespace LVT
{
    public class Goal : INode
    {
        public Goal(string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Bets = new List<INode>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<INode> Bets { get; set; }

        public string ID => NodeID;

        public string GetContent1()
        {
            return Title;
        }

        public string Header => GetType().Name;
        public List<INode> Subnodes => Bets;

    }
}

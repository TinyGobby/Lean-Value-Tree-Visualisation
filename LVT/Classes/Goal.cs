using System;
using System.Collections.Generic;
using LVT.LVT.Interfaces;

namespace LVT
{
    public class Goal : Node
    {
        public Goal(string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Bets = new List<Node>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Node> Bets { get; set; }

        public string ID => NodeID;
        public string Content1 => Title;
        public string Header => GetType().Name;
        public List<Node> Subnodes => Bets;

    }
}

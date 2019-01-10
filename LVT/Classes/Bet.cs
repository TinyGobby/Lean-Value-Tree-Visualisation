using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;

namespace LVT
{
    public class Bet : Node
    {
        public Bet(string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Initiatives = new List<Initiative>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Initiative> Initiatives { get; set; }

        // Move to abstract base class.

        public string ID => NodeID;
        public string Content1 => Title;
        public string Header => GetType().Name;
        public List<Node> Subnodes => null;
    }
}

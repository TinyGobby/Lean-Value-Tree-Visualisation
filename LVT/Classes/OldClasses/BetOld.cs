using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;

namespace LVT
{
    public class BetOld : INode
    {
        public BetOld(string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Initiatives = new List<InitiativeOld>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<InitiativeOld> Initiatives { get; set; }

        // Move to abstract base class.

        public string ID => NodeID;

        public string GetContent1()
        {
            return Title;
        }

        public string Header => GetType().Name;
        public List<INode> Subnodes => null;
    }
}

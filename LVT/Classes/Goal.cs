using LVT.LVT.Interfaces;
using System.Collections.Generic;

namespace LVT.Classes
{
    public class Goal : Node
    {
        public Goal(string title) : base(title)
        {
            ContentLineOne = title;
            Subnodes = new List<Bet>();
        }

        public string Id { get; private set; }
        public string Type { get; private set; }
        public string ContentLineOne { get; private set; }

        public List<Bet> Subnodes { get; private set; }
    }
}

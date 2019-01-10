using LVT.LVT.Interfaces;
using System.Collections.Generic;

namespace LVT.Classes
{
    public class Bet : Goal
    {
        public Bet(string title) : base(title)
        {
            ContentLineOne = title;
            Subnodes = new List<Initiative>();
        }
        public string Id { get; private set; }
        public string Type { get; private set; }
        public string ContentLineOne { get; private set; }
      
        public IEnumerable<INode> Subnodes { get; private set; }
    }
}

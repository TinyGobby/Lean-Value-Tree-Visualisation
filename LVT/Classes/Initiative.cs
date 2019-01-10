using LVT.LVT.Interfaces;
using System.Collections.Generic;

namespace LVT.Classes
{
    class Initiative : Goal
    {
        public Initiative(string title) : base(title)
        {
            ContentLineOne = title;
            Subnodes = new List<Measure>();
            Subnodes2 = new List<Epic>();
        }

        public string Id { get; private set; }
        public string Type { get; private set; }
        public string ContentLineOne { get; private set; }

        public IEnumerable<INode> Subnodes { get; private set; }
        public IEnumerable<INode> Subnodes2 { get; private set; }
    }
}

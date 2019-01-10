using LVT.LVT.Interfaces;
using System.Collections.Generic;

namespace LVT.Classes
{
    class Measure : Epic
    {
        public Measure(string description, string deadline, string amount, string units) : base(description, deadline)
        {
            ContentLineOne = description;
            ContentLineTwo = deadline;
            ContentLineThree = amount;
            ContentLineFour = units;
        }

        public string Id { get; private set; }
        public string Type { get; private set; }
        public string ContentLineOne { get; private set; }
        public string ContentLineTwo { get; private set; }
        public string ContentLineThree { get; private set; }
        public string ContentLineFour { get; private set; }

        private readonly IEnumerable<INode> Subnodes;

        public IEnumerable<INode> GetSubnodes()
        {
            return null;
        }
    }
}

using LVT.LVT.Interfaces;
using System.Collections.Generic;

namespace LVT.Classes
{
    class Epic : Node
    {
        public Epic(string description, string deadline) : base(description)
        {
            ContentLineOne = description;
            ContentLineTwo = deadline;
        }

        public string Id { get; private set; }
        public string Type { get; private set; }
        public string ContentLineOne { get; private set; }
        public string ContentLineTwo { get; private set; }

        private readonly IEnumerable<INode> Subnodes;

        public IEnumerable<INode> GetSubnodes()
        {
            return null;
        }        
    }
}

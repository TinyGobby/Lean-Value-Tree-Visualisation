using LVT.LVT.Interfaces;
using System.Collections.Generic;

namespace LVT.Classes
{
    public class Node : INode
    {
        
        public Node(string content)
        {
            Type = GetType().Name;
            ContentLineOne = content;
            
            Subnodes = new List<INode>();
        }
         
        public string Id { get; private set; }
        public string Type { get; private set; }
        public string ContentLineOne { get; private set; }
                
        public List<INode> Subnodes { get; private set; }

    }
}

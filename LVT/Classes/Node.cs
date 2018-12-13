using System;
using System.Collections.Generic;
using System.Text;
using LVT.LVT.Interfaces;

namespace LVT.Classes
{
    public class Node
    {
        public Node(string title, List<Vision> nodeList)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            NodeList = nodeList;
        }
        public string NodeID { get; }
        public string Title { get; set; }
        public List<Vision> NodeList { get; set; }
    }
}

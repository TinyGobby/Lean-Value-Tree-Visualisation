using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class ListHandler
    {
        public List<Node> NodeList { get; set; }
        public List<List<Node>> EdgeList { get; set; }
        public Node PreviousNode { get; set; }
    }
}

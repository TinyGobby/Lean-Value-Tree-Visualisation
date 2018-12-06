using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LVT
{
    public class Node
    {
        public Node()
        {
            _name = "node";
            Title = "untitled";
            InternalNodeList = new List<Node>();
        }

        public string NodeId { get; set; }

        public string Title { get; set; }

        public List<Node> InternalNodeList { get; set; }

        public bool IsNotBottomOfTree()
        {
            return InternalNodeList.Count != 0;
        }

        public string GenerateNodeID(List<Node> nodeList)
        {
            int count = 0;
            Regex rx = new Regex(@"\b("+ _name +")");

            foreach(Node node in nodeList)
            {
                string id = node.NodeId;

                if (rx.IsMatch(id))
                {
                    count++;
                }
            }

            NodeId = $"{_name}{count}";

            return NodeId;
        }

        public List<List<Node>> UpdateEdgeList(List<List<Node>> edgeList, Node previousNode)
        {
            if (previousNode.NodeId == null) return edgeList;

            List<Node> edge = new List<Node> { previousNode, this };
            edgeList.Add(edge);

            return edgeList;
        }

        public ListHandler RecursiveTreeCrawler(ListHandler listHandler)
        {
            // Returns an object with a list of all nodes and all edges between nodes
            GenerateNodeID(listHandler.NodeList);
            listHandler.EdgeList = UpdateEdgeList(listHandler.EdgeList, listHandler.PreviousNode);
            listHandler.PreviousNode = this;
            listHandler.NodeList.Add(this);
            
                foreach (Node node in InternalNodeList)
                {
                    listHandler = node.RecursiveTreeCrawler(listHandler);
                    listHandler.PreviousNode = this;
                }

            return listHandler;
        }

        private readonly string _name;
    }
}
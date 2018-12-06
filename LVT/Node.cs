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
            if (InternalNodeList.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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

            List<Node> edge = new List<Node>();

            edge.Add(previousNode);
            edge.Add(this);
            edgeList.Add(edge);

            return edgeList;
        }

        public Node UpdatePreviousNode(Node previousNode)
        {
            return this;
        }

        public ListHandler RecursiveTreeCrawler(ListHandler listHandler)
        {
            GenerateNodeID(listHandler.NodeList);
            listHandler.EdgeList = UpdateEdgeList(listHandler.EdgeList, listHandler.PreviousNode);
            listHandler.PreviousNode = UpdatePreviousNode(listHandler.PreviousNode);
            listHandler.NodeList.Add(this);

            if (IsNotBottomOfTree())
            {
                foreach (Node node in InternalNodeList)
                {
                    listHandler = node.RecursiveTreeCrawler(listHandler);
                    listHandler.PreviousNode = UpdatePreviousNode(listHandler.PreviousNode);
                }
            }

            return listHandler;
        }

        private readonly string _name;
    }
}
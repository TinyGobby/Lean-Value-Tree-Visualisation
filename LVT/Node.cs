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
            Measures = new List<Node>();
            Epics = new List<Node>();
        }

        public string NodeId { get; set; }

        public string Title { get; set; }

        public List<Node> Measures { get; set; }

        public List<Node> Epics { get; set; }

        public bool IsBottomOfTree()
        {
            if (Epics.Count == 0 && Measures.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public List<Node> CheckNode(List<Node> nodeList)
        //{
        //    if (IsBottomOfTree())
        //    {
        //        string nodeID = GenerateNodeID(nodeList);
        //        nodeList.Add(nodeID);
        //    }

        //    return nodeList;
        //}

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
                    Console.WriteLine(count);
                }
            }

            NodeId = $"{_name}{count}";

            return NodeId;
        }

        public List<Node> CalculateEdge(Node currentNode, Node previousNode)
        {
            List<Node> edge = new List<Node>();
            edge.Add(previousNode);
            edge.Add(currentNode);

            return edge;
        }

        // Remove
        public List<List<Node>> AddToEdgeList(List<List<Node>> edgeList, List<Node> edge)
        {
            edgeList.Add(edge);

            return edgeList;
        }

        private readonly string _name;

        public Node ChangePreviousNode(Node previousNode)
        {
            return this;
        }

        public ListHandler RecursiveTreeCrawler(ListHandler listHandler)
        {
            GenerateNodeID(listHandler.NodeList);
            listHandler.EdgeList.Add(CalculateEdge(this, listHandler.PreviousNode));
            ChangePreviousNode(listHandler.PreviousNode);
            listHandler.NodeList.Add(this);

            return listHandler;

        }

    }
}
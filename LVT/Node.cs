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
            Measures = new List<Measure>();
            Epics = new List<Epic>();
        }

        public string Title { get; set; }

        public List<Measure> Measures { get; set; }

        public List<Epic> Epics { get; set; }

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
        public List<string> CheckNode(List<string> nodeList)
        {
            if (IsBottomOfTree())
            {
                string nodeID = GenerateNodeID(nodeList);
                nodeList.Add(nodeID);
            }

            return nodeList;
        }

        public string GenerateNodeID(List<string> nodeList)
        {
            int count = 0;
            Regex rx = new Regex(@"\b("+ _name +")");

            foreach(string node in nodeList)
            {
                if (rx.IsMatch(node))
                {
                    count++;
                    Console.WriteLine(count);
                }
            }

            return $"{_name}{count}";
        }

        public List<string> CalculateEdge(string currentNode, string previousNode)
        {
            List<string> edge = new List<string>();
            edge.Add(previousNode);
            edge.Add(currentNode);

            return edge;
        }

        public List<List<string>> AddToEdgeList(List<List<string>> edgeList, List<string> edge)
        {
            edgeList.Add(edge);

            return edgeList;
        }

        private readonly string _name;
    }
}
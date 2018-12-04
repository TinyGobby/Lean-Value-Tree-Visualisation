using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LVT
{
    public class Initiative
    {
        public Initiative()
        {
            _name = "initiative";
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

        private readonly string _name;

        public List<string> CalculateEdge(List<string> edgeList, string previousNode)
        {
            throw new NotImplementedException();
        }
    }
}
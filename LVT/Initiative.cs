using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Initiative
    {
        public Initiative()
        {
            _title = "untitled";
            _measures = new List<Measure>();
            _epics = new List<Epic>();
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public List<Measure> Measures
        {
            get { return _measures; }
            set { _measures = value; }
        }

        public List<Epic> Epics
        {
            get { return _epics; }
            set { _epics = value; }
        }

        public bool isBottomOfTree()
        {
            if (_epics.Count == 0 && _measures.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> checkNode(List<string> nodeList)
        {
            if (isBottomOfTree())
            {
                string nodeID = generateNodeID(nodeList);
                nodeList.Add(nodeID);
            }

            return nodeList;
        }

        public string generateNodeID(List<string> nodeList)
        {
            

            int position = nodeList.Count;

            return $"initiative{position}";

        }

        private string _title;
        private List<Measure> _measures;
        private List<Epic> _epics;
    }
}
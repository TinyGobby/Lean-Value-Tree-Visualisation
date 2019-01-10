using System;
using System.Collections.Generic;
using LVT.LVT.Interfaces;

namespace LVT
{
    public class Vision : Node
    {
        public Vision (string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Goals = new List<Goal>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Goal> Goals { get; set; }

        public string ID => NodeID;
        public string Content1 => Title;
        public string Header => GetType().Name;

    }
}

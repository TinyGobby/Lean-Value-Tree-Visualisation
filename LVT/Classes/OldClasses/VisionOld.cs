using System;
using System.Collections.Generic;
using LVT.LVT.Interfaces;

namespace LVT
{
    public class VisionOld : INode
    {
        public VisionOld (string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Goals = new List<Goal>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Goal> Goals { get; set; }

        public string ID
        {
            get
            {
                return NodeID;
            }
        }

        public string GetContent1()
        {
            return Title;
        }

        public string Header
        {
            get
            {
                return GetType().Name;
            }
        }
    }
}

using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;

namespace LVT
{
    public class Vision : IVision
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
    }
}

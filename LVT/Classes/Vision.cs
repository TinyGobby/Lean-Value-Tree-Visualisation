using System;
using System.Collections.Generic;
using System.Text;
using LVT.Classes;
using LVT.LVT.Interfaces;

namespace LVT
{
    public class Vision : IVision
    {
        public Vision (string title, List<Goal> goals)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            NodeList = goals;
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Goal> NodeList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Vision
    {
        public Vision (string title, List<Goal> goals)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Goals = goals;
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Goal> Goals { get; set; }

      
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Vision
    {
        public string Title { get; set; }
        public List<Goal> Goals { get; set; }

        public Vision(string title, List<Goal> goals) {
            Title = title;
            Goals = goals;
        }
    }
}

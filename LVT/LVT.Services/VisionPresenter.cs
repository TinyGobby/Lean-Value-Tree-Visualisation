using LVT.LVT.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVT.LVT.Services
{
    public class VisionPresenter : IVisionPresenter
    {
        public string VisualizeToString(Vision vision, string parentNode = "")
        {
            string result = "[[{ v: '" + vision.NodeID + "', f: 'Vision" + "<div style=\"font-style:italic\">" + vision.Title + "</div>'}, " + $"'{parentNode}']";

            if (vision.Goals != null && vision.Goals.Count() >= 1)
            {
                result = result + ", " + ProcessGoals(vision, vision.NodeID);
            };

            return result + "]";
        }

        private string ProcessGoals(Vision vision, string nodeID)
        {
            GoalPresenter GP = new GoalPresenter();
            IEnumerable<String> goalsStrings = vision.Goals.Select(goal => GP.VisualizeToString(goal, vision.NodeID));

            return string.Join(", ", goalsStrings);
        }
    }
}



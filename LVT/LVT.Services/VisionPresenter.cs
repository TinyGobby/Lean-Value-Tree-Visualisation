using LVT.LVT.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVT.LVT.Services
{
    public class VisionPresenter : IVisualizer<Vision>
    {
        protected List<string[]> LVTRowData = new List<string[]>();

        public string VisualizeToString(Vision vision, string parentNode = "")
        {
            GoalPresenter GP = new GoalPresenter();
            IEnumerable<String> goalsStrings = vision.Goals.Select(goal => GP.VisualizeToString(goal, vision.NodeID));
            string prettyGoals = string.Join(",", goalsStrings);

            return "[[{ v: '" + vision.NodeID + "', f: 'Vision" + "<div style=\"font-style:italic\">" + vision.Title + "</div>'}, " + $"'{parentNode}'], " + prettyGoals + "]";
        }

        // this is not used
        public List<string[]> VisualizeToList(Vision vision)
        {
            string[] visionPropsData = {$"{vision.Title}", ""};

            LVTRowData.Add(visionPropsData);

            ProcessGoals(vision, vision.Title);
            
            return LVTRowData;         
        }

        public void ProcessGoals(Vision vision, string visionTitle)
        {
            GoalPresenter GP = new GoalPresenter();
            IEnumerable<List<string[]>> goalsList = vision.Goals.Select(goal => GP.VisualizeToList(goal, visionTitle));

            foreach (List<string[]> goal in goalsList)
            {
                foreach (string[] text in goal)
                {
                    LVTRowData.Add(text);
                }
            }
        }
    }
}




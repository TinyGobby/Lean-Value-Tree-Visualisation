using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVT.LVT.Services
{
    public class VisionPresenter : IVisualizer<Vision>
    {
        public string VisualizeToString(Vision vision)
        {
            GoalPresenter GP = new GoalPresenter();
            IEnumerable<String> goalsStrings = vision.Goals.Select(goal => GP.VisualizeToString(goal));
            string prettyGoals = string.Join(",", goalsStrings);

            return $"~~ I am a vision with the following attributes: Title: {vision.Title}, GoalsList: {prettyGoals} ~~";
        }
    }
}

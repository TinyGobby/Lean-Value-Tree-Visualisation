using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVT.LVT.Services
{
    public class GoalPresenter : IGoalPresenter
    {
        public string VisualizeToString(IGoal goal, string parentNode)
        {
            string result = "[{ v: '" + goal.NodeID + "', f: 'Goal" + "<div style=\"font-style:italic\">" + goal.Title + "</div>'}, " + $"'{parentNode}']";

            if (goal.NodeList != null && goal.NodeList.Count() >= 1)
            {
                result = result + ", " + ProcessBets(goal, goal.NodeID);
            };

            return result;
        }

        private string ProcessBets(IGoal goal, string nodeID)
        {
            BetPresenter BP = new BetPresenter();
            IEnumerable<String> betsStrings = goal.NodeList.Select(bet => BP.VisualizeToString(bet, goal.NodeID));

            return string.Join(", ", betsStrings);
        }
    }
}

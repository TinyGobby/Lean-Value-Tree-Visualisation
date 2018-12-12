using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVT.LVT.Services
{
    public class GoalPresenter : IVisualizer<Goal>
    {
        protected List<string[]> goalRowData = new List<string[]>();

        public string VisualizeToString(Goal goal, string parentNode)
        {
            string result = "[{ v: '" + goal.NodeID + "', f: 'Goal" + "<div style=\"font-style:italic\">" + goal.Title + "</div>'}, " + $"'{parentNode}']";

            if (goal.Bets != null && goal.Bets.Count() >= 1)
            {
                result = result + ", " + ProcessBets(goal, goal.NodeID);
            };

            return result;
        }

        private string ProcessBets(Goal goal, string nodeID)
        {
            BetPresenter BP = new BetPresenter();
            IEnumerable<String> betsStrings = goal.Bets.Select(bet => BP.VisualizeToString(bet, goal.NodeID));

            return string.Join(", ", betsStrings);
        }
    }
}

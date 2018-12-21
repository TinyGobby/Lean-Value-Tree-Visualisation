using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class GoalPresenter : IGoalPresenter
    {
        private IBetPresenter _bp;

        public GoalPresenter(IBetPresenter bp = null)
        {
            _bp = bp ?? new BetPresenter();

        }

        public string VisualizeToString(Goal goal, string parentNode)
        {
            string result = "[{ v: '" + goal.NodeID + "', f: 'Goal" + "<div style=\"font-style:italic\">" + goal.Title + "</div>'}, " + $"'{parentNode}']";

            if (goal.Bets.Count() >= 1)
            {
                result = result + ", " + ProcessBets(goal, goal.NodeID);
            };

            return result;
        }

        private string ProcessBets(Goal goal, string nodeID)
        {
            IEnumerable<String> betsStrings = goal.Bets.Select(bet => _bp.VisualizeToString(bet, goal.NodeID));

            return string.Join(", ", betsStrings);
        }
    }
}

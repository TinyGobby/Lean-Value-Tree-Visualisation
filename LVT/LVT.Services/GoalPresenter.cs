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

        public string VisualizeToString(Goal goal, string parentNodeID)
        {
            string result = $"[{{ v:'{goal.NodeID}', f:'{goal.GetType().Name}<div style=\"font-style:italic\">{goal.Title}</div>'}}, '{parentNodeID}']";

            if (goal.Bets.Count() >= 1)
            {
                result = result + ", " + ProcessBets(goal);
            };

            return result;
        }

        private string ProcessBets(Goal goal)
        {
            IEnumerable<String> betsStrings = goal.Bets.Select(bet => _bp.VisualizeToString(bet, goal.NodeID));

            return string.Join(", ", betsStrings);
        }
    }
}

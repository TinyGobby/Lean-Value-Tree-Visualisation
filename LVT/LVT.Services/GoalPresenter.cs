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
            BetPresenter BP = new BetPresenter();
            IEnumerable<String> betsStrings = goal.Bets.Select(bet => BP.VisualizeToString(bet, goal.NodeID));
            string prettyBets = string.Join(",", betsStrings);

            return "[{ v: '" + goal.NodeID + "', f: 'Goal" + "<div style=\"font-style:italic\">" + goal.Title + "</div>'}, " + $"'{parentNode}'], " + prettyBets;

        }

        // this is not used
        public List<string[]> VisualizeToList(Goal goal, string visionTitle)
        {
            string[] goalPropsData = { $"{goal.Title}", $"{visionTitle}" };

            goalRowData.Add(goalPropsData);
            ProcessBets(goal, goal.Title);

            return goalRowData;
        }

        public void ProcessBets(Goal goal, string goalTitle)
        {
            BetPresenter BP = new BetPresenter();
            IEnumerable<List<string[]>> betsList = goal.Bets.Select(bet => BP.VisualizeToList(bet, goalTitle));

            foreach (List<string[]> bet in betsList)
            {
                foreach (string[] text in bet)
                {
                    goalRowData.Add(text);
                }            
            }
        }
    }
}

using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVT.LVT.Services
{
    public class GoalPresenter : IVisualizer<Goal>
    { 
        public string VisualizeToString(Goal goal)
        {
            BetPresenter BP = new BetPresenter();
            IEnumerable<String> betsStrings = goal.Bets.Select(bet => BP.VisualizeToString(bet));
            string prettyBets = string.Join(",", betsStrings);
            return $">> I am a goal with the following attributes: Title: {goal.Title}, BetsList: {prettyBets} <<";
        }
    }
}

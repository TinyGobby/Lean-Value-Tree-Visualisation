using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    class GoogleOrgChartPresenter : Presenter
    {
        public string VisualizeToStringVision(Vision vision)
        {
            var goalsStrings = new List<string>();

            var result = BuildOrgChartDataString(vision);

            if (vision.Goals.Count() >= 1)
            {
                foreach (var goal in vision.Goals)
                {
                    goalsStrings.Add(VisualizeToStringGoal(goal, vision.NodeID));
                }
            }

            return $"[{result}, {string.Join(", ", goalsStrings)}]";
        }

        internal string VisualizeToStringGoal(Goal goal, Vision parentNode)
        {
            var betsStrings = new List<string>();

            var result = BuildOrgChartDataString(goal, parentNode);

            if (goal.Bets.Count() >= 1)
            {
                foreach (var bet in goal.Bets)
                {
                    betsStrings.Add(VisualizeToStringBet(bet, nodeID));
                }
            }

            return $"{result}, {string.Join(", ", betsStrings)}";
        }

        internal string VisualizeToStringBet(Bet bet, string parentNode)
        {
            var nodeID = bet.NodeID;
            var nodeHeader = bet.GetType().Name;
            var nodeTitle = bet.Title;

            var initiativesStrings = new List<string>();

            var result = BuildOrgChartDataString(nodeID, nodeHeader, nodeTitle, parentNode);

            if (bet.Initiatives.Count() >= 1)
            {
                foreach (var initiative in bet.Initiatives)
                {
                    initiativesStrings.Add(VisualizeToStringInitiative(initiative, nodeID));
                }
            }

            return $"{result}, {string.Join(", ", initiativesStrings)}";
        }

        public string VisualizeToStringInitiative(Initiative initiative, string parentNode)
        {
            var nodeID = initiative.NodeID;
            var nodeHeader = initiative.GetType().Name;
            var nodeTitle = initiative.Title;

            var measuresStrings = new List<string>();
            var epicsStrings = new List<string>();

            string result = BuildOrgChartDataString(nodeID, nodeHeader, nodeTitle, parentNode);

            if (initiative.Measures.Count() >= 1)
            {
                foreach (var measure in initiative.Measures)
                {
                    measuresStrings.Add(VisualizeToStringMeasure(measure, nodeID));
                }
            }

            if (initiative.Epics.Count() >= 1)
            {
                foreach (var epic in initiative.Epics)
                {
                    epicsStrings.Add(VisualizeToStringEpic(epic, nodeID));
                }
            }

            return $"{result}, {string.Join(", ", measuresStrings)}, {string.Join(", ", epicsStrings)}";
        }

        public string VisualizeToStringMeasure(Measure measure, string parentNode)
        {
            var nodeID = measure.NodeID;
            var nodeHeader = measure.GetType().Name;
            var nodeDescription = measure.Description;
            var nodeDeadline = measure.Deadline;
            var nodeAmount = measure.Amount;
            var nodeUnits = measure.Units;

            return BuildOrgChartDataString(nodeID, nodeHeader, nodeDescription, nodeDeadline, nodeAmount, nodeUnits,
                parentNode);
        }

        public string VisualizeToStringEpic(Epic epic, string parentNode)
        {
            var nodeID = epic.NodeID;
            var nodeHeader = epic.GetType().Name;
            var nodeDescription = epic.Description;
            var nodeDeadline = epic.Deadline;

            return BuildOrgChartDataString(nodeID, nodeHeader, nodeDescription, nodeDeadline, parentNode);
        }
    }
}

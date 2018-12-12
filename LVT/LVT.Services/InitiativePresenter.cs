using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class InitiativePresenter : IVisualizer<Initiative>
    {
        public string VisualizeToString(Initiative initiative, string parentNode)
        {
            string result = "[{ v: '" + initiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + initiative.Title + "</div>'}, " + $"'{parentNode}']";

            if (initiative.Measures != null && initiative.Measures.Count() >= 1)
            {
                Console.WriteLine(result);
                result = result + " , " + ProcessMeasures(initiative, initiative.NodeID);
                Console.WriteLine(result);
            };

            if (initiative.Epics != null && initiative.Epics.Count() >= 1)
            {
                result = result + " , " + ProcessEpics(initiative, initiative.NodeID);
            };

            return result;
        }

        public string ProcessMeasures(Initiative initiative, string initiativeTitle)
        {
            MeasurePresenter MP = new MeasurePresenter();
            IEnumerable<String> measuresStrings = initiative.Measures.Select(measure => MP.VisualizeToString(measure, initiative.NodeID)); ;

            return string.Join(", ", measuresStrings);
        }

        private string ProcessEpics(Initiative initiative, string initiativeTitle)
        {
            EpicPresenter EP = new EpicPresenter();
            IEnumerable<String> epicsStrings = initiative.Epics.Select(epic => EP.VisualizeToString(epic, initiative.NodeID));

            return string.Join(", ", epicsStrings);
        }
    }
}
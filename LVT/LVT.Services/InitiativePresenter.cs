using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class InitiativePresenter : IInitiativePresenter
    {
        private IMeasurePresenter _mp;
        private IEpicPresenter _ep;

        public InitiativePresenter(IEpicPresenter ep = null, IMeasurePresenter mp = null)
        {
            _ep = ep == null ? new EpicPresenter() : ep;
            _mp = mp == null ? new MeasurePresenter() : mp;
        }

        public string VisualizeToString(Initiative initiative, string parentNode)
        {
            string result = "[{ v: '" + initiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + initiative.Title + "</div>'}, " + $"'{parentNode}']";

            if (initiative.Measures.Count() >= 1)
            {
                result = result + " , " + ProcessMeasures(initiative, initiative.NodeID);
            };

            if (initiative.Epics.Count() >= 1)
            {
                result = result + " , " + ProcessEpics(initiative, initiative.NodeID);
            };
            return result;
        }

        public string ProcessMeasures(Initiative initiative, string initiativeTitle)
        {
            IEnumerable<String> measuresStrings = initiative.Measures.Select(measure => _mp.VisualizeToString(measure, initiative.NodeID)); ;

            return string.Join(", ", measuresStrings);
        }

        private string ProcessEpics(Initiative initiative, string initiativeTitle)
        {
            IEnumerable<String> epicsStrings = initiative.Epics.Select(epic => _ep.VisualizeToString(epic, initiative.NodeID));

            return string.Join(", ", epicsStrings);
        }
    }
}
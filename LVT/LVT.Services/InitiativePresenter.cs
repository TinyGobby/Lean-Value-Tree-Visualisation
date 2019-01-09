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
            _ep = ep ?? new EpicPresenter();
            _mp = mp ?? new MeasurePresenter();
        }

        public string VisualizeToString(Initiative initiative, string parentNodeID)
        {
            string result = $"[{{ v:'{initiative.NodeID}', f:'{initiative.GetType().Name}<div style=\"font-style:italic\">{initiative.Title}</div>'}}, '{parentNodeID}']";

            if (initiative.Measures.Count() >= 1)
            {
                result = result + " , " + ProcessMeasures(initiative);
            };

            if (initiative.Epics.Count() >= 1)
            {
                result = result + " , " + ProcessEpics(initiative);
            };
            return result;
        }

        private string ProcessMeasures(Initiative initiative)
        {
            IEnumerable<String> measuresStrings = initiative.Measures.Select(measure => _mp.VisualizeToString(measure, initiative.NodeID)); ;

            return string.Join(", ", measuresStrings);
        }

        private string ProcessEpics(Initiative initiative)
        {
            IEnumerable<String> epicsStrings = initiative.Epics.Select(epic => _ep.VisualizeToString(epic, initiative.NodeID));

            return string.Join(", ", epicsStrings);
        }
    }
}
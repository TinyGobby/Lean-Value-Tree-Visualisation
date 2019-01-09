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

        public string VisualizeToString(Initiative initiative, string parentNode)
        {
            //string result = "[{ v: '" + initiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + initiative.Title + "</div>'}, " + $"'{parentNode}']";

            string result = ConstantsGoogleChartsString.OpenerOrgChartDataString +
                            ConstantsGoogleChartsString.OrgChartNodeIDWrapper +
                            initiative.NodeID +
                            ConstantsGoogleChartsString.OrgChartNodeHeaderWrapper +
                            initiative.GetType().Name +
                            ConstantsGoogleChartsString.OpenerOrgChartContentStylerFontItalic +
                            initiative.Title +
                            ConstantsGoogleChartsString.ClosingOrgChartContentStyler +
                            parentNode +
                            ConstantsGoogleChartsString.ClosingOrgChartDataString;

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
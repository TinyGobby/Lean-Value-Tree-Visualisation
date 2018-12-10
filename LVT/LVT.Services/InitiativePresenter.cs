using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class InitiativePresenter : IVisualizer<Initiative>
    {
        protected List<string[]> initiativeRowData = new List<string[]>();

        public string VisualizeToString(Initiative initiative, string parentNode)
        {
            MeasurePresenter MP = new MeasurePresenter();
            IEnumerable<String> measuresStrings = initiative.Measures.Select(measure => MP.VisualizeToString(measure, initiative.Title));
            string prettyMeasures = string.Join(",", measuresStrings);
            EpicPresenter EP = new EpicPresenter();
            IEnumerable<String> epicsStrings = initiative.Epics.Select(epic => EP.VisualizeToString(epic, initiative.Title));
            string prettyEpics = string.Join(",", epicsStrings);

            return "[{ v: '" + initiative.Title + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + initiative.Title + "</div>'}, " + $"'{parentNode}'], " + $"{prettyMeasures}, " + prettyEpics;
        }

        // this is not used
        public List<string[]> VisualizeToList(Initiative initiative, string betTitle)
        {
            string[] initiativePropsData = {$"{initiative.Title}", $"{betTitle}"};

            initiativeRowData.Add(initiativePropsData);
            ProcessMeasures(initiative, initiative.Title);
            ProcessEpics(initiative, initiative.Title);

            return initiativeRowData;
        }

        public void ProcessMeasures(Initiative initiative, string initiativeTitle)
        {
            MeasurePresenter MP = new MeasurePresenter();
            IEnumerable<List<string[]>> measuresList = initiative.Measures.Select(measure => MP.VisualizeToList(measure, initiativeTitle));

            foreach (List<string[]> measure in measuresList)
            {
                foreach (string[] text in measure)
                {
                    initiativeRowData.Add(text);
                }
            }
        }

        private void ProcessEpics(Initiative initiative, string initiativeTitle)
        {
            EpicPresenter EP = new EpicPresenter();
            IEnumerable<List<string[]>> epicsList = initiative.Epics.Select(epic => EP.VisualizeToList(epic, initiativeTitle));

            foreach (List<string[]> epic in epicsList)
            {
                foreach (string[] text in epic)
                {
                    initiativeRowData.Add(text);
                }
            }
        }
    }
}
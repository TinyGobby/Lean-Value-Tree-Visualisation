using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class InitiativePresenter : IVisualizer<Initiative>
    {
        public string VisualizeToString(Initiative initiative)
        {
            MeasurePresenter MP = new MeasurePresenter();
            IEnumerable<String> measuresStrings = initiative.Measures.Select(measure => MP.VisualizeToString(measure));
            string prettyMeasures = string.Join(",", measuresStrings);
            EpicPresenter EP = new EpicPresenter();
            IEnumerable<String> epicsStrings = initiative.Epics.Select(epic => EP.VisualizeToString(epic));
            string prettyEpics = string.Join(",", measuresStrings);

            return $"** I am an Initiative with the following attributes: Title: {initiative.Title}, MeasureList: {prettyMeasures}, EpicList {prettyEpics} **";
        }
    }
}
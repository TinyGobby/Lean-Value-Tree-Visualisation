using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;

namespace LVT.LVT.Services
{
    public class MeasurePresenter : IVisualizer<Measure>
    {
        protected List<string[]> measureRowData = new List<string[]>();

        public string VisualizeToString(Measure measure, string parentNode)
        {
            return "[{ v: '" + measure.NodeID + "', f: 'Measure<div style=\"font-style:italic\">" + $"{measure.Description}" + "</div>" +
                                                                                   "<div style=\"font-style:italic\">" + $"{measure.Deadline}" + "</div>" +
                                                                                   "<div style=\"font-style:italic\">" + $"{measure.Amount}" + "</div>" +
                                                                                   "<div style=\"font-style:italic\">" + $"{measure.Units}" + "</div>" +
                                                                                   "'}, " + $"'{parentNode}']";
        }

        // this is not used
        public List<string[]> VisualizeToList(Measure measure, string initiativeTitle)
        {
            string[] measurePropsData = {$"Amount: {measure.Amount}, Deadline: {measure.Deadline}, Description: {measure.Description}, Units: {measure.Units}", $"{initiativeTitle}"};

            measureRowData.Add(measurePropsData);

            return measureRowData;
        }
    }
}
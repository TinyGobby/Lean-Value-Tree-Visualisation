using LVT.LVT.Interfaces;

namespace LVT.LVT.Services
{
    public class MeasurePresenter : IMeasurePresenter
    {
        public string VisualizeToString(MeasureOld measure, string parentNode)
        {
            return "[{ v: '" + measure.NodeID + "', f: 'Measure<div style=\"font-style:italic\">" + $"{measure.Description}" + "</div>" +
                                                              "<div style=\"font-style:italic\">" + $"{measure.Deadline}" + "</div>" +
                                                              "<div style=\"font-style:italic\">" + $"{measure.Amount}" + "</div>" +
                                                              "<div style=\"font-style:italic\">" + $"{measure.Units}" + "</div>" +
                                                              "'}, " + $"'{parentNode}']";
        }
    }
}
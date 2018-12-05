using LVT.LVT.Interfaces;
using System;

namespace LVT.LVT.Services
{
    public class MeasurePresenter : IVisualizer<Measure>
    {
        public string VisualizeToString(Measure measure)
        {
            return $"## I am a measure with these attributes: Amount: {measure.Amount}, Deadline: {measure.Deadline}, Description: {measure.Description}, Units: {measure.Units} ##";
        }
    }
}
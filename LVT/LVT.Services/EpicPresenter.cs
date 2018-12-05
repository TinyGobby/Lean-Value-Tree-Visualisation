using LVT.LVT.Interfaces;
using System;

namespace LVT.LVT.Services
{
    public class EpicPresenter : IVisualizer<Epic>
    {
        public string VisualizeToString(Epic epic)
        {
            return $"## I am an Epic with these attributes: Deadline: {epic.Deadline}, Description: {epic.Description} ##";
        }
    }
}
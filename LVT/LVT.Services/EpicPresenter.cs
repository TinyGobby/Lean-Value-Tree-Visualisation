using LVT.LVT.Interfaces;

namespace LVT.LVT.Services
{
    public class EpicPresenter : IEpicPresenter
    {
        public string VisualizeToString(Epic epic, string parentNodeID)
        {
            return $"[{{ v:'{epic.NodeID}', f:'{epic.GetType().Name}<div style=\"font-style:italic\">{epic.Description}</div><div style=\"font-style:italic\">{epic.Deadline}</div>'}}, '{parentNodeID}']";
        }       
    }
}
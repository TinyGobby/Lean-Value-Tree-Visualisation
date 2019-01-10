using LVT.LVT.Interfaces;

namespace LVT.LVT.Services
{
    public class Presenter
    {
        // for vision
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeTitle)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeTitle}</div>'}}, '']";
        }
        // for goal, bet, initiative
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeTitle, string parentNodeID)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeTitle}</div>'}}, '{parentNodeID}']";
        }

        // for measure
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeDescription, string nodeDeadline, int nodeAmount, string nodeUnits, string parentNodeID)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeDescription}</div><div style=\"font-style:italic\">{nodeDeadline}</div><div style=\"font-style:italic\">{nodeAmount}</div><div style=\"font-style:italic\">{nodeUnits}</div>'}}, '{parentNodeID}']";
        }

        // for epic
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeDescription, string nodeDeadline, string parentNodeID)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeDescription}</div><div style=\"font-style:italic\">{nodeDeadline}</div>'}}, '{parentNodeID}']";
        }

        // for vision
        public string BuildOrgChartDataString(Vision vision)
        {
            return $"[{{ v:'{vision.NodeID}', f:'{vision.GetType().Name}<div style=\"font-style:italic\">{vision.Title}</div>'}}, '']";
        }
        // for goal, bet, initiative
        public string BuildOrgChartDataString(Node node, Node parentNode)
        {
            return $"[{{ v:'{node.ID}', f:'{node.Header}<div style=\"font-style:italic\">{node.Content1}</div>'}}, '{parentNode.ID}']";
        }

        // for measure
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeDescription, string nodeDeadline, int nodeAmount, string nodeUnits, string parentNodeID)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeDescription}</div><div style=\"font-style:italic\">{nodeDeadline}</div><div style=\"font-style:italic\">{nodeAmount}</div><div style=\"font-style:italic\">{nodeUnits}</div>'}}, '{parentNodeID}']";
        }

        // for epic
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeDescription, string nodeDeadline, string parentNodeID)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeDescription}</div><div style=\"font-style:italic\">{nodeDeadline}</div>'}}, '{parentNodeID}']";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeTitle, string parentNode)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeTitle}</div>'}}, '{parentNode}']";
        }

        // for measure
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeDescription, string nodeDeadline, int nodeAmount, string nodeUnits, string parentNode)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeDescription}</div><div style=\"font-style:italic\">{nodeDeadline}</div><div style=\"font-style:italic\">{nodeAmount}</div><div style=\"font-style:italic\">{nodeUnits}</div>'}}, '{parentNode}']";
        }

        // for epic
        public string BuildOrgChartDataString(string nodeID, string nodeHeader, string nodeDescription, string nodeDeadline, string parentNode)
        {
            return $"[{{ v:'{nodeID}', f:'{nodeHeader}<div style=\"font-style:italic\">{nodeDescription}</div><div style=\"font-style:italic\">{nodeDeadline}</div>'}}, '{parentNode}']";
        }
    }
}

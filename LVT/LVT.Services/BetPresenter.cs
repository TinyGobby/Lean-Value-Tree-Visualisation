using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class BetPresenter : IBetPresenter
    {
        private IInitiativePresenter _ip;

        public BetPresenter(IInitiativePresenter ip = null)
        {
            _ip = ip ?? new InitiativePresenter();
        }

        public string VisualizeToString(Bet bet, string parentNode)
        {
            string result = ConstantsGoogleChartsString.OpenerOrgChartDataString +
                            ConstantsGoogleChartsString.OrgChartNodeIDWrapper +
                            bet.NodeID +
                            ConstantsGoogleChartsString.OrgChartNodeHeaderWrapper +
                            bet.GetType().Name +
                            ConstantsGoogleChartsString.OpenerOrgChartContentStylerFontItalic +
                            bet.Title +
                            ConstantsGoogleChartsString.ClosingOrgChartContentStyler + 
                            parentNode + 
                            ConstantsGoogleChartsString.ClosingOrgChartDataString;

            if (bet.Initiatives.Count >= 1)
            {
                result = result + ", " + ProcessInitiatives(bet);
            };

            return result;
        }

        private string ProcessInitiatives(Bet bet)
        {
            IEnumerable<String> initiativesStrings = bet.Initiatives.Select(initiative => _ip.VisualizeToString(initiative, bet.NodeID));

            return string.Join(", ", initiativesStrings);
        }
    }
}
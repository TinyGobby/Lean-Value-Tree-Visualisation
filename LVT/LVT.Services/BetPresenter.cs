using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class BetPresenter : IVisualizer<Bet>
    {
        private IVisualizer<Initiative> _ip;

        public BetPresenter(IVisualizer<Initiative> ip)
        {
            _ip = ip;
        }

        public string VisualizeToString(Bet bet, string parentNode)
        {
            string result = "[{ v: '" + bet.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + bet.Title + "</div>'}, " + $"'{parentNode}']";

            if (bet.Initiatives != null && bet.Initiatives.Count >= 1)
            {
                result = result + ", " + ProcessInitiatives(bet, bet.NodeID);
            };

            return result;
        }

        private string ProcessInitiatives(Bet bet, string nodeID)
        {
            _ip = new InitiativePresenter();
            IEnumerable<String> initiativesStrings = bet.Initiatives.Select(initiative => _ip.VisualizeToString(initiative, bet.NodeID));

            return string.Join(", ", initiativesStrings);
        }
    }
}
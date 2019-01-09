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

        public string VisualizeToString(Bet bet, string parentNodeID)
        {
            string result = $"[{{ v:'{bet.NodeID}', f:'{bet.GetType().Name}<div style=\"font-style:italic\">{bet.Title}</div>'}}, '{parentNodeID}']";

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
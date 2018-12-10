using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class BetPresenter : IVisualizer<Bet>
    {
        protected List<string[]> betRowData = new List<string[]>();

        public string VisualizeToString(Bet bet, string parentNode)
        {
            InitiativePresenter IP = new InitiativePresenter();
            IEnumerable<String> initiativesStrings = bet.Initiatives.Select(initiative => IP.VisualizeToString(initiative, bet.NodeID));
            string prettyInitiatives = string.Join(",", initiativesStrings);

            return "[{ v: '" + bet.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + bet.Title + "</div>'}, " + $"'{parentNode}'], " + prettyInitiatives;

        }

        // this is not used
        public List<string[]> VisualizeToList(Bet bet, string goalTitle)
        {
            string[] betPropsData = {$"{bet.Title}", $"{goalTitle}"};

            betRowData.Add(betPropsData);
            ProcessInitiatives(bet, bet.Title);

            return betRowData;
        }

        public void ProcessInitiatives(Bet bet, string betTitle)
        {
            InitiativePresenter IP = new InitiativePresenter();
            IEnumerable<List<string[]>> initiativesList = bet.Initiatives.Select(initiative => IP.VisualizeToList(initiative, betTitle));

            foreach (List<string[]> initiative in initiativesList)
            {
                foreach (string[] text in initiative)
                {
                    betRowData.Add(text);
                }
            }
        }
    }
}
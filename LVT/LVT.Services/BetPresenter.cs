using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVT.LVT.Services
{
    public class BetPresenter : IVisualizer<Bet>
    {
        public string VisualizeToString(Bet bet)
        {
            InitiativePresenter IP = new InitiativePresenter();
            IEnumerable<String> initiativesStrings = bet.Initiatives.Select(initiative => IP.VisualizeToString(initiative));
            string prettyInitiatives = string.Join(",", initiativesStrings);
            return $"<< I am a Bet with the following attributes: Title {bet.Title}, InititativeList: {prettyInitiatives} >>";
        }
    }
}
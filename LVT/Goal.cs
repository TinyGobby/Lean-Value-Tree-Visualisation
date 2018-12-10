using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Goal
    {
        public Goal(string title, List<Bet> bets)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Bets = bets;
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Bet> Bets { get; set; }

    }
}

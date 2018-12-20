using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Goal
    {
        public Goal(string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Bets = new List<Bet>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Bet> Bets { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using LVT.LVT.Interfaces;

namespace LVT
{
    public class Goal : IGoal
    {
        public Goal(string title, List<Bet> bets)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            NodeList = bets;
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Bet> NodeList { get; set; }

    }
}

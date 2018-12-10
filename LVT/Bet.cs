using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Bet
    {
        public Bet(string title, List<Initiative> initiatives)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Initiatives = initiatives;
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Initiative> Initiatives { get; set; }

    }
}

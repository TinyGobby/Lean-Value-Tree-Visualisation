using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Measure
    {
        public string NodeID { get; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public int Amount { get; set; }
        public string Units { get; set; }

        public Measure(string description, string deadline, int amount, string units)
        {
            NodeID = Guid.NewGuid().ToString();
            Description = description;
            Deadline = deadline;
            Amount = amount;
            Units = units;
        }


    }
}

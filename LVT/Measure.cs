using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Measure
    {
        public string Description { get; set; }
        public string Deadline { get; set; }
        public int Amount { get; set; }
        public string Units { get; set; }

        public Measure(string description, string deadline, int amount, string units)
        {
            Description = description;
            Deadline = deadline;
            Amount = amount;
            Units = units;
        }


    }
}

using System;

namespace LVT
{
    public class MeasureOld
    {
        public string NodeID { get; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public int Amount { get; set; }
        public string Units { get; set; }

        public MeasureOld(string description, string deadline, int amount, string units)
        {
            NodeID = Guid.NewGuid().ToString();
            Description = description;
            Deadline = deadline;
            Amount = amount;
            Units = units;
        }
    }
}

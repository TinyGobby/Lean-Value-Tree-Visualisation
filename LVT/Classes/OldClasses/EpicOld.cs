using System;

namespace LVT
{
    public class EpicOld
    {
        public EpicOld(string description, string deadline)
        {
            NodeID = Guid.NewGuid().ToString();
            Description = description;
            Deadline = deadline;
        }

        public string NodeID { get; }
        public string Description { get; set; }
        public string Deadline { get; set; }
    }
}

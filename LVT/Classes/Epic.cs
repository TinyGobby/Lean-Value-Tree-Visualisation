using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Epic
    {
        public Epic(string description, string deadline)
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

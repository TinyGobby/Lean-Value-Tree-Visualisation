using System;
using System.Collections.Generic;

namespace LVT
{
    public class InitiativeOld
    {
        public InitiativeOld(string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Measures = new List<MeasureOld>();
            Epics = new List<EpicOld>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<MeasureOld> Measures { get; set; }
        public List<EpicOld> Epics { get; set; }
    }
}

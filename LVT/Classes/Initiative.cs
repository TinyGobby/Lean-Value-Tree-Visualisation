using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Initiative
    {
        public Initiative(string title, List<Measure> measures, List<Epic> epics)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            Measures = measures;
            Epics = epics;
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Measure> Measures { get; set; }
        public List<Epic> Epics { get; set; }

    }
}

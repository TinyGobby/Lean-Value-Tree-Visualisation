using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Initiative
    {
        public Initiative(string title)
        {
            NodeID = Guid.NewGuid().ToString();
            Title = title;
            List<Measure> Measures = new List<Measure>();
            List<Epic> Epics = new List<Epic>();
        }

        public string NodeID { get; }
        public string Title { get; set; }
        public List<Measure> Measures { get; set; }
        public List<Epic> Epics { get; set; }

    }
}

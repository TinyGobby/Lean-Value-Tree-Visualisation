using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Initiative
    {
        public string title { get; set; }
        public List<Measure> measures { get; set; }
        public List<Epic> epics { get; set; }

        public string getTitle()
        {
            return "untitled";
        }
 
    }
}
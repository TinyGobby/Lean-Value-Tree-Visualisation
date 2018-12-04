using System;
using System.Collections.Generic;
using System.Text;

namespace LVT
{
    public class Initiative
    {
        public Initiative()
        {
            _title = "untitled";
            _measures = new List<Measure>();
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public List<Measure> Measures
        {
            get { return _measures; }
            set { _measures = value; }
        }

        public List<Epic> epics { get; set; }

        private string _title;
        private List<Measure> _measures;
    }
}
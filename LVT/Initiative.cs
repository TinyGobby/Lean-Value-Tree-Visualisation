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
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public List<Measure> measures { get; set; }
        public List<Epic> epics { get; set; }

        private string _title;
    }
}
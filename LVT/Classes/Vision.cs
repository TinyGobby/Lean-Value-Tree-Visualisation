using LVT.LVT.Interfaces;
using System;
using System.Collections.Generic;

namespace LVT.Classes
{
    public class Vision : Node
    {
        public Vision(string title) : base(title)
        {
            //ContentLineOne = title;
            //Subnodes = new List<Goal>();
            Subnodes = new List<Goal>();
        }

        //public string Id { get; private set; }
        //public string Type { get; private set; }
        //public string ContentLineOne { get; private set; }
        //public new List<Goal> Subnodes { get; private set; }
        public new List<Goal> Subnodes { get; private set; }
}
}

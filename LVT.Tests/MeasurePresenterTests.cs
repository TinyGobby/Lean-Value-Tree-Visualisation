using LVT.LVT.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LVT.Tests
{
    class MeasurePresenterTests
    {
        [Test]
        public void MeasurePresenterTest()
        {
            var MP = new MeasurePresenter();
            var measure = new Measure("testDescription", "testDeadline", 5, "testUnits");
            string ParentNode = "parentNode";
            string result = MP.VisualizeToString(measure, ParentNode);
            string NodeID = measure.NodeID;
            string Description = measure.Description;
            string Deadline = measure.Deadline;
            int Amount = measure.Amount;
            string Units = measure.Units;
 
            string expected = "[{ v: '" + measure.NodeID + "', f: 'Measure<div style=\"font-style:italic\">" + $"{Description}" + "</div>" +
                                                                         "<div style=\"font-style:italic\">" + $"{Deadline}" + "</div>" +
                                                                         "<div style=\"font-style:italic\">" + $"{Amount}" + "</div>" +
                                                                         "<div style=\"font-style:italic\">" + $"{Units}" + "</div>" +
                                                                         "'}, " + $"'{ParentNode}']";

            Assert.AreEqual(expected, result);
        }
    }
}

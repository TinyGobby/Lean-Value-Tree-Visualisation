using LVT.LVT.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LVT.Tests
{
    class EpicPresenterTests
    {
        [Test]
        public void EpicPresenterTest()
        {
            var EP = new EpicPresenter();
            var epic = new Epic("testDescription", "testDeadline");
            string NodeID = epic.NodeID;
            string Description = epic.Description;
            string Deadline = epic.Deadline;
            string ParentNode = "parentNode";
            string expected = "[{ v: '" + NodeID + "', f: 'Epic" + "<div style=\"font-style:italic\">" + $"{Description}" + "</div>" +
                                                                   "<div style=\"font-style:italic\">" + $"{Deadline}" + "</div>" +
                                                                   "'}, " + $"'{ParentNode}']";

            string result = EP.VisualizeToString(epic, "parentNode");

            Assert.AreEqual(expected, result);

        }
    }
}

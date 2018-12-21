using LVT.LVT.Services;
using NUnit.Framework;

namespace LVT.Tests
{
    class MeasurePresenterTests
    {
        private MeasurePresenter _MP;
        private Measure _testMeasure;

        [SetUp]
        public void SetupForTest()
        {
            _MP = new MeasurePresenter();
            _testMeasure = new Measure("testDescription", "testDeadline", 5, "testUnits");
        }

        [Test]
        public void MeasurePresenterTest()
        {
            string ParentNode = "Parent Initiative NodeID";

            string result = _MP.VisualizeToString(_testMeasure, ParentNode);
            string expected = "[{ v: '" + _testMeasure.NodeID + "', f: 'Measure<div style=\"font-style:italic\">" + $"{_testMeasure.Description}" + "</div>" +
                                                                         "<div style=\"font-style:italic\">" + $"{_testMeasure.Deadline}" + "</div>" +
                                                                         "<div style=\"font-style:italic\">" + $"{_testMeasure.Amount}" + "</div>" +
                                                                         "<div style=\"font-style:italic\">" + $"{_testMeasure.Units}" + "</div>" +
                                                                         "'}, " + $"'{ParentNode}']";

            Assert.AreEqual(expected, result);
        }
    }
}

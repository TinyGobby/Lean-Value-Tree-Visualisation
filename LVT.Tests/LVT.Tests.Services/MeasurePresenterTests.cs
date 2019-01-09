using LVT.LVT.Services;
using NUnit.Framework;

namespace LVT.Tests
{
    class MeasurePresenterTests
    {
        private MeasurePresenter _measurePresenter;
        private Measure _testMeasure;
        private string _parentNodeID;
        private string _expectedMeasureOrgChartString;

        [SetUp]
        public void SetupForTest()
        {
            _parentNodeID = "Parent Initiative NodeID";
            _measurePresenter = new MeasurePresenter();
            _testMeasure = new Measure("testDescription", "testDeadline", 5, "testUnits");
            _expectedMeasureOrgChartString = $"[{{ v:'{_testMeasure.NodeID}', f:'{_testMeasure.GetType().Name}<div style=\"font-style:italic\">{_testMeasure.Description}</div><div style=\"font-style:italic\">{_testMeasure.Deadline}</div><div style=\"font-style:italic\">{_testMeasure.Amount}</div><div style=\"font-style:italic\">{_testMeasure.Units}</div>'}}, '{_parentNodeID}']";
        }

        [Test]
        public void MeasurePresenterReturnsCorrectOrgChartString()
        {
            //act
            var result = _measurePresenter.VisualizeToString(_testMeasure, _parentNodeID);

            //assert
            var expected = $"{_expectedMeasureOrgChartString}";

            Assert.AreEqual(expected, result);
        }
    }
}

using LVT.LVT.Services;
using NUnit.Framework;

namespace LVT.Tests
{
    class EpicPresenterTests
    {
        private EpicPresenter _epicPresenter;
        private Epic _testEpic;

        [SetUp]
        public void SetupForTest()
        {
            _epicPresenter = new EpicPresenter();
            _testEpic = new Epic("testDescription", "testDeadline");
        }

        [Test]
        public void EpicPresenterReturnsCorrectOrgChartString()
        {
            string parentNodeID = "Parent Initiative NodeID";

            string result = _epicPresenter.VisualizeToString(_testEpic, parentNodeID);
            string expected = $"[{{ v:'{_testEpic.NodeID}', f:'{_testEpic.GetType().Name}<div style=\"font-style:italic\">{_testEpic.Description}</div><div style=\"font-style:italic\">{_testEpic.Deadline}</div>'}}, '{parentNodeID}']";

            Assert.AreEqual(expected, result);
        }
    }
}

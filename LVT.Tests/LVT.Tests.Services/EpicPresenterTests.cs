using LVT.LVT.Services;
using NUnit.Framework;

namespace LVT.Tests
{
    class EpicPresenterTests
    {
        private EpicPresenter _epicPresenter;
        private Epic _testEpic;
        private string _parentNodeID;
        private string _expectedEpicOrgChartString;

        [SetUp]
        public void SetupForTest()
        {
            _epicPresenter = new EpicPresenter();
            _testEpic = new Epic("testDescription", "testDeadline");
            _parentNodeID = "Parent Initiative NodeID";
            _expectedEpicOrgChartString =
                $"[{{ v:'{_testEpic.NodeID}', f:'{_testEpic.GetType().Name}<div style=\"font-style:italic\">{_testEpic.Description}</div><div style=\"font-style:italic\">{_testEpic.Deadline}</div>'}}, '{_parentNodeID}']";
        }

        [Test]
        public void EpicPresenterReturnsCorrectOrgChartString()
        {
            //act
            string result = _epicPresenter.VisualizeToString(_testEpic, _parentNodeID);

            //assert
            string expected = $"{_expectedEpicOrgChartString}";

            Assert.AreEqual(expected, result);
        }
    }
}

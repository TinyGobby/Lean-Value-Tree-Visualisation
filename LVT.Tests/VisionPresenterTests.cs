using LVT.LVT.Interfaces;
using LVT.LVT.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace LVT.Tests
{
    class VisionPresenterTests
    {
        private Vision _testVision;
        private Goal _testGoal;
        private VisionPresenter _visionPresenter;
        private string _parentNodeID;
        private Mock<IGoalPresenter> _mockGoalPresenter;

        [SetUp]
        public void SetupForTest()
        {
            _testVision = new Vision("Test Vision Title");
            _parentNodeID = "Parent LVT Node Test ID";
            _testGoal = new Goal("Test Goal Title");

            _mockGoalPresenter = new Mock<IGoalPresenter>();
            _mockGoalPresenter.SetupSequence(mgp => mgp.VisualizeToString(_testGoal, _testVision.NodeID)).Returns("This GoalPresenter method has been mocked")
                                                                                           .Returns("This mocked GoalPresenter method has been called twice");
            _visionPresenter = new VisionPresenter(_mockGoalPresenter.Object);
        }

        [Test]
        public void VisualizeToString_Vision_ReturnsCorrectOrgChartString_WithNoGoals()
        {
            string result = _visionPresenter.VisualizeToString(_testVision, _parentNodeID);
            string expected = $"[[{{ v:'{_testVision.NodeID}', f:'{_testVision.GetType().Name}<div style=\"font-style:italic\">{_testVision.Title}</div>'}}, '']]";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Vision_ReturnsCorrectOrgChartString_WithOneGoal()
        {
            _testVision.Goals.Add(_testGoal);

            string result = _visionPresenter.VisualizeToString(_testVision, _parentNodeID);
            string expected = $"[[{{ v:'{_testVision.NodeID}', f:'{_testVision.GetType().Name}<div style=\"font-style:italic\">{_testVision.Title}</div>'}}, ''], "
                                                                                     + "This GoalPresenter method has been mocked" 
                                                                                     + "]";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Vision_ReturnsCorrectOrgChartString_WithTwoGoals()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testVision.Goals.Add(_testGoal));

            string result = _visionPresenter.VisualizeToString(_testVision, _parentNodeID);
            string expected = $"[[{{ v:'{_testVision.NodeID}', f:'{_testVision.GetType().Name}<div style=\"font-style:italic\">{_testVision.Title}</div>'}}, ''], "
                                                                                     + "This GoalPresenter method has been mocked" + ", "
                                                                                     + "This mocked GoalPresenter method has been called twice"
                                                                                     + "]";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Vision_CallsVisualizeToStringGoal_FiveTimes_WithFiveGoals()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testVision.Goals.Add(_testGoal));

            string result = _visionPresenter.VisualizeToString(_testVision, _parentNodeID);

            _mockGoalPresenter.Verify(mgp => mgp.VisualizeToString(It.IsAny<Goal>(), _testVision.NodeID), Times.Exactly(5));
        }
    }
}

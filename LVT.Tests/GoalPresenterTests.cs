using LVT.LVT.Interfaces;
using LVT.LVT.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace LVT.Tests
{
    class GoalPresenterTests
    {
        private Goal _testGoal;
        private GoalPresenter _goalPresenter;
        private Bet _testBet;
        private string _parentNodeID;
        private Mock<IBetPresenter> _mockBetPresenter;

        [SetUp]
        public void SetupForTest()
        {
            _testGoal = new Goal("Test Goal Title");
            _parentNodeID = "Parent Vision Node Test ID";
            _testBet = new Bet("Test Bet Title");

            _mockBetPresenter = new Mock<IBetPresenter>();
            _mockBetPresenter.SetupSequence(mbp => mbp.VisualizeToString(_testBet, _testGoal.NodeID)).Returns("This BetPresenter method has been mocked")
                                                                                        .Returns("This mocked BetPresenter method has been called twice");
            _goalPresenter = new GoalPresenter(_mockBetPresenter.Object);
        }

        [Test]
        public void VisualizeToString_Goal_ReturnsCorrectOrgChartString_WithNoBets()
        {
            string result = _goalPresenter.VisualizeToString(_testGoal, _parentNodeID);
            string expected = $"[{{ v:'{_testGoal.NodeID}', f:'{_testGoal.GetType().Name}<div style=\"font-style:italic\">{_testGoal.Title}</div>'}}, '{_parentNodeID}']";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Goal_ReturnsCorrectOrgChartString_WithOneBet()
        {
            _testGoal.Bets.Add(_testBet);

            string result = _goalPresenter.VisualizeToString(_testGoal, _parentNodeID);
            string expected = $"[{{ v:'{_testGoal.NodeID}', f:'{_testGoal.GetType().Name}<div style=\"font-style:italic\">{_testGoal.Title}</div>'}}, '{_parentNodeID}'], "
                              + "This BetPresenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Goal_ReturnsCorrectOrgChartString_WithTwoBets()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testGoal.Bets.Add(_testBet));

            string result = _goalPresenter.VisualizeToString(_testGoal, _parentNodeID);
            string expected = $"[{{ v:'{_testGoal.NodeID}', f:'{_testGoal.GetType().Name}<div style=\"font-style:italic\">{_testGoal.Title}</div>'}}, '{_parentNodeID}'], "
                              + "This BetPresenter method has been mocked, "
                              + "This mocked BetPresenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Goal_CallsVisualizeToStringBet_FiveTimes_WithFiveBets()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testGoal.Bets.Add(_testBet));

            string result = _goalPresenter.VisualizeToString(_testGoal, _parentNodeID);
           
            _mockBetPresenter.Verify(mbp => mbp.VisualizeToString(It.IsAny<Bet>(), _testGoal.NodeID), Times.Exactly(5));
        }
    }
}

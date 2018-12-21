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
        private Bet _testBet;
        private GoalPresenter _GP;
        private string _ParentNodeID;
        private Mock<IBetPresenter> _MBP;

        [SetUp]
        public void SetupForTest()
        {
            _testGoal = new Goal("Test Goal Title");
            _ParentNodeID = "Parent Vision Node Test ID";
            _testBet = new Bet("Test Bet Title");

            _MBP = new Mock<IBetPresenter>();
            _MBP.SetupSequence(mbp => mbp.VisualizeToString(_testBet, _testGoal.NodeID)).Returns("This BetPresenter method has been mocked")
                                                                                        .Returns("This mocked BetPresenter method has been called twice");
            _GP = new GoalPresenter(_MBP.Object);
        }

        [Test]
        public void VisualiseToString_Goal_NoBets()
        {
            string result = _GP.VisualizeToString(_testGoal, _ParentNodeID);
            string expected = "[{ v: '" + _testGoal.NodeID + "', f: 'Goal" + "<div style=\"font-style:italic\">" + _testGoal.Title + "</div>'}, " + $"'{_ParentNodeID}']";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Goal_WithOneBet()
        {
            _testGoal.Bets.Add(_testBet);

            string result = _GP.VisualizeToString(_testGoal, _ParentNodeID);
            string expected = "[{ v: '" + _testGoal.NodeID + "', f: 'Goal" + "<div style=\"font-style:italic\">" + _testGoal.Title + "</div>'}, " + $"'{_ParentNodeID}'], "
                                                                           + "This BetPresenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Goal_WithTwoBets()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testGoal.Bets.Add(_testBet));

            string result = _GP.VisualizeToString(_testGoal, _ParentNodeID);
            string expected = "[{ v: '" + _testGoal.NodeID + "', f: 'Goal" + "<div style=\"font-style:italic\">" + _testGoal.Title + "</div>'}, " + $"'{_ParentNodeID}'], "
                                                                           + "This BetPresenter method has been mocked" + ", "
                                                                           + "This mocked BetPresenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Goal_WithFiveBets()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testGoal.Bets.Add(_testBet));

            string result = _GP.VisualizeToString(_testGoal, _ParentNodeID);
           
            _MBP.Verify(mbp => mbp.VisualizeToString(It.IsAny<Bet>(), _testGoal.NodeID), Times.Exactly(5));
        }
    }
}

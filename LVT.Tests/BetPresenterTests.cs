using LVT.LVT.Services;
using NUnit.Framework;
using Moq;
using LVT.LVT.Interfaces;
using System.Linq;

namespace LVT.Tests
{
    class BetPresenterTests
    {
        private Bet _testBet;
        private BetPresenter _betPresenter;
        private Initiative _testInitiative;
        private string _parentNodeID;
        private Mock<IInitiativePresenter> _mockInitiativePresenter;
        private string _expectedBetOrgChartString;

        [SetUp]
        public void SetupForTest()
        {
            _testBet = new Bet("Test Bet Title");
            _parentNodeID = "Parent Goal Node Test ID";
            _testInitiative = new Initiative("Test Initiative Title");

            _mockInitiativePresenter = new Mock<IInitiativePresenter>();
            _mockInitiativePresenter.SetupSequence(mip => mip.VisualizeToString(_testInitiative, _testBet.NodeID)).Returns("This initiative presenter method has been mocked")
                                                                                              .Returns("This mocked initiative presenter method has been called twice");
            _betPresenter = new BetPresenter(_mockInitiativePresenter.Object);
            _expectedBetOrgChartString = $"[{{ v:'{_testBet.NodeID}', f:'{_testBet.GetType().Name}<div style=\"font-style:italic\">{_testBet.Title}</div>'}}, '{_parentNodeID}']";
        }

        [Test]
        public void VisualizeToString_Bet_ReturnsCorrectOrgChartString_NoInitiatives()
        {
            //act
            var result = _betPresenter.VisualizeToString(_testBet, _parentNodeID);

            //assert
            var expected = $"{_expectedBetOrgChartString}";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_ReturnsCorrectOrgChartString_WithOneInitiative()
        {
            //arrange
            _testBet.Initiatives.Add(_testInitiative);

            //act
            string result = _betPresenter.VisualizeToString(_testBet, _parentNodeID);

            //assert
            var expected = $"{_expectedBetOrgChartString}, "
                           + "This initiative presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_ReturnsCorrectOrgChartString_WithTwoInitiatives()
        {
            //arrange
            Enumerable.Range(0, 2).ToList().ForEach(count => _testBet.Initiatives.Add(_testInitiative));

            //act
            string result = _betPresenter.VisualizeToString(_testBet, _parentNodeID);

            //assert
            var expected = $"{_expectedBetOrgChartString}, "
                           + "This initiative presenter method has been mocked, "
                           + "This mocked initiative presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_CallsVisualizeToStringInitiative_FiveTimes_WithFiveInitiatives()
        {
            //arrange
            Enumerable.Range(0, 5).ToList().ForEach(count => _testBet.Initiatives.Add(_testInitiative));

            //act
            _betPresenter.VisualizeToString(_testBet, _parentNodeID);

            //assert
            _mockInitiativePresenter.Verify(mip => mip.VisualizeToString(It.IsAny<Initiative>(), _testBet.NodeID), Times.Exactly(5));
        }
    }
}
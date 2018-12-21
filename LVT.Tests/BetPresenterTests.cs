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
        private BetPresenter _BP;
        private Initiative _testInitiative;
        private string _ParentNodeID;
        private Mock<IInitiativePresenter> _MIP;

        [SetUp]
        public void SetupForTest()
        {
            _testBet = new Bet("Test Bet Title");
            _ParentNodeID = "Parent Goal Node Test ID";
            _testInitiative = new Initiative("Test Initiative Title");

            _MIP = new Mock<IInitiativePresenter>();
            _MIP.SetupSequence(mip => mip.VisualizeToString(_testInitiative, _testBet.NodeID)).Returns("This initiative presenter method has been mocked")
                                                                                              .Returns("This mocked initiative presenter method has been called twice");
            _BP = new BetPresenter(_MIP.Object);
        }
        [Test]
        public void VisualizeToString_Bet_NoInitiatives()
        {           
            string result = _BP.VisualizeToString(_testBet, _ParentNodeID);
            string expected = "[{ v: '" + _testBet.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + _testBet.Title + "</div>'}, " + $"'{_ParentNodeID}']";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_WithOneInitiative()
        {
            _testBet.Initiatives.Add(_testInitiative);

            string result = _BP.VisualizeToString(_testBet, _ParentNodeID);
            string expected = "[{ v: '" + _testBet.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + _testBet.Title + "</div>'}, " + $"'{_ParentNodeID}'], "
                                                                         + "This initiative presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_WithTwoInitiatives()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testBet.Initiatives.Add(_testInitiative));

            string result = _BP.VisualizeToString(_testBet, _ParentNodeID);
            string expected = "[{ v: '" + _testBet.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + _testBet.Title + "</div>'}, " + $"'{_ParentNodeID}'], "
                                                                         + "This initiative presenter method has been mocked" + ", "
                                                                         + "This mocked initiative presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_WithFiveInitiatives()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testBet.Initiatives.Add(_testInitiative));
            
            _BP.VisualizeToString(_testBet, _ParentNodeID);
            
            _MIP.Verify(mip => mip.VisualizeToString(It.IsAny<Initiative>(), _testBet.NodeID), Times.Exactly(5));
        }
    }
}
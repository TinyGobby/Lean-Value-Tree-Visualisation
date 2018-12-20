using LVT.LVT.Services;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Text;
using LVT.LVT.Interfaces;

namespace LVT.Tests
{
    class BetPresenterTests
    {
        private Bet _testBet;
        private BetPresenter _TBP;
        private Initiative _testInitiative;
        private Mock<IInitiativePresenter> _MIP;
        private string _ParentNodeID;

        [SetUp]
        public void SetupForTest()
        {
            _testBet = new Bet("Test Bet Title");
            _ParentNodeID = "Parent Goal Node Test ID";
            _testInitiative = new Initiative("Test Initiative Title");
            System.Console.WriteLine(_testInitiative);
            _MIP = new Mock<IInitiativePresenter>();
        }
        [Test]
        public void VisualiseToString_Bet_NoInitiatives()
        {
            _TBP = new BetPresenter();

            string result = _TBP.VisualizeToString(_testBet, _ParentNodeID);
            string expected = "[{ v: '" + _testBet.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + _testBet.Title + "</div>'}, " + $"'{_ParentNodeID}']";

            Assert.AreEqual(expected, result);
        }

        //[Test]
        //public void VisualiseToString_Bet_WithOneInitiative()
        //{
        //    _testBet.Initiatives.Add(_testInitiative);
        //    _MIP.Setup(mip => mip.VisualizeToString(_testInitiative, "parent bet node")).Returns("This initiative presenter method has been mocked");
        //    _TBP = new BetPresenter(_MIP.Object);

        //    string result = _TBP.VisualizeToString(_testBet, _ParentNodeID);
        //    string expected = "[{ v: '" + _testBet.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + _testBet.Title + "</div>'}, " + $"'{_ParentNodeID}']" + "Test Initiative One of One Title";

        //    Assert.AreEqual(expected, result);
        //}
    }
}
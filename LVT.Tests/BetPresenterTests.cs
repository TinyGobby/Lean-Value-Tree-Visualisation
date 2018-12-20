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
        public Bet _testBet;
        public BetPresenter _TBP;
        public Initiative _testInitiative;
        public Mock<IInitiativePresenter> _MIP;

        [SetUp]
        public void SetupForTest()
        {
            _TBP = new BetPresenter();
            _testBet = new Bet("Test Bet Title");
            _testInitiative = new Initiative("Test Initiative Title");
            _MIP = new Mock<IInitiativePresenter>();
        }
        //[Test]
        //TestBetVisualizeToStringOneInitiative()
        //{
        //    string title = "betTitle";
        //    var mockInitiative = new Mock<Initiative>();
        //    mockInitiative.Setup(foo => foo.ProcessInitiatives).Returns(;
        //    BetPresenter BP = new BetPresenter(mockInitiative);
        //    Bet testBet = new Bet(title);
        //    string parentNode = "hiIAmAParentNode";
        //    string actual = BP.VisualizeToString(testBet, parentNode);
        //    string BetID = testBet.NodeID;

        //    string expected = "[{ v: '" + BetID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + title + "</div>'}, " + $"'{parentNode}']";

        //    Assert.AreEqual(expected, actual);
        //    Assert.verify (or similar, to verify call is made to method)

        //mock_ip.Setup(foo => foo.ProcessInitiatives).Returns("SomeSTring");

        //}

        [Test]
        public void VisualiseToString_Bet_WithOneInitiative()
        {
            _testBet.Initiatives.Add(_testInitiative);
            _MIP.Setup(mip => mip.VisualizeToString(_testInitiative, "Parent Node Test ID")).Returns("Test Initiative One of One Title");
            
            string result = _TBP.VisualizeToString(_testBet, _testBet.NodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + _testBet.Title + "</div>'}, " + $"'{_testBet.NodeID}']" + "Test Initiative One of One Title";

            Assert.AreEqual(expected, result);
      }
    }
}
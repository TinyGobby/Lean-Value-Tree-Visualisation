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

        //[Test]
        //public void ProcessInitiative_test()
        //{
        //    var mockIP = new Mock<IVisualizer<Initiative>>();
        //    Initiative testInit = new Initiative("Inititaive Title");   
        //    Bet testBet = new Bet("Test Bet");
        //    BetPresenter testBP = new BetPresenter(mockIP);
        //    string betNodeID = "Test Node ID";
            
        //    mockIP.Setup(foo => foo.VisualizeToString(testInit, betNodeID)).Returns("StringOfInitiatives");

        //    ProcessInitiatives(testBet, betNodeID);
        //}
    }
}
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
        [Test]
        TestBetVisualizeToStringOneInitiative()
        {
            string title = "betTitle";
            var mockInitiative = new Mock<Initiative>();
            mockInitiative.Setup(foo => foo.ProcessInitiatives).Returns(;
            BetPresenter BP = new BetPresenter(mockInitiative);
            Bet testBet = new Bet(title);
            string parentNode = "hiIAmAParentNode";
            string actual = BP.VisualizeToString(testBet, parentNode);
            string BetID = testBet.NodeID;

            string expected = "[{ v: '" + BetID + "', f: 'Bet" + "<div style=\"font-style:italic\">" + title + "</div>'}, " + $"'{parentNode}']";

            Assert.AreEqual(expected, actual);
        }        
    }
}
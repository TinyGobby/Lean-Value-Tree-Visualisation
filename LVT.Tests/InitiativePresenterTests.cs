using LVT.LVT.Interfaces;
using LVT.LVT.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace LVT.Tests
{
    class InitiativePresenterTests
    {
        private Initiative _testInitiative;
        private Measure _testMeasure;
        private Epic _testEpic;
        private InitiativePresenter _IP;
        private string _ParentNodeID;
        private Mock<IEpicPresenter> _MEP;
        private Mock<IMeasurePresenter> _MMP;

        [SetUp]
        public void SetupForTest()
        {
            _testInitiative = new Initiative("Test Initiative Title");
            _ParentNodeID = "Parent Bet Node Test ID";
            _testEpic = new Epic("Test Epic Descritpition", "Test Epic Deadline");
            _testMeasure = new Measure("Test Measure Description", "Test Measure Deadline", 1, "Test Measure Units");

            _MEP = new Mock<IEpicPresenter>();
            _MEP.SetupSequence(mep => mep.VisualizeToString(_testEpic, _testInitiative.NodeID)).Returns("This Epic Presenter method has been mocked")
                                                                                              .Returns("This mocked Epic Presenter method has been called twice");
            _MMP = new Mock<IMeasurePresenter>();
            _MMP.SetupSequence(mmp => mmp.VisualizeToString(_testMeasure, _testInitiative.NodeID)).Returns("This Measure Presenter method has been mocked")
                                                                                                  .Returns("This mocked Measure Presenter method has been called twice");

            _IP = new InitiativePresenter(_MEP.Object, _MMP.Object);
        }

        [Test]
        public void VisualiseToString_Bet_NoMeasures_NoEpics()
        {
            string result = _IP.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Bet_OneMeasure_NoEpics()
        {
            _testInitiative.Measures.Add(_testMeasure);

            string result = _IP.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Bet_OneEpic_NoEMeasure()
        {
            _testInitiative.Epics.Add(_testEpic);

            string result = _IP.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Epic Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Bet_OneMeasure_OneEpic()
        {
            _testInitiative.Measures.Add(_testMeasure);
            _testInitiative.Epics.Add(_testEpic);

            string result = _IP.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked" + " , "
                                                                                       + "This Epic Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Bet_TwoMeasures_NoEpics()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));

            string result = _IP.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked" + ", "
                                                                                       + "This mocked Measure Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Bet_TwoEpics_NoEMeasure()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            string result = _IP.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Epic Presenter method has been mocked" + ", "
                                                                                       + "This mocked Epic Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Bet_TwoMeasures_TwoEpics()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            string result = _IP.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked" + ", "
                                                                                       + "This mocked Measure Presenter method has been called twice" + " , "
                                                                                       + "This Epic Presenter method has been mocked" + ", "
                                                                                       + "This mocked Epic Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualiseToString_Bet_FiveMeasures_NoEpics()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));

            _IP.VisualizeToString(_testInitiative, _ParentNodeID);

            _MMP.Verify(mmp => mmp.VisualizeToString(It.IsAny<Measure>(), _testInitiative.NodeID), Times.Exactly(5));
        }

        [Test]
        public void VisualiseToString_Bet_FiveEpics_NoMeasures()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            _IP.VisualizeToString(_testInitiative, _ParentNodeID);

            _MEP.Verify(mep => mep.VisualizeToString(It.IsAny<Epic>(), _testInitiative.NodeID), Times.Exactly(5));
        }

        [Test]
        public void VisualiseToString_Bet_FiveMeasures_FiveEpics()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            _IP.VisualizeToString(_testInitiative, _ParentNodeID);

            _MMP.Verify(mmp => mmp.VisualizeToString(It.IsAny<Measure>(), _testInitiative.NodeID), Times.Exactly(5));
            _MEP.Verify(mep => mep.VisualizeToString(It.IsAny<Epic>(), _testInitiative.NodeID), Times.Exactly(5));
        }
    }
}
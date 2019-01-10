using LVT.LVT.Interfaces;
using LVT.LVT.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace LVT.Tests
{
    class InitiativePresenterTests
    {
        private InitiativeOld _testInitiative;
        private MeasureOld _testMeasure;
        private EpicOld _testEpic;
        private InitiativePresenter _initiativePresenter;
        private string _ParentNodeID;
        private Mock<IEpicPresenter> _mockEpicPresenter;
        private Mock<IMeasurePresenter> _mockMeasurePresenter;

        [SetUp]
        public void SetupForTest()
        {
            _testInitiative = new InitiativeOld("Test Initiative Title");
            _ParentNodeID = "Parent Bet Node Test ID";
            _testEpic = new EpicOld("Test Epic Descritpition", "Test Epic Deadline");
            _testMeasure = new MeasureOld("Test Measure Description", "Test Measure Deadline", 1, "Test Measure Units");

            _mockEpicPresenter = new Mock<IEpicPresenter>();
            _mockEpicPresenter.SetupSequence(mep => mep.VisualizeToString(_testEpic, _testInitiative.NodeID)).Returns("This Epic Presenter method has been mocked")
                                                                                              .Returns("This mocked Epic Presenter method has been called twice");
            _mockMeasurePresenter = new Mock<IMeasurePresenter>();
            _mockMeasurePresenter.SetupSequence(mmp => mmp.VisualizeToString(_testMeasure, _testInitiative.NodeID)).Returns("This Measure Presenter method has been mocked")
                                                                                                  .Returns("This mocked Measure Presenter method has been called twice");

            _initiativePresenter = new InitiativePresenter(_mockEpicPresenter.Object, _mockMeasurePresenter.Object);
        }

        [Test]
        public void VisualizeToString_Bet_NoMeasures_NoEpics()
        {
            string result = _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_OneMeasure_NoEpics()
        {
            _testInitiative.Measures.Add(_testMeasure);

            string result = _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_OneEpic_NoEMeasure()
        {
            _testInitiative.Epics.Add(_testEpic);

            string result = _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Epic Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_OneMeasure_OneEpic()
        {
            _testInitiative.Measures.Add(_testMeasure);
            _testInitiative.Epics.Add(_testEpic);

            string result = _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked" + " , "
                                                                                       + "This Epic Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_TwoMeasures_NoEpics()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));

            string result = _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked" + ", "
                                                                                       + "This mocked Measure Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_TwoEpics_NoEMeasure()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            string result = _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Epic Presenter method has been mocked" + ", "
                                                                                       + "This mocked Epic Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Bet_TwoMeasures_TwoEpics()
        {
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            string result = _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);
            string expected = "[{ v: '" + _testInitiative.NodeID + "', f: 'Initiative" + "<div style=\"font-style:italic\">" + _testInitiative.Title + "</div>'}, " + $"'{_ParentNodeID}']" + " , "
                                                                                       + "This Measure Presenter method has been mocked" + ", "
                                                                                       + "This mocked Measure Presenter method has been called twice" + " , "
                                                                                       + "This Epic Presenter method has been mocked" + ", "
                                                                                       + "This mocked Epic Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        // Would this be an option to use Parametrized tests [TestCase]?
        [Test]
        public void VisualizeToString_Bet_FiveMeasures_NoEpics()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));

            _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);

            _mockMeasurePresenter.Verify(mmp => mmp.VisualizeToString(It.IsAny<MeasureOld>(), _testInitiative.NodeID), Times.Exactly(5));
        }

        [Test]
        public void VisualizeToString_Bet_FiveEpics_NoMeasures()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);

            _mockEpicPresenter.Verify(mep => mep.VisualizeToString(It.IsAny<EpicOld>(), _testInitiative.NodeID), Times.Exactly(5));
        }

        [Test]
        public void VisualizeToString_Bet_FiveMeasures_FiveEpics()
        {
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            _initiativePresenter.VisualizeToString(_testInitiative, _ParentNodeID);

            _mockMeasurePresenter.Verify(mmp => mmp.VisualizeToString(It.IsAny<MeasureOld>(), _testInitiative.NodeID), Times.Exactly(5));
            _mockEpicPresenter.Verify(mep => mep.VisualizeToString(It.IsAny<EpicOld>(), _testInitiative.NodeID), Times.Exactly(5));
        }
    }
}
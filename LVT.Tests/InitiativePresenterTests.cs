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
        private InitiativePresenter _initiativePresenter;
        private string _parentNodeID;
        private Mock<IEpicPresenter> _mockEpicPresenter;
        private Mock<IMeasurePresenter> _mockMeasurePresenter;
        private string _expectedInitiativeOrgChartString;

        [SetUp]
        public void SetupForTest()
        {
            _testInitiative = new Initiative("Test Initiative Title");
            _parentNodeID = "Parent Bet Node Test ID";
            _testEpic = new Epic("Test Epic Descritpition", "Test Epic Deadline");
            _testMeasure = new Measure("Test Measure Description", "Test Measure Deadline", 1, "Test Measure Units");

            _mockEpicPresenter = new Mock<IEpicPresenter>();
            _mockEpicPresenter.SetupSequence(mep => mep.VisualizeToString(_testEpic, _testInitiative.NodeID)).Returns("This Epic Presenter method has been mocked")
                                                                                              .Returns("This mocked Epic Presenter method has been called twice");
            _mockMeasurePresenter = new Mock<IMeasurePresenter>();
            _mockMeasurePresenter.SetupSequence(mmp => mmp.VisualizeToString(_testMeasure, _testInitiative.NodeID)).Returns("This Measure Presenter method has been mocked")
                                                                                                  .Returns("This mocked Measure Presenter method has been called twice");

            _initiativePresenter = new InitiativePresenter(_mockEpicPresenter.Object, _mockMeasurePresenter.Object);
            _expectedInitiativeOrgChartString = $"[{{ v:'{_testInitiative.NodeID}', f:'{_testInitiative.GetType().Name}<div style=\"font-style:italic\">{_testInitiative.Title}</div>'}}, '{_parentNodeID}']";
        }

        [Test]
        public void VisualizeToString_Initiative_ReturnsCorrectOrgChartString_WithNoMeasures_NoEpics()
        {
            //act
            var result = _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            var expected = $"{_expectedInitiativeOrgChartString}";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Initiative_ReturnsCorrectOrgChartString_WithOneMeasure_NoEpics()
        {
            //arrange
            _testInitiative.Measures.Add(_testMeasure);

            //act
            var result = _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            var expected = $"{_expectedInitiativeOrgChartString} , "
                           + "This Measure Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Initiative_ReturnsCorrectOrgChartString_WithOneEpic_NoMeasure()
        {
            //arrange
            _testInitiative.Epics.Add(_testEpic);

            //act
            var result = _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            var expected = $"{_expectedInitiativeOrgChartString} , "
                           + "This Epic Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Initiative_ReturnsCorrectOrgChartString_WithOneMeasure_OneEpic()
        {
            //arrange
            _testInitiative.Measures.Add(_testMeasure);
            _testInitiative.Epics.Add(_testEpic);

            //act
            var result = _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            var expected = $"{_expectedInitiativeOrgChartString} , "
                           + "This Measure Presenter method has been mocked , "
                           + "This Epic Presenter method has been mocked";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Initiative_ReturnsCorrectOrgChartString_WithTwoMeasures_NoEpics()
        {
            //arrange
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));

            //act
            var result = _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            var expected = $"{_expectedInitiativeOrgChartString} , "
                           + "This Measure Presenter method has been mocked, "
                           + "This mocked Measure Presenter method has been called twice";


            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Initiative_ReturnsCorrectOrgChartString_WithTwoEpics_NoMeasure()
        {
            //arrange
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            //act
            var result = _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            var expected = $"{_expectedInitiativeOrgChartString} , "
                           + "This Epic Presenter method has been mocked, "
                           + "This mocked Epic Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void VisualizeToString_Initiative_ReturnsCorrectOrgChartString_WithTwoMeasures_TwoEpics()
        {
            //arrange
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));
            Enumerable.Range(0, 2).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            //act
            var result = _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            var expected = $"{_expectedInitiativeOrgChartString} , "
                           + "This Measure Presenter method has been mocked, "
                           + "This mocked Measure Presenter method has been called twice , "
                           + "This Epic Presenter method has been mocked, "
                           + "This mocked Epic Presenter method has been called twice";

            Assert.AreEqual(expected, result);
        }

        // Would this be an option to use Parametrized tests [TestCase]?
        [Test]
        public void VisualizeToString_Initiative_CallsVisualizeToStringMeasure_FiveTimes_WithFiveMeasures_NoEpics()
        {
            //act
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));

            //arrange
            _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            _mockMeasurePresenter.Verify(mmp => mmp.VisualizeToString(It.IsAny<Measure>(), _testInitiative.NodeID), Times.Exactly(5));
            _mockEpicPresenter.Verify(mep => mep.VisualizeToString(It.IsAny<Epic>(), _testInitiative.NodeID), Times.Exactly(0));
        }

        [Test]
        public void VisualizeToString_Initiative_CallsVisualizeToStringEpic_FiveTimes_WithFiveEpics_NoMeasures()
        {
            //arrange
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            //act
            _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            _mockEpicPresenter.Verify(mep => mep.VisualizeToString(It.IsAny<Epic>(), _testInitiative.NodeID), Times.Exactly(5));
            _mockMeasurePresenter.Verify(mmp => mmp.VisualizeToString(It.IsAny<Measure>(), _testInitiative.NodeID), Times.Exactly(0));
        }

        [Test]
        public void VisualizeToString_Initiative_CallsVisualizeToStringMeasureAndEpic_FiveTimes_WithFiveMeasures_FiveEpics()
        {
            //arrange
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Measures.Add(_testMeasure));
            Enumerable.Range(0, 5).ToList().ForEach(count => _testInitiative.Epics.Add(_testEpic));

            //act
            _initiativePresenter.VisualizeToString(_testInitiative, _parentNodeID);

            //assert
            _mockMeasurePresenter.Verify(mmp => mmp.VisualizeToString(It.IsAny<Measure>(), _testInitiative.NodeID), Times.Exactly(5));
            _mockEpicPresenter.Verify(mep => mep.VisualizeToString(It.IsAny<Epic>(), _testInitiative.NodeID), Times.Exactly(5));
        }
    }
}
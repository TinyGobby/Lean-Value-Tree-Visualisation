using NUnit.Framework;
using LVT;
using System.Collections.Generic;

namespace Tests
{
    public class InitiativeTest
    {
        private Initiative testedObject;

        [SetUp]
        public void Setup()
        {
            testedObject = new Initiative();
        }

        [Test]
        public void getTitle()
        {
            string expectedInitialTitle = "untitled";
            string result = testedObject.Title;

            Assert.AreEqual(expectedInitialTitle, result);
        }

        [Test]
        public void setTitle()
        {
            string newTitle = "Test";
            testedObject.Title = newTitle;
            string result = testedObject.Title;

            Assert.AreEqual(newTitle, result);
        }

        [Test]
        public void getMeasures()
        {
            List<Measure> result = testedObject.Measures;

            Assert.IsEmpty(result);
        }

        [Test]
        public void setMeasures()
        {
            Measure testMeasure = new Measure();
            testedObject.Measures.Add(testMeasure);
            Measure result = testedObject.Measures[0];

            Assert.AreEqual(testMeasure, result);
        }

        [Test]
        public void setMultipleMeasures()
        {
            Measure testMeasure = new Measure();
            Measure testMeasure2 = new Measure();
            testedObject.Measures.Add(testMeasure);
            testedObject.Measures.Add(testMeasure2);
            List<Measure> result = testedObject.Measures;

            Assert.Contains(testMeasure, result);
            Assert.Contains(testMeasure2, result);
        }

        [Test]
        public void getEpics()
        {
            List<Epic> result = testedObject.Epics;

            Assert.IsEmpty(result);
        }

        [Test]
        public void setEpics()
        {
            Epic testEpic = new Epic();
            testedObject.Epics.Add(testEpic);
            Epic result = testedObject.Epics[0];

            Assert.AreEqual(testEpic, result);
        }

        [Test]
        public void setMultipleEpics()
        {
            Epic testEpic = new Epic();
            Epic testEpic2 = new Epic();
            testedObject.Epics.Add(testEpic);
            testedObject.Epics.Add(testEpic2);
            List<Epic> result = testedObject.Epics;

            Assert.Contains(testEpic, result);
            Assert.Contains(testEpic2, result);
        }
    }
}
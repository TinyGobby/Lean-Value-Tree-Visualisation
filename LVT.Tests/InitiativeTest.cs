using NUnit.Framework;
using LVT;
using System.Collections.Generic;

namespace Tests
{
    public class InitiativeTest
    {
        private Initiative testedObject;
        private List<string> nodeList;

        [SetUp]
        public void Setup()
        {
            testedObject = new Initiative();
            nodeList = new List<string>();
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

        [Test]
        public void isBottomOfTree()
        {
            Assert.True(testedObject.isBottomOfTree());
        }

        [Test]
        public void isNotBottomOfEpicTree()
        {
            Epic testEpic = new Epic();
            testedObject.Epics.Add(testEpic);
            Assert.False(testedObject.isBottomOfTree());
        }

        [Test]
        public void generateNodeID()
        {
            string expected = "initiative0";
            string result = testedObject.generateNodeID(nodeList);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void generateNodeIDWhenThereAreAlreadyInitiativeNodes()
        {
            string initialNode = "initiative0";
            string secondNode = "initiative1"; // skipping test for two nodes as this will be covered in this test
            nodeList.Add(initialNode);
            nodeList.Add(secondNode);

            string expected = "initiative2";
            string result = testedObject.generateNodeID(nodeList);


            Assert.AreEqual(expected, result);
        }

        [Test]
        public void generateNodeIDWhenThereAreAlreadyOtherNodes()
        {
            string initialInitiativeNode = "initiative0";
            string initialOtherNode = "measure0"; 
            nodeList.Add(initialOtherNode);
            nodeList.Add(initialInitiativeNode);

            string expected = "initiative1";
            string result = testedObject.generateNodeID(nodeList);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void returnsNodeIfBottomOfTree()
        {
            List<string> result = testedObject.checkNode(nodeList);

            Assert.IsNotEmpty(result);
        }

        [Test]
        public void addNodeIdToArray()
        {
            string initialNode = "initiative0";
            nodeList.Add(initialNode);

            string expected = "initiative1";
            List<string> result = testedObject.checkNode(nodeList);

            Assert.Contains(expected, result);
        }
    }
}
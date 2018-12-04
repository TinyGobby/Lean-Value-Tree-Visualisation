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
        public void TestGetTitle()
        {
            string expectedInitialTitle = "untitled";
            string result = testedObject.Title;

            Assert.AreEqual(expectedInitialTitle, result);
        }

        [Test]
        public void TestSetTitle()
        {
            string newTitle = "Test";
            testedObject.Title = newTitle;
            string result = testedObject.Title;

            Assert.AreEqual(newTitle, result);
        }

        [Test]
        public void TestGetMeasures()
        {
            List<Measure> result = testedObject.Measures;

            Assert.IsEmpty(result);
        }

        [Test]
        public void TestSetMeasures()
        {
            Measure testMeasure = new Measure();
            testedObject.Measures.Add(testMeasure);
            Measure result = testedObject.Measures[0];

            Assert.AreEqual(testMeasure, result);
        }

        [Test]
        public void TestSetMultipleMeasures()
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
        public void TestGetEpics()
        {
            List<Epic> result = testedObject.Epics;

            Assert.IsEmpty(result);
        }

        [Test]
        public void TestSetEpics()
        {
            Epic testEpic = new Epic();
            testedObject.Epics.Add(testEpic);
            Epic result = testedObject.Epics[0];

            Assert.AreEqual(testEpic, result);
        }

        [Test]
        public void TestSetMultipleEpics()
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
        public void TestIsBottomOfTree()
        {
            Assert.True(testedObject.IsBottomOfTree());
        }

        [Test]
        public void TestIsNotBottomOfEpicTree()
        {
            Epic testEpic = new Epic();
            testedObject.Epics.Add(testEpic);
            Assert.False(testedObject.IsBottomOfTree());
        }

        [Test]
        public void TestGenerateNodeID()
        {
            string expected = "initiative0";
            string result = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGenerateNodeIDWhenThereAreAlreadyInitiativeNodes()
        {
            string initialNode = "initiative0";
            string secondNode = "initiative1"; // skipping test for two nodes as this will be covered in this test
            nodeList.Add(initialNode);
            nodeList.Add(secondNode);

            string expected = "initiative2";
            string result = testedObject.GenerateNodeID(nodeList);


            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGenerateNodeIDWhenThereAreAlreadyOtherNodes()
        {
            string initialInitiativeNode = "initiative0";
            string initialOtherNode = "measure0"; 
            nodeList.Add(initialOtherNode);
            nodeList.Add(initialInitiativeNode);

            string expected = "initiative1";
            string result = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReturnsNodeIfBottomOfTree()
        {
            List<string> result = testedObject.CheckNode(nodeList);

            Assert.IsNotEmpty(result);
        }

        [Test]
        public void TestAddNodeIdToArray()
        {
            string initialNode = "initiative0";
            nodeList.Add(initialNode);

            string expected = "initiative1";
            List<string> result = testedObject.CheckNode(nodeList);

            Assert.Contains(expected, result);
        }
    }
}
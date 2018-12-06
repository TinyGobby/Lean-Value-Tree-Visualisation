using NUnit.Framework;
using LVT;
using System.Collections.Generic;

namespace Tests
{
    public class NodeTest
    {
        private Node testedObject;
        private List<Node> nodeList;
        private List<List<Node>> edgeList;
        private Node previousNode;
        private Node currentNode;
        private Node initialNode;
        private Node secondNode;
        private ListHandler listHandler;

        [SetUp]
        public void Setup()
        {
            testedObject = new Node();
            nodeList = new List<Node>();
            edgeList = new List<List<Node>>();
            previousNode = new Node();
            currentNode = new Node();
            initialNode = new Node();
            secondNode = new Node();
            listHandler = new ListHandler();
        }

        [Test]
        public void TestGetTitle()
        {
            string expectedInitialTitle = "untitled";
            string actual = testedObject.Title;

            Assert.AreEqual(expectedInitialTitle, actual);
        }

        [Test]
        public void TestSetTitle()
        {
            string newTitle = "Test";
            testedObject.Title = newTitle;
            string actual = testedObject.Title;

            Assert.AreEqual(newTitle, actual);
        }

        //[Test]
        //public void TestGetMeasures()
        //{
        //    List<Measure> actual = testedObject.Measures;

        //    Assert.IsEmpty(actual);
        //}

        //[Test]
        //public void TestSetMeasures()
        //{
        //    Measure testMeasure = new Measure();
        //    testedObject.Measures.Add(testMeasure);
        //    Measure actual = testedObject.Measures[0];

        //    Assert.AreEqual(testMeasure, actual);
        //}

        //[Test]
        //public void TestSetMultipleMeasures()
        //{
        //    Measure testMeasure = new Measure();
        //    Measure testMeasure2 = new Measure();
        //    testedObject.Measures.Add(testMeasure);
        //    testedObject.Measures.Add(testMeasure2);
        //    List<Measure> actual = testedObject.Measures;

        //    Assert.Contains(testMeasure, actual);
        //    Assert.Contains(testMeasure2, actual);
        //}

        //[Test]
        //public void TestGetEpics()
        //{
        //    List<Epic> actual = testedObject.Epics;

        //    Assert.IsEmpty(actual);
        //}
        

        //[Test]
        //public void TestSetEpics()
        //{
        //    Epic testEpic = new Epic();
        //    testedObject.Epics.Add(testEpic);
        //    Epic actual = testedObject.Epics[0];

        //    Assert.AreEqual(testEpic, actual);
        //}

        //[Test]
        //public void TestSetMultipleEpics()
        //{
        //    Epic testEpic = new Epic();
        //    Epic testEpic2 = new Epic();
        //    testedObject.Epics.Add(testEpic);
        //    testedObject.Epics.Add(testEpic2);
        //    List<Epic> actual = testedObject.Epics;

        //    Assert.Contains(testEpic, actual);
        //    Assert.Contains(testEpic2, actual);
        //}

        [Test]
        public void TestIsBottomOfTree()
        {
            Assert.True(testedObject.IsBottomOfTree());
        }

        //[Test]
        //public void TestIsNotBottomOfEpicTree()
        //{
        //    Epic testEpic = new Epic();
        //    testedObject.Epics.Add(testEpic);
        //    Assert.False(testedObject.IsBottomOfTree());
        //}

        [Test]
        public void TestGenerateNodeID()
        {
            string expected = "node0";
            string actual = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGenerateNodeIDWhenThereAreAlreadyInitiativeNodes()
        {
            initialNode.NodeId = "node0";
            secondNode.NodeId = "node1"; // skipping test for two nodes as this will be covered in this test
            nodeList.Add(initialNode);
            nodeList.Add(secondNode);

            string expected = "node2";
            string actual = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGenerateNodeIDWhenThereAreAlreadyOtherNodes()
        {
            initialNode.NodeId = "node0";
            Node initialOtherNode = new Node();
            initialOtherNode.NodeId = "measure0"; 

            nodeList.Add(initialOtherNode);
            nodeList.Add(initialNode);

            string expected = "node1";
            string actual = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalculateEdge()
        {
            previousNode.NodeId = "goal0";
            currentNode.NodeId = "node0";

            List<Node> expected = new List<Node>();

            expected.Add(previousNode);
            expected.Add(currentNode);

            List<Node> actual = testedObject.CalculateEdge(currentNode, previousNode);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddToEdgeList()
        {
            previousNode.NodeId = "goal0";
            currentNode.NodeId = "node0";
            List<Node> edge = new List<Node>();
            edge = testedObject.CalculateEdge(currentNode, previousNode);

            List<List<Node>> expected = new List<List<Node>>();
            expected.Add(edge);

            List<List<Node>> actual = testedObject.AddToEdgeList(edgeList, edge);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestChangePreviousNode()
        {
            previousNode = testedObject.ChangePreviousNode(previousNode);
            Assert.AreEqual(testedObject, previousNode);
        }

        [Test]
        public void TestPassingUpTheTree()
        {
            initialNode.NodeId = "bet0";

            listHandler.NodeList.Add(initialNode);
            listHandler.PreviousNode = initialNode;

            ListHandler result;
            result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(testedObject, result.NodeList[1]);
            Assert.Contains(testedObject, result.EdgeList[0]);
        }

        [Test]
        public void TestPassingDownTheTree()
        {
            testedObject.Measures.Add(secondNode);

            ListHandler result;
            result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(2, result.NodeList.Count);
            Assert.AreEqual(1, result.EdgeList.Count);
        }
    }
}
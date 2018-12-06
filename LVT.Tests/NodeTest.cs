using System.Collections.Generic;
using NUnit.Framework;

namespace LVT.Tests
{
    public class NodeTest
    {
        private Node testedObject;
        private List<Node> nodeList;
        private List<List<Node>> edgeList;
        private Node previousNode;
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

        [Test]
        public void TestIsNotBottomOfTree()
        {
            Assert.False(testedObject.IsNotBottomOfTree());
        }

        [Test]
        public void TestIsNotBottomOfTreeWhenThereAreLowerNodes()
        {
            testedObject.InternalNodeList.Add(secondNode);

            Assert.True(testedObject.IsNotBottomOfTree());
        }

        [Test]
        public void TestGenerateNodeID()
        {
            string expected = "node0";
            string actual = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGenerateNodeIDWhenThereAreAlreadyNodes()
        {
            initialNode.NodeId = "node0";
            secondNode.NodeId = "node1";
            nodeList.Add(initialNode);
            nodeList.Add(secondNode);

            string expected = "node2";
            string actual = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGenerateNodeIDWhenThereAreOtherNodesWithDifferentNames()
        {
            initialNode.NodeId = "node0";
            Node initialOtherNode = new Node {NodeId = "measure0"};


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
            List<Node> edge = new List<Node> { previousNode, testedObject };
            List<List<Node>> expected = new List<List<Node>> { edge };

            List<List<Node>> actual = testedObject.UpdateEdgeList(edgeList, previousNode);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdatePreviousNode()
        {
            previousNode = testedObject.UpdatePreviousNode(previousNode);
            Assert.AreEqual(testedObject, previousNode);
        }

        [Test]
        public void TestPassingUpTheTree()
        {
            initialNode.NodeId = "bet0";

            listHandler.NodeList.Add(initialNode);
            listHandler.PreviousNode = initialNode;

            ListHandler result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(testedObject, result.NodeList[1]);
            Assert.Contains(testedObject, result.EdgeList[0]);

            Assert.AreEqual("bet0",result.NodeList[0].NodeId);
            Assert.AreEqual("node0",result.NodeList[1].NodeId);

            Assert.AreEqual("bet0", result.EdgeList[0][0].NodeId);
            Assert.AreEqual("node0", result.EdgeList[0][1].NodeId);
        }

        [Test]
        public void TestPassingDownTheTree()
        {
            testedObject.InternalNodeList.Add(secondNode);

            ListHandler result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(2, result.NodeList.Count);
            Assert.AreEqual(1, result.EdgeList.Count);

            Assert.AreEqual("node0", result.NodeList[0].NodeId);
            Assert.AreEqual("node1", result.NodeList[1].NodeId);

            Assert.AreEqual("node0", result.EdgeList[0][0].NodeId);
            Assert.AreEqual("node1", result.EdgeList[0][1].NodeId);
        }

        [Test]
        public void TestPassingDownTheTreeWithMultipleNodes()
        {
            testedObject.InternalNodeList.Add(initialNode);
            testedObject.InternalNodeList.Add(secondNode);

            ListHandler result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(3, result.NodeList.Count);
            Assert.AreEqual(2, result.EdgeList.Count);

            Assert.AreEqual("node2", result.NodeList[2].NodeId);

            Assert.AreEqual("node0", result.EdgeList[1][0].NodeId);
            Assert.AreEqual("node2", result.EdgeList[1][1].NodeId);
        }

        [Test]
        public void TestPassingDownTheTreeWithMultipleBranches()
        {
            secondNode.InternalNodeList.Add(new Node());
            secondNode.InternalNodeList.Add(new Node());

            testedObject.InternalNodeList.Add(secondNode);
            testedObject.InternalNodeList.Add(new Node());

            ListHandler result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(5, result.NodeList.Count);
            Assert.AreEqual(4, result.EdgeList.Count);

            Assert.AreEqual("node0", result.EdgeList[3][0].NodeId);
            Assert.AreEqual("node4", result.EdgeList[3][1].NodeId);
        }
    }
}
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
        [Category("Title")]
        public void DefaultTitle()
        {
            string expectedInitialTitle = "untitled";
            string result = testedObject.Title;

            Assert.AreEqual(expectedInitialTitle, result, "Default Title should be 'untitled'");
        }

        [Test]
        [Category("Title")]
        public void DefaultOverrideable()
        {
            string newTitle = "Test";
            testedObject.Title = newTitle;
            string result = testedObject.Title;

            Assert.AreEqual(newTitle, result, "Default title should be overrideable");
        }

        [Test]
        [Category("GenerateNodeID")]
        public void EmptyNodeList()
        {
            string expected = "node0";
            string result = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, result, "Should generate an ID of '_name'(see constructor) + '0'");
        }

        [Test]
        [Category("GenerateNodeID")]
        public void WithSameTypeOfNodesInNodeList()
        {
            // Simulating similar nodes higher in tree
            initialNode.NodeId = "node0";
            secondNode.NodeId = "node1";
            nodeList.Add(initialNode);
            nodeList.Add(secondNode);

            string expected = "node2";
            string result = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, result, "Should generate consecutive IDs of same type");
        }

        [Test]
        [Category("GenerateNodeID")]
        public void OtherTypesOfNodes()
        {
            initialNode.NodeId = "node0";
            // Simulating other node (to be ignored)
            Node initialOtherNode = new Node {NodeId = "measure0"};

            nodeList.Add(initialOtherNode);
            nodeList.Add(initialNode);

            string expected = "node1";
            string result = testedObject.GenerateNodeID(nodeList);

            Assert.AreEqual(expected, result, "Should ignore IDs of other types");
        }

        [Test]
        [Category("UpdateNodeList")]
        public void CorrectEdgeIsAddedToList()
        {
            previousNode.NodeId = "goal0";
            List<Node> edge = new List<Node> { previousNode, testedObject };
            List<List<Node>> expected = new List<List<Node>> { edge };

            List<List<Node>> result = testedObject.UpdateEdgeList(edgeList, previousNode);

            Assert.AreEqual(expected, result, "Should calculate edge as being previous node to current node then add this to the list");
        }

        [Test]
        [Category("UpdateListHandler")]
        public void CorrectlyUpdateListHandler()
        {
            initialNode.NodeId = "bet0";
            listHandler.NodeList.Add(initialNode);
            listHandler.PreviousNode = initialNode;

            ListHandler result = testedObject.UpdateListHandler(listHandler);

            Assert.AreEqual(testedObject, result.NodeList[1], "NodeList should contain node being tested at end of list");
            Assert.Contains(testedObject, result.EdgeList[0], "EdgeList should contain copy of node being tested (as current node)");
            Assert.AreEqual(testedObject, result.PreviousNode, "The PreviousNode should have been replaced by the node being tested");

            Assert.AreEqual("bet0", result.NodeList[0].NodeId, "bet0 should remain as first in NodeList");
            Assert.AreEqual("node0", result.NodeList[1].NodeId, "Node being tested should be added as second node in NodeList");

            Assert.AreEqual("bet0", result.EdgeList[0][0].NodeId, "bet0 should be the first (previous) node in the edge");
            Assert.AreEqual("node0", result.EdgeList[0][1].NodeId, "The current node should be the second (last) node in the edge");
        }

        [Test]
        [Category("RecursiveTreeCrawler")]
        public void PassingDownTheTree()
        {
            // Simulating being first in the tree with a single child
            testedObject.InternalNodeList.Add(secondNode);

            ListHandler result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(2, result.NodeList.Count, "NodeList should hold both nodes");
            Assert.AreEqual(1, result.EdgeList.Count, "EdgeList should hold one edge");
            Assert.AreEqual(2, result.EdgeList[0].Count, "Edge should be two nodes long");
            Assert.AreEqual(testedObject, result.PreviousNode, "The PreviousNode should be the node being tested");

            Assert.AreEqual("node0", result.NodeList[0].NodeId, "First node should be first in NodeList");
            Assert.AreEqual("node1", result.NodeList[1].NodeId, "Second node should be second in NodeList");

            Assert.AreEqual("node0", result.EdgeList[0][0].NodeId, "First node should be first in edge");
            Assert.AreEqual("node1", result.EdgeList[0][1].NodeId, "Second node should be the second in the edge");
        }

        [Test]
        [Category("RecursiveTreeCrawler")]
        public void PassingDownTheTreeWithMultipleNodesInOneBranch()
        {
            // Simulating being first in the tree with two children
            testedObject.InternalNodeList.Add(initialNode);
            testedObject.InternalNodeList.Add(secondNode);

            ListHandler result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(3, result.NodeList.Count, "NodeList should hold all three nodes");
            Assert.AreEqual(2, result.EdgeList.Count, "EdgeList should hold two edges");
            Assert.AreEqual(2, result.EdgeList[0].Count, "First edge should be two nodes long");
            Assert.AreEqual(2, result.EdgeList[1].Count, "Second edge should be two nodes long");

            Assert.AreEqual("node0", result.NodeList[0].NodeId, "First node (parent) should be first in NodeList");
            Assert.AreEqual("node2", result.NodeList[2].NodeId, "Third node (second child) should be third in NodeList");

            Assert.AreEqual("node0", result.EdgeList[1][0].NodeId, "Second edge should run from the parent");
            Assert.AreEqual("node2", result.EdgeList[1][1].NodeId, "Second edge should run to the second child node");
        }

        [Test]
        [Category("RecursiveTreeCrawler")]
        public void PassingDownTheTreeWithMultipleBranches()
        {
            // Simulating one parent node with two child nodes, first child has two grandchild nodes
            secondNode.InternalNodeList.Add(new Node()); // First grandchild
            secondNode.InternalNodeList.Add(new Node()); // Second grandchild

            testedObject.InternalNodeList.Add(secondNode); // First child

            testedObject.InternalNodeList.Add(new Node()); // Second child

            ListHandler result = testedObject.RecursiveTreeCrawler(listHandler);

            Assert.AreEqual(5, result.NodeList.Count, "NodeList should hold all five nodes");
            Assert.AreEqual(4, result.EdgeList.Count, "EdgeList should hold four edges");

            Assert.AreEqual("node1", result.EdgeList[2][0].NodeId, "Third edge should run from first child");
            Assert.AreEqual("node3", result.EdgeList[2][1].NodeId, "Third edge should run to second grandchild");

            Assert.AreEqual("node0", result.EdgeList[3][0].NodeId, "Fourth edge should run from parent");
            Assert.AreEqual("node4", result.EdgeList[3][1].NodeId, "Fourth edge should run to second child");
        }
    }
}
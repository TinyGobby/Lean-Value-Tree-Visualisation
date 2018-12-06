using NUnit.Framework;
using LVT;
using System.Collections.Generic;

namespace LVT.Tests
{
    class ListHandlerTest
    {
        private ListHandler testedObject;

        [SetUp]
        public void SetUp()
        {
            testedObject = new ListHandler();
        }

        //[Test]
        //public void TestGetNodeList()
        //{
        //    List<Node> actual = testedObject.NodeList;

        //    Assert.IsEmpty(actual);
        //}

        //[Test]
        //public void TestSetNodeList()
        //{
        //    Node expected = new Node();
        //    testedObject.NodeList.Add(expected);
        //    Node actual = testedObject.NodeList[0];

        //    Assert.AreEqual(expected, actual);
        //}
    }
}

﻿using LVT.LVT.Services;
using NUnit.Framework;

namespace LVT.Tests
{
    class EpicPresenterTests
    {
        private EpicPresenter _epicPresenter;
        private Epic _testEpic;

        [SetUp]
        public void SetupForTest()
        {
            _epicPresenter = new EpicPresenter();
            _testEpic = new Epic("testDescription", "testDeadline");
        }

        [Test]
        public void EpicPresenterTest()
        {
            string ParentNode = "Parent Initiative NodeID";

            string result = _epicPresenter.VisualizeToString(_testEpic, ParentNode);
            string expected = "[{ v: '" + _testEpic.NodeID + "', f: 'Epic" + "<div style=\"font-style:italic\">" + $"{_testEpic.Description}" + "</div>" +
                                                                   "<div style=\"font-style:italic\">" + $"{_testEpic.Deadline}" + "</div>" +
                                                                   "'}, " + $"'{ParentNode}']";

            Assert.AreEqual(expected, result);
        }
    }
}

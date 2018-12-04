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
        public void checkForMeasures()
        {
            List<Measure> result = testedObject.Measures;

            Assert.IsEmpty(result);
        }
    }
}
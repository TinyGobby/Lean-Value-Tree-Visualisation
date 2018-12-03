using NUnit.Framework;
using LVT;

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
            string result = testedObject.getTitle();

            Assert.AreEqual(result, expectedInitialTitle);
        }
    }
}
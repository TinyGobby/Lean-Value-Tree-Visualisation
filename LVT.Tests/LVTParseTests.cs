using LVT.LVT.Services;
using NUnit.Framework;
using System.IO;
namespace LVT.Tests
{
    [TestFixture]
    public class ParseJSONLVTFromStreamTest
    {
        [Test]
        public void ParseJsonLVT()
        {   //this opens the TestLVT file stored in the project's resources
            Stream TestStream = new MemoryStream(Properties.Resources.TestLVT);
            StreamReader TestStreamReader = new StreamReader(TestStream);

            JsonParser TestParser = new JsonParser();
            LeanValueTree TestSingleBranchLVT = TestParser.ParseJsonLVTFromStream(TestStreamReader);

            Assert.IsInstanceOf(typeof(LeanValueTree), TestSingleBranchLVT, "ParseJsonLVT should return LeanValueTree object");
            Assert.AreNotEqual(null, TestSingleBranchLVT.Vision, "ParseJsonLVT should populate objects inside the LVT");
        }
    }

    [TestFixture]
    public class LVTObjectTests
    {
        LeanValueTree SingleBranchLVT;

        [SetUp]
        public void Setup()
        {
            Stream stream = new MemoryStream(Properties.Resources.TestLVT);
            StreamReader streamReader = new StreamReader(stream);
            JsonParser Parser = new JsonParser();
            SingleBranchLVT = Parser.ParseJsonLVTFromStream(streamReader);
        }

         [Test]
        public void SingleBranchLVT_Vision_Tests()
        {
            Vision VisionObj = SingleBranchLVT.Vision;

            Assert.AreEqual("visionTitle", VisionObj.Title, "Vision should have title");
            Assert.IsInstanceOf(typeof(Vision), VisionObj, "Test Vision should be instance of Vision Class");
            Assert.AreEqual(1, VisionObj.Goals.Count, "Test Vision should have one goal");
        }

        [Test]
        public void SingleBranchLVT_Goal()
        {
            Goal GoalObj = SingleBranchLVT.Vision.Goals[0];

            Assert.IsInstanceOf(typeof(Goal), GoalObj, "Test Goal should be instance of Goal class");
            Assert.AreEqual("goalTitle", GoalObj.Title, "Test Goal should have title");
            Assert.AreEqual(1, GoalObj.Bets.Count, "Test Goal should have one Bet");
        }

        [Test]
        public void SingleBranchLVT_Bet()
        {
            BetOld BetObj = SingleBranchLVT.Vision.Goals[0].Bets[0];

            Assert.IsInstanceOf(typeof(BetOld), BetObj, "Test Bet should be instance of Bet class");
            Assert.AreEqual("betTitle", BetObj.Title, "Test Bet should have a title");
            Assert.AreEqual(1, BetObj.Initiatives.Count, "Test Bet should have one Initiative");
        }

        [Test]
        public void SingleBranchLVT_Initiative()
        {
            InitiativeOld InitiativeObj = SingleBranchLVT.Vision.Goals[0].Bets[0].Initiatives[0];

            Assert.IsInstanceOf(typeof(InitiativeOld), InitiativeObj, "Test Initiative should be instance of Iniative class");
            Assert.AreEqual("initiativeTitle", InitiativeObj.Title, "Test Initiative should have title");
            Assert.AreEqual(1, InitiativeObj.Measures.Count, "Test Initiative should have one Measure");
            Assert.AreEqual(1, InitiativeObj.Epics.Count, "Test Initiative should have one Epic");
        }

        [Test]
        public void SingleBranchLVT_Measure()
        {
            MeasureOld MeasureObj = SingleBranchLVT.Vision.Goals[0].Bets[0].Initiatives[0].Measures[0];

            Assert.IsInstanceOf(typeof(MeasureOld), MeasureObj, "Test Measure is instance of Measure class");
            Assert.AreEqual("measureDescription", MeasureObj.Description, "Test Measure has a description");
            Assert.AreEqual("measureDeadline", MeasureObj.Deadline, "Test Measure has a deadline");
            Assert.AreEqual(1, MeasureObj.Amount, "Test Measure has an amount");
            Assert.AreEqual("measureUnits", MeasureObj.Units, "Test Measure has units");
        }

        [Test]
        public void SingleBranchLVT_Epic()
        {
            EpicOld EpicObj = SingleBranchLVT.Vision.Goals[0].Bets[0].Initiatives[0].Epics[0];

            Assert.IsInstanceOf(typeof(EpicOld), EpicObj, "Test Epic is instance of Epic class");
            Assert.AreEqual("epicDescription", EpicObj.Description, "Test Epic has a description");
            Assert.AreEqual("epicDeadline", EpicObj.Deadline, "Test Epic has a deadline");
        }
    }
}
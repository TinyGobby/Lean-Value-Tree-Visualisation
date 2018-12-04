using LVT.LVT.Services;
using NUnit.Framework;

namespace LVT.Tests
{
    [TestFixture]
    public class ParseJSONLVTTest
    {
        [Test]
        public void ParseJsonLVT_ReturnsLVTObject()
        {
            JsonParser Parser = new JsonParser();
            LeanValueTree SingleBranchLVT = Parser.ParseJsonLVT(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT.Tests\TestLVT.json");
            
            Assert.IsInstanceOf(typeof(LeanValueTree), SingleBranchLVT);
        }
    }

    [TestFixture]
    public class TestsLVTVisionObject
    {
        Vision VisionObj;

        [SetUp]
        public void Setup()
        {
            JsonParser Parser = new JsonParser();
            LeanValueTree SingleBranchLVT = Parser.ParseJsonLVT(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT.Tests\TestLVT.json");
            VisionObj = SingleBranchLVT.Vision;
        }

        [Test]
        public void SingleBranchLVT_Vision_HasTitle()
        {
            Assert.AreEqual("visionTitle", VisionObj.Title);
        }

        [Test]
        public void SingleBranchLVT_Vision_IsTypeOfVision()
        {
            Assert.IsInstanceOf(typeof(Vision), VisionObj);
        }

        [Test]
        public void SingleBranchLVT_Vision_HasOneGoal()
        {
            Assert.AreEqual(1, VisionObj.Goals.Count);
        }
    }

    [TestFixture]
    public class TestsLVTGoalObject
    {
        Goal GoalObj;

        [SetUp]
        public void Setup()
        {
            JsonParser Parser = new JsonParser();
            LeanValueTree SingleBranchLVT = Parser.ParseJsonLVT(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT.Tests\TestLVT.json");
            GoalObj = SingleBranchLVT.Vision.Goals[0];
        }

        [Test]
        public void SingleBranchLVT_Goal_IsTypeOfGoal()
        {
            Assert.IsInstanceOf(typeof(Goal), GoalObj,"testObj");
        }

        [Test]
        public void SingleBranchLVT_Goal_HasTitle()

        {
            Assert.AreEqual("goalTitle", GoalObj.Title);
        }

        [Test]
        public void SingleBranchLVT_Goal_HasOneBet()
        {
            Assert.AreEqual(1, GoalObj.Bets.Count);
        }
    }

    [TestFixture]
    public class TestsLVTBetObject
    {
        Bet BetObj;

        [SetUp]
        public void Setup()
        {
            JsonParser Parser = new JsonParser();
            LeanValueTree SingleBranchLVT = Parser.ParseJsonLVT(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT.Tests\TestLVT.json");
            BetObj = SingleBranchLVT.Vision.Goals[0].Bets[0];
        }

        [Test]
        public void SingleBranchLVT_Bet_IsTypeOfBet()
        {
            Assert.IsInstanceOf(typeof(Bet), BetObj);
        }

        [Test]
        public void SingleBranchLVT_Bet_HasTitle()
        {
            Assert.AreEqual("betTitle", BetObj.Title);
        }

        [Test]
        public void SingleBranchLVT_Bet_HasOneInitiative()
        {
            Assert.AreEqual(1, BetObj.Initiatives.Count);
        }
    }

    [TestFixture]
    public class TestsLVTInitiativeObject
    {
        Initiative InitiativeObj;

        [SetUp]
        public void Setup()
        {
            JsonParser Parser = new JsonParser();
            LeanValueTree SingleBranchLVT = Parser.ParseJsonLVT(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT.Tests\TestLVT.json");
            InitiativeObj = SingleBranchLVT.Vision.Goals[0].Bets[0].Initiatives[0];
        }
        [Test]
        public void SingleBranchLVT_Initiative_IsTypeOfInitiative()
        {
            Assert.IsInstanceOf(typeof(Initiative), InitiativeObj);
        }

        [Test]
        public void SingleBranchLVT_Initiative_HasTitle()
        {
            Assert.AreEqual("initiativeTitle", InitiativeObj.Title);
        }

        [Test]
        public void SingleBranchLVT_Initative_HasOneMeasure()
        {
            Assert.AreEqual(1, InitiativeObj.Measures.Count);
        }

        [Test]
        public void SingleBranchLVT_Initative_HasOneEpic()
        {
            Assert.AreEqual(1, InitiativeObj.Epics.Count);
        }
    }

    [TestFixture]
    public class TestsLVTMeasureObj
    {
        Measure MeasureObj;

        [SetUp]
        public void Setup()
        {
            JsonParser Parser = new JsonParser();
            LeanValueTree SingleBranchLVT = Parser.ParseJsonLVT(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT.Tests\TestLVT.json");
            MeasureObj = SingleBranchLVT.Vision.Goals[0].Bets[0].Initiatives[0].Measures[0];
        }
        [Test]
        public void SingleBranchLVT_Measure_IsTypeOfMeasure()
        {
            Assert.IsInstanceOf(typeof(Measure), MeasureObj);
        }

        [Test]
        public void SingleBranchLVT_Measure_HasDescription()
        {
            Assert.AreEqual("measureDescription", MeasureObj.Description);
        }

        [Test]
        public void SingleBranchLVT_Measure_HasDeadline()
        {
            Assert.AreEqual("measureDeadline", MeasureObj.Deadline);
        }

        [Test]
        public void SingleBranchLVT_Measure_HasAmount()
        {
            Assert.AreEqual(1, MeasureObj.Amount);
        }

        [Test]
        public void SingleBranchLVT_Measure_HasUnits()
        {
            Assert.AreEqual("measureUnits", MeasureObj.Units);
        }
    }

    [TestFixture]
    public class TestsLVTEpicObj
    {
        Epic EpicObj;

        [SetUp]
        public void Setup()
        {
            JsonParser Parser = new JsonParser();
            LeanValueTree SingleBranchLVT = Parser.ParseJsonLVT(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT.Tests\TestLVT.json");
            EpicObj = SingleBranchLVT.Vision.Goals[0].Bets[0].Initiatives[0].Epics[0];
        }

        [Test]
        public void SingleBranchLVT_Epic_IsTypeOfEpic()
        {
            Assert.IsInstanceOf(typeof(Epic), EpicObj);
        }

        [Test]
        public void SingleBranchLVT_Measure_HasDescription()
        {
            Assert.AreEqual("epicDescription", EpicObj.Description);
        }

        [Test]
        public void SingleBranchLVT_Measure_HasDeadline()
        {
            Assert.AreEqual("epicDeadline", EpicObj.Deadline);
        }
    }  
}
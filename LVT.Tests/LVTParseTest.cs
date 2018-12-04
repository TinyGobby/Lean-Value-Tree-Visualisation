using System;
using System.Collections.Generic;
using System.Text;
using LVT;

using NUnit.Framework;

namespace LVT.Tests
{
    public class LVTParseTest
    {
        LeanValueTree singleBranchLVT;

        [SetUp]
        public void Setup()
        {
            singleBranchLVT = Program.ParseJsonLVT();
        }

        [Test]
        public void ParseJsonLVT_ReturnsLVTObject()
        {
            Assert.IsInstanceOf(typeof(LeanValueTree), singleBranchLVT);
        }

        [Test]
        public void ParseJsonLVT_HasVisionTitle()

        {
            string VisionTitle = singleBranchLVT.Vision.Title;
            Assert.AreEqual("visionTitle", VisionTitle);
        }
    }
}
using LVT.LVT.Services;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LVT.Tests
{
    class ReadAndWriteTests
    {

        [Test]
        public void BuildTreeCreatesStringWhenHandedCorrectJson()
        {
            Stream TestStream = new MemoryStream(Properties.Resources.TestLVT);
            StreamReader TestStreamReader = new StreamReader(TestStream);

            string result = ReadAndWrite.BuildTree(TestStreamReader);
            string expected = "[[{ v: 'e7831d25-278b-4fdc-aae9-8d8b1d732302', f: 'Vision<div style=\"font-style:italic\">visionTitle</div>'}, ''], [{ v: '905e76da-e494-4db5-8191-d5c641af7135', f: 'Goal<div style=\"font-style:italic\">goalTitle</div>'}, 'e7831d25-278b-4fdc-aae9-8d8b1d732302'], [{ v: '50413412-901b-473b-aca0-33ef5dd08f1e', f: 'Bet<div style=\"font-style:italic\">betTitle</div>'}, '905e76da-e494-4db5-8191-d5c641af7135'], [{ v: 'fce8338f-519d-4ae2-8a8f-f9cd374653bf', f: 'Initiative<div style=\"font-style:italic\">initiativeTitle</div>'}, '50413412-901b-473b-aca0-33ef5dd08f1e'] , [{ v: 'e9eb3cf6-0e09-4330-9bb5-6ebd2bcb0820', f: 'Measure<div style=\"font-style:italic\">measureDescription</div><div style=\"font-style:italic\">measureDeadline</div><div style=\"font-style:italic\">1</div><div style=\"font-style:italic\">measureUnits</div>'}, 'fce8338f-519d-4ae2-8a8f-f9cd374653bf'] , [{ v: 'd46622c4-dde1-4195-89f3-4aef4c0e58ba', f: 'Epic<div style=\"font-style:italic\">epicDescription</div><div style=\"font-style:italic\">epicDeadline</div>'}, 'fce8338f-519d-4ae2-8a8f-f9cd374653bf']]";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BuildTreeCreatesStringOfSameLength()
        {
            Stream TestStream = new MemoryStream(Properties.Resources.TestLVT);
            StreamReader TestStreamReader = new StreamReader(TestStream);

            string result = ReadAndWrite.BuildTree(TestStreamReader);
            string expected = "[[{ v: 'e7831d25-278b-4fdc-aae9-8d8b1d732302', f: 'Vision<div style=\"font-style:italic\">visionTitle</div>'}, ''], [{ v: '905e76da-e494-4db5-8191-d5c641af7135', f: 'Goal<div style=\"font-style:italic\">goalTitle</div>'}, 'e7831d25-278b-4fdc-aae9-8d8b1d732302'], [{ v: '50413412-901b-473b-aca0-33ef5dd08f1e', f: 'Bet<div style=\"font-style:italic\">betTitle</div>'}, '905e76da-e494-4db5-8191-d5c641af7135'], [{ v: 'fce8338f-519d-4ae2-8a8f-f9cd374653bf', f: 'Initiative<div style=\"font-style:italic\">initiativeTitle</div>'}, '50413412-901b-473b-aca0-33ef5dd08f1e'] , [{ v: 'e9eb3cf6-0e09-4330-9bb5-6ebd2bcb0820', f: 'Measure<div style=\"font-style:italic\">measureDescription</div><div style=\"font-style:italic\">measureDeadline</div><div style=\"font-style:italic\">1</div><div style=\"font-style:italic\">measureUnits</div>'}, 'fce8338f-519d-4ae2-8a8f-f9cd374653bf'] , [{ v: 'd46622c4-dde1-4195-89f3-4aef4c0e58ba', f: 'Epic<div style=\"font-style:italic\">epicDescription</div><div style=\"font-style:italic\">epicDeadline</div>'}, 'fce8338f-519d-4ae2-8a8f-f9cd374653bf']]";
            int resultLength = result.Length;
            int expectedLength = expected.Length;
            Assert.AreEqual(expectedLength, resultLength);
        }
    }
}

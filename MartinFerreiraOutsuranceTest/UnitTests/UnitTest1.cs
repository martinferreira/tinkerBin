using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MartinFerreiraOutsuranceTest;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        string[] input = new[] {"Matt,Tim,102 Long Lane,29384857",
                        "Heinrich,Johnson,22 Jones Rd,29384857",
                        "Johnson,Smith,31 Clifton Rd,29384857",
                        "Tim,Johnson,12 Acton St,29384857" };

        [TestMethod]
        public void GivenAListOfName_WhenPuttingItThroughTheParser_ThenItMustReturnTheFrequencyAndSortThemAlpabetically()
        {
            var parser = new Parser(input);
            var output = parser.GetFrequency();

            var expectedOutput = new[] {
                new StatsItem("Johnson", 3),
                new StatsItem("Tim", 2),
                new StatsItem("Heinrich", 1),
                new StatsItem("Matt", 1),
                new StatsItem("Smith", 1)
            };

            Assert.AreEqual(expectedOutput.Length, output.Count, "Count is wrong");

            for (int a = 0; a < expectedOutput.Length; a++)
            {
                Assert.AreEqual(expectedOutput[a].Item, output[a].Item, $"Item {a} is wrong");
                Assert.AreEqual(expectedOutput[a].Count, output[a].Count, $"Count {a} Item is wrong");
            }
        }

        [TestMethod]
        public void GivenAListOfName_WhenPuttingItThroughTheParser_ThenItMustReturnTheAddressesAlphabetically()
        {

            var parser = new Parser(input);
            var output = parser.GetStreetNames();

            var expectedOutput = new[] { "12 Acton St",
                "31 Clifton Rd",
                "22 Jones Rd",
                "102 Long Lane" };
            for (int a = 0; a < expectedOutput.Length; a++)
            {
                Assert.AreEqual(expectedOutput[a], output[a], $"Item {a} is wrong");
            }

        }

        [TestMethod]
        public void GivenLineItem_WhenConstructing_ThenItMustPopulateTheObjectCorrectly()
        {
            var givenInput = "Matt,Tim,102 Long Lane,29384857";
            var output = new LineItem(givenInput);
            Assert.AreEqual("Matt", output.FirstName);
            Assert.AreEqual("Tim", output.LastName);
            Assert.AreEqual("102 Long Lane", output.Address);
            Assert.AreEqual("LongLane", output.SortedAddress);
            Assert.AreEqual("29384857", output.PhoneNumber);
        }

        [TestMethod]
        public void GivenStatsItem_WhenCallingToStribg_ThenItMustReturnItAccordingToTheStructure()
        {
            var input = new StatsItem("Name", 999);
            Assert.AreEqual("Name, 999", input.ToString() );

        }
    }
}

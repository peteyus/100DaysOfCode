namespace AoC2023Tests
{
    using AoC2023.Day1;
    using System.Diagnostics;

    [TestClass]
    public class Day1Tests
    {
        private Day1 classUnderTest = new Day1();

        [TestClass]
        public class Part1ProcessLineTests : Day1Tests
        {
            [TestMethod]
            public void ProcessesFirstAndLastDigitOfLine()
            {
                var result = this.classUnderTest.ProcessLine("1abc2");
                Assert.AreEqual(12, result);
            }
        }

        [TestClass]
        public class Part1InputTests : Day1Tests
        {
            [TestMethod]
            public void ProcessInputPartOne()
            {
                var result = this.classUnderTest.ProcessPartOneInput();
                Assert.IsTrue(result > 0);
                Debug.WriteLine(result);
            }
        }

        [TestClass]
        public class Part2ProcessLineTests : Day1Tests
        {
            [TestMethod]
            public void ProcessesFirstAndLastDigitOfLineAsString()
            {
                var result = this.classUnderTest.ProcessLinePartTwo("one2three");
                Assert.AreEqual(13, result);
            }

            [TestMethod]
            public void ProcessesExpectedValuesForCalibration()
            {
                Dictionary<string, int> expectedValues = new Dictionary<string, int>() { 
                    { "two1nine", 29 }, 
                    { "eightwothree", 83 }, 
                    { "abcone2threexyz", 13 },
                    { "xtwone3four", 24 },
                    { "4nineeightseven2", 42 },
                    { "zoneight234", 14 },
                    { "7pqrstsixteen", 76} };

                foreach (var row in expectedValues)
                {
                    var result = classUnderTest.ProcessLinePartTwo(row.Key);
                    Assert.AreEqual(row.Value, result);
                }
            }
        }

        [TestClass]
        public class Part2InputTests : Day1Tests
        {
            [TestMethod]
            public void ProcessInputPartTwo()
            {
                var result = this.classUnderTest.ProcessPartTwoInput(null);
                Assert.IsTrue(result > 0);
                Debug.WriteLine(result);
            }

            [TestMethod]
            public void CalibrationTestPartTwo()
            {
                string calibrationValues = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";
                var result = this.classUnderTest.ProcessPartTwoInput(calibrationValues);
                Assert.AreEqual(281, result);
            }
        }
    }
}
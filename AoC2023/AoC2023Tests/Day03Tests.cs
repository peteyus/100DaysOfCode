namespace AoC2023Tests
{
    using AoC2023.Day3;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class Day03Tests
    {
        private Day3 classUnderTest = new Day3();
        string sampleInput = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

        [TestClass]
        public class PartOne : Day03Tests
        {
            [TestMethod]
            public void IdentifiesSymbolsInSampleInput()
            {
                var expectedResults = new List<Symbol>() { new Symbol(3, 1), new Symbol(6, 3), new Symbol(3, 4), new Symbol(5, 5), new Symbol(3, 8), new Symbol(5, 8) };
                var result = classUnderTest.GetSymbolLocations(sampleInput);

                foreach (var expected in expectedResults)
                {
                    Assert.IsTrue(result.Any(row => row.X == expected.X && row.Y == expected.Y), $"No match for {expected.X},{expected.Y}");
                }
            }

            [TestMethod]
            public void IdentifiesNumbersInSampleInput()
            {
                var expectedResults = new List<GridNumber>()
                {
                    new GridNumber() { XStart = 0, XFinish = 2, Y = 0, Value = 467 },
                    new GridNumber() { XStart = 5, XFinish = 7, Y = 0, Value = 114 },
                    new GridNumber() { XStart = 2, XFinish = 3, Y = 2, Value = 35 },
                    new GridNumber() { XStart = 6, XFinish = 8, Y = 2, Value = 633 },
                    new GridNumber() { XStart = 0, XFinish = 2, Y = 4, Value = 617 },
                    new GridNumber() { XStart = 7, XFinish = 8, Y = 5, Value = 58 },
                    new GridNumber() { XStart = 2, XFinish = 4, Y = 6, Value = 592 },
                    new GridNumber() { XStart = 6, XFinish = 8, Y = 7, Value = 755 },
                    new GridNumber() { XStart = 1, XFinish = 3, Y = 9, Value = 664 },
                    new GridNumber() { XStart = 5, XFinish = 7, Y = 9, Value = 598 }
                };

                var result = classUnderTest.GetGridNumbers(sampleInput);

                foreach (var expected in expectedResults)
                {
                    Assert.IsTrue(result.Any(row => row.XStart == expected.XStart && row.XFinish == expected.XFinish && row.Y == expected.Y && row.Value == expected.Value),
                        $"No match for {expected.Value} at {expected.XStart},{expected.Y}");
                }
            }

            [TestMethod]
            public void IdentifiesNumbersTouchingSymbolsInSampleOutput()
            {
                var expectedResults = new List<GridNumber>()
                {
                    new GridNumber() { XStart = 0, XFinish = 2, Y = 0, Value = 467 },
                    new GridNumber() { XStart = 2, XFinish = 3, Y = 2, Value = 35 },
                    new GridNumber() { XStart = 6, XFinish = 8, Y = 2, Value = 633 },
                    new GridNumber() { XStart = 0, XFinish = 2, Y = 4, Value = 617 },
                    new GridNumber() { XStart = 2, XFinish = 4, Y = 6, Value = 592 },
                    new GridNumber() { XStart = 6, XFinish = 8, Y = 7, Value = 755 },
                    new GridNumber() { XStart = 1, XFinish = 3, Y = 9, Value = 664 },
                    new GridNumber() { XStart = 5, XFinish = 7, Y = 9, Value = 598 }
                };

                var result = classUnderTest.GetGridNumbersTouchingSymbols(classUnderTest.GetSymbolLocations(sampleInput), classUnderTest.GetGridNumbers(sampleInput));

                foreach (var expected in expectedResults)
                {
                    Assert.IsTrue(result.Any(row => row.XStart == expected.XStart && row.XFinish == expected.XFinish && row.Y == expected.Y && row.Value == expected.Value),
                        $"No match for {expected.Value} at {expected.XStart},{expected.Y}");
                }
            }

            [TestMethod]
            public void ParsesSampleInput()
            {
                var result = classUnderTest.SumOfPartNumbers(sampleInput);
                Assert.AreEqual(4361, result);
            }

            [TestMethod]
            public void RunPartOne()
            {
                var result = classUnderTest.SumOfPartNumbers(null);
                Debug.WriteLine(result);
                Assert.AreEqual(540212, result);
            }
        }

        [TestClass]
        public class PartTwo : Day03Tests
        {
            [TestMethod]
            public void GeneratesExpectedOutcomeFromSample()
            {
                var result = classUnderTest.SumOfGearRatios(sampleInput);
                Assert.AreEqual(467835, result);
            }

            [TestMethod]
            public void RunPartTwo()
            {
                var result = classUnderTest.SumOfGearRatios(null);
                Debug.WriteLine(result);
                Assert.AreEqual(87605697, result);
            }
        }
    }
}

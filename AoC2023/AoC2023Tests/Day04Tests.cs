﻿namespace AoC2023Tests
{
    using AoC2023.Day04;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class Day04Tests
    {
        private Day4 classUnderTest = new Day4();
        private string sampleInput = @"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

        [TestClass]
        public class PartOne : Day04Tests
        {
            [TestMethod]
            public void ReturnsExpectedValuesForInput()
            {
                var result = this.classUnderTest.GetCardValues(sampleInput);

                var sum = result.Sum();
                Assert.AreEqual(13, sum);
            }

            [TestMethod]
            public void RunPartOne()
            {
                var result = this.classUnderTest.SumValueOfCards(null);
                Debug.WriteLine(result);
                Assert.AreEqual(32001, result);
            }
        }

        [TestClass]
        public class PartTwo : Day04Tests
        {
            [TestMethod]
            public void GeneratesExpectedValuesForSampleInput()
            {
                var result = this.classUnderTest.CountAllScratchCards(sampleInput);
                Assert.AreEqual(30, result);
            }

            [TestMethod]
            public void RunPartTwo()
            {
                var result = this.classUnderTest.CountAllScratchCards(null);
                Debug.WriteLine(result);
                Assert.AreEqual(5037841, result);
            }
        }
    }
}

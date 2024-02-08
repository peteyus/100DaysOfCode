namespace AoC2023Tests
{
    using AoC2023.Day05;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class Day05Tests
    {
        private Day5 classUnderTest = new Day5();
        private string sampleInput = @"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4";

        [TestClass]
        public class PartOne : Day05Tests
        {
            [TestMethod]
            public void ParsesExpectedSeedIds()
            {
                var result = this.classUnderTest.GetMappedSeeds(sampleInput);
                Assert.AreEqual(4, result.Count());
                Assert.IsTrue(result.Any(s => s.SeedId == 79));
                Assert.IsTrue(result.Any(s => s.SeedId == 14));
                Assert.IsTrue(result.Any(s => s.SeedId == 55));
                Assert.IsTrue(result.Any(s => s.SeedId == 13));
            }

            [TestMethod]
            public void ReturnsExpectedValueForSampleInput()
            {
                var result = this.classUnderTest.GetNearestSoilLocation(sampleInput);
                Assert.AreEqual(35, result);
            }

            [TestMethod]
            public void RunPartOne()
            {
                var result = this.classUnderTest.GetNearestSoilLocation(null);
                Debug.WriteLine(result);
                Assert.AreEqual(382895070, result);
            }
        }
    }
}

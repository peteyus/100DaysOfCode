namespace AoC2023Tests
{
    using AoC2023.Day2;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class Day2Tests
    {
        private Day2 classUnderTest = new Day2();

        [TestClass]
        public class PartOne : Day2Tests
        {
            [TestMethod]
            public void ProcessesLineAsExpected()
            {
                string line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
                var result = this.classUnderTest.GetIdOfPossibleGame(line, 12, 13, 14);

                Assert.IsTrue(result.Possible);
                Assert.AreEqual(1, result.Id);
            }


            [TestMethod]
            public void ProccessSampleAsExpected()
            {
                string game = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

                var result = this.classUnderTest.SumOfPossibleGames(game, 12, 13, 14);
                Assert.AreEqual(8, result);
            }

            [TestMethod]
            public void ProccessesManualSample()
            {
                string game = @"Game 1: 7 green, 4 blue, 3 red; 4 blue, 10 red, 1 green; 1 blue, 9 red
Game 2: 2 red, 4 blue, 3 green; 5 green, 3 red, 1 blue; 3 green, 5 blue, 3 red
Game 3: 12 red, 1 blue; 6 red, 2 green, 3 blue; 2 blue, 5 red, 3 green
Game 4: 3 green, 1 red, 3 blue; 1 red; 2 green, 1 red, 1 blue; 3 green, 1 blue; 2 blue; 2 green, 4 blue
Game 5: 3 blue, 3 red, 8 green; 5 blue, 1 red; 1 green, 19 blue, 3 red; 1 red, 5 green, 3 blue; 4 green, 20 blue, 4 red; 20 blue, 4 green
Game 6: 7 green, 6 blue, 1 red; 3 blue, 5 green, 3 red; 9 blue, 3 red, 6 green; 8 blue, 11 green, 3 red; 2 blue, 1 red; 7 green, 4 blue, 1 red
Game 7: 5 green, 1 blue; 2 green, 2 blue; 1 blue, 1 red; 5 blue, 2 green; 3 green
Game 8: 5 blue, 5 red, 10 green; 6 green, 1 blue, 1 red; 5 red, 2 blue, 16 green; 2 blue, 14 green, 9 red; 9 red, 3 green, 7 blue; 8 red, 4 blue, 10 green
Game 9: 1 red, 1 blue, 7 green; 4 red, 6 green, 2 blue; 6 green, 14 blue, 3 red
Game 10: 1 red, 16 green, 3 blue; 1 red, 3 blue; 6 green; 4 green, 2 blue, 1 red";
                var result = this.classUnderTest.SumOfPossibleGames(game, 12, 13, 14);
                Assert.AreEqual(32, result);
            }

            [TestMethod]
            public void RunPartOne()
            {
                var result = this.classUnderTest.SumOfPossibleGames(null, 12, 13, 14);
                Debug.WriteLine(result);
            }
        }

        [TestClass]
        public class PartTwo : Day2Tests
        {
            [TestMethod]
            public void ProccessesSingleGameAsExpected()
            {
                string line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
                var result = this.classUnderTest.GetIdOfPossibleGame(line, 12, 13, 14);

                Assert.IsTrue(result.Possible);
                Assert.AreEqual(48, result.GamePower);
            }

            [TestMethod]
            public void ProccessesSampleAsExpected()
            {
                string game = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

                var result = this.classUnderTest.PowerOfPossibleGames(game, 12, 13, 14);
                Assert.AreEqual(2286, result);
            }

            [TestMethod]
            public void ProccessesManualSampleAsExpected()
            {
                string game = @"Game 1: 7 green, 4 blue, 3 red; 4 blue, 10 red, 1 green; 1 blue, 9 red
Game 2: 2 red, 4 blue, 3 green; 5 green, 3 red, 1 blue; 3 green, 5 blue, 3 red
Game 3: 12 red, 1 blue; 6 red, 2 green, 3 blue; 2 blue, 5 red, 3 green
Game 4: 3 green, 1 red, 3 blue; 1 red; 2 green, 1 red, 1 blue; 3 green, 1 blue; 2 blue; 2 green, 4 blue
Game 5: 3 blue, 3 red, 8 green; 5 blue, 1 red; 1 green, 19 blue, 3 red; 1 red, 5 green, 3 blue; 4 green, 20 blue, 4 red; 20 blue, 4 green
Game 6: 7 green, 6 blue, 1 red; 3 blue, 5 green, 3 red; 9 blue, 3 red, 6 green; 8 blue, 11 green, 3 red; 2 blue, 1 red; 7 green, 4 blue, 1 red
Game 7: 5 green, 1 blue; 2 green, 2 blue; 1 blue, 1 red; 5 blue, 2 green; 3 green
Game 8: 5 blue, 5 red, 10 green; 6 green, 1 blue, 1 red; 5 red, 2 blue, 16 green; 2 blue, 14 green, 9 red; 9 red, 3 green, 7 blue; 8 red, 4 blue, 10 green
Game 9: 1 red, 1 blue, 7 green; 4 red, 6 green, 2 blue; 6 green, 14 blue, 3 red
Game 10: 1 red, 16 green, 3 blue; 1 red, 3 blue; 6 green; 4 green, 2 blue, 1 red";
                var result = this.classUnderTest.PowerOfPossibleGames(game, 12, 13, 14);
                Assert.AreEqual(2885, result);
            }

            [TestMethod]
            public void RunPartTwo()
            {
                var result = this.classUnderTest.PowerOfPossibleGames(null, 12, 13, 14);
                Debug.WriteLine(result);
                Assert.AreNotEqual(56323, result);
            }
        }
    }
}

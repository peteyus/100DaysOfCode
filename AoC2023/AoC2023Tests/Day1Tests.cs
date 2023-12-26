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
    }
}
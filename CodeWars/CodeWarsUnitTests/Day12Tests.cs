using CodeWars.Day12;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWarsUnitTests
{
    [TestClass]
    public class Day12Tests
    {
        private Connect4 test1 = new Connect4();
        private Connect4 test2 = new Connect4();
        private Connect4 test3 = new Connect4();
        private Connect4 test4 = new Connect4();

        // Test 1
        [TestMethod]
        public void BasicTest1a()
        {
            Assert.AreEqual("Player 1 has a turn", test1.play(0), "Should return: 'Player 1 has a turn'");
        }

        [TestMethod]
        public void BasicTest1b()
        {
            BasicTest1a();
            Assert.AreEqual("Player 2 has a turn", test1.play(0), "Should return: 'Player 2 has a turn'");
        }

        // Test 2
        [TestMethod]
        public void BasicTest2a()
        {
            BasicTest1b();
            Assert.AreEqual("Player 1 has a turn", test2.play(0), "Should return: 'Player 1 has a turn'");
        }

        [TestMethod]
        public void BasicTest2b()
        {
            BasicTest2a();
            Assert.AreEqual("Player 2 has a turn", test2.play(1), "Should return: 'Player 2 has a turn'");
        }

        [TestMethod]
        public void BasicTest2c()
        {
            BasicTest2b();
            Assert.AreEqual("Player 1 has a turn", test2.play(0), "Should return: 'Player 1 has a turn'");
        }

        [TestMethod]
        public void BasicTest2d()
        {
            BasicTest2c();
            Assert.AreEqual("Player 2 has a turn", test2.play(1), "Should return: 'Player 2 has a turn'");
        }

        [TestMethod]
        public void BasicTest2e()
        {
            BasicTest2d();
            Assert.AreEqual("Player 1 has a turn", test2.play(0), "Should return: 'Player 1 has a turn'");
        }

        [TestMethod]
        public void BasicTest2f()
        {
            BasicTest2e();
            Assert.AreEqual("Player 2 has a turn", test2.play(1), "Should return: 'Player 2 has a turn'");
        }

        [TestMethod]
        public void BasicTest2g()
        {
            BasicTest2f();
            Assert.AreEqual("Player 1 wins!", test2.play(0), "Should return: 'Player 1 wins!'");
        }

        // Test 3
        [TestMethod]
        public void BasicTest3a()
        {
            Assert.AreEqual("Player 1 has a turn", test3.play(4), "Should return: 'Player 1 has a turn'");
        }
        [TestMethod]
        public void BasicTest3b()
        {
            BasicTest3a();
            Assert.AreEqual("Player 2 has a turn", test3.play(4), "Should return: 'Player 2 has a turn'");
        }
        [TestMethod]
        public void BasicTest3c()
        {
            BasicTest3b();
            Assert.AreEqual("Player 1 has a turn", test3.play(4), "Should return: 'Player 1 has a turn'");
        }
        [TestMethod]
        public void BasicTest3d()
        {
            BasicTest3c();
            Assert.AreEqual("Player 2 has a turn", test3.play(4), "Should return: 'Player 2 has a turn'");
        }
        [TestMethod]
        public void BasicTest3e()
        {
            BasicTest3d();
            Assert.AreEqual("Player 1 has a turn", test3.play(4), "Should return: 'Player 1 has a turn'");
        }
        [TestMethod]
        public void BasicTest3f()
        {
            BasicTest3e();
            Assert.AreEqual("Player 2 has a turn", test3.play(4), "Should return: 'Player 2 has a turn'");
        }
        [TestMethod]
        public void BasicTest3g()
        {
            BasicTest3f();
            Assert.AreEqual("Column full!", test3.play(4), "Should return: 'Column full!'");
        }


        // Test 4
        [TestMethod]
        public void BasicTest4a()
        {
            Assert.AreEqual("Player 1 has a turn", test4.play(1), "Should return: 'Player 1 has a turn'");
        }
        [TestMethod]
        public void BasicTest4b()
        {
            BasicTest4a();
            Assert.AreEqual("Player 2 has a turn", test4.play(1), "Should return: 'Player 2 has a turn'");
        }
        [TestMethod]
        public void BasicTest4c()
        {
            BasicTest4b();
            Assert.AreEqual("Player 1 has a turn", test4.play(2), "Should return: 'Player 1 has a turn'");
        }
        [TestMethod]
        public void BasicTest4d()
        {
            BasicTest4c();
            Assert.AreEqual("Player 2 has a turn", test4.play(2), "Should return: 'Player 2 has a turn'");
        }
        [TestMethod]
        public void BasicTest4e()
        {
            BasicTest4d();
            Assert.AreEqual("Player 1 has a turn", test4.play(3), "Should return: 'Player 1 has a turn'");
        }
        [TestMethod]
        public void BasicTest4f()
        {
            BasicTest4e();
            Assert.AreEqual("Player 2 has a turn", test4.play(3), "Should return: 'Player 2 has a turn'");
        }
        [TestMethod]
        public void BasicTest4g()
        {
            BasicTest4f();
            Assert.AreEqual("Player 1 wins!", test4.play(4), "Should return: 'Player 1 wins!'");
        }
        [TestMethod]
        public void BasicTest4h()
        {
            BasicTest4g();
            Assert.AreEqual("Game has finished!", test4.play(4), "Should return: 'Game has finished!'");
        }

    }

}
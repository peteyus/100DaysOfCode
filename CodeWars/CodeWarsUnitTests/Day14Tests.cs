﻿
namespace CodeWarsUnitTests
{
    using CodeWars.Day14;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("[[3, 1]]", Dioph.solEquaStr(5));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("[[4, 1]]", Dioph.solEquaStr(12));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("[[7, 3]]", Dioph.solEquaStr(13));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("[[4, 0]]", Dioph.solEquaStr(16));
        }

        [TestMethod]
        public void NoResult()
        {
            Assert.AreEqual("[]", Dioph.solEquaStr(1));
        }
    }
}
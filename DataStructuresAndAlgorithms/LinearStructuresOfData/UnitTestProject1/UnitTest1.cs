using System;
using System.Collections.Generic;
using _04.LongestSubsequanceWithList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetLongestSubSequanceEmpty()
        {
            List<int> list = new List<int>();
            var result = LongestSubsequance.GetLongestSubSequance(list);
            Assert.AreEqual(0, result.Count);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void TestGetLongestSubSequanceSingle()
        {
            List<int> list = new List<int>() { 5, 5, 5};
            var result = LongestSubsequance.GetLongestSubSequance(list);
            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int>(){5, 5, 5}, result);
        }

        [TestMethod]
        public void TestGetLongestSubSequanceDoubleWithSameCount()
        {
            List<int> list = new List<int>() { 5, 5, 6, 6 };
            var result = LongestSubsequance.GetLongestSubSequance(list);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new List<int>(){5, 5}, result);
        }

        [TestMethod]
        public void TestGetLongestSubSequanceDoubleWithDiffirentCount()
        {
            List<int> list = new List<int>() { 5, 5, 5, 6, 6 };
            var result = LongestSubsequance.GetLongestSubSequance(list);
            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int>(){5, 5, 5}, result);
        }

        [TestMethod]
        public void TestGetLongestSubSequanceSecondSeqBigger()
        {
            List<int> list = new List<int>() { 5, 5, 6, 6, 6 };
            var result = LongestSubsequance.GetLongestSubSequance(list);
            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int>() { 6, 6, 6 }, result);
        }

        [TestMethod]
        public void TestGetLongestSubSequanceNoSeq()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            var result = LongestSubsequance.GetLongestSubSequance(list);
            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEqual(new List<int>() { 1 }, result);
        }

        [TestMethod]
        public void TestGetLongestSubSequanceNegativeNumbers()
        {
            List<int> list = new List<int>() { 0, -1, -1, -2, -3 };
            var result = LongestSubsequance.GetLongestSubSequance(list);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new List<int>() { -1, -1 }, result);
        }
    }
}

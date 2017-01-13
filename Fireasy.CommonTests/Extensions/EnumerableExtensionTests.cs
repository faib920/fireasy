using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass]
    public class EnumerableExtensionTests
    {
        [TestMethod]
        public void TestForeach()
        {
            var list = new List<string> { "123", "456" };
            list.ForEach(s =>
                {
                    Console.WriteLine(s);
                });
        }

        [TestMethod]
        public void TestSlice()
        {
            var list = new List<string> { "123", "456", "789", "abc" };
            list.Slice(1, 4).ForEach(s =>
                {
                    Console.WriteLine(s);
                });
        }

        [TestMethod]
        public void TestCycle()
        {
            var list = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            list.Cycle(8, s => Console.Write(s + ","));
            Console.WriteLine();
            list.Cycle(0, s => Console.Write(s + ","));
            Console.WriteLine();
            list.Cycle(2, s => Console.Write(s + ","));
        }
    }
}

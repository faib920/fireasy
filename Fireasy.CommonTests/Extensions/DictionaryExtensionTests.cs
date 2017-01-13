using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass]
    public class DictionaryExtensionTests
    {
        [TestMethod]
        public void TestTryAdd()
        {
            var dict = new Dictionary<string, string> { { "1", "abc" }, { "2", "def" } };

            Console.WriteLine(dict.TryAdd("1", () => "abc"));
            Console.WriteLine(dict.TryAdd("3", () => "ghi"));
        }

        [TestMethod]
        public void TestTryGetValue()
        {
            var dict = new Dictionary<string, string> { { "1", "abc" }, { "2", "def" } };

            Console.WriteLine(dict.TryGetValue("1", () => "abc_1"));
            Console.WriteLine(dict.TryGetValue("3", () => "ghi_1"));
        }

        [TestMethod]
        public void TestAddOrReplace()
        {
            var dict = new Dictionary<string, string> { { "1", "abc" }, { "2", "def" } };

            dict.AddOrReplace("1", "abc_1");
            dict.AddOrReplace("3", "ghi_1");
            Console.WriteLine(dict["1"]);
            Console.WriteLine(dict["3"]);
        }
    }
}

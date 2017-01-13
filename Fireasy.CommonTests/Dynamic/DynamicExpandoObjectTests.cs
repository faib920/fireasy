using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Dynamic.Tests
{
    [TestClass]
    public class DynamicExpandoObjectTests
    {
        [TestMethod]
        public void TestIndex()
        {
            dynamic a = new DynamicExpandoObject();
            a[0, 0] = 222;

            Console.WriteLine(a[0, 0]);

        }
    }
}

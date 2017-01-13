// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Extensions.Test
{
    [TestClass()]
    public class NumericExtensionTests
    {
        [TestMethod()]
        public void GetIntegerPartTest()
        {
            Console.WriteLine((123.65d).GetIntegerPart());
        }

        [TestMethod()]
        public void GetIntegerPartTest1()
        {
            Assert.AreEqual(123, (123.65m).GetIntegerPart());
        }

        [TestMethod()]
        public void GetDecimalPartTest()
        {
            Assert.AreEqual(0.65m, (123.65d).GetDecimalPart());
        }

        [TestMethod()]
        public void GetDecimalPartTest1()
        {
            Assert.AreEqual(0.65m, (123.65m).GetDecimalPart());
        }

        [TestMethod()]
        public void ToUpperTest()
        {
            Console.WriteLine((567033.67d).ToUpper());
        }

        [TestMethod()]
        public void ToUpperTest1()
        {
            Console.WriteLine((567033.67m).ToUpper());
        }
    }
}

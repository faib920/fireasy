// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Extensions.Test
{
    /// <summary>
    /// CharExtensionTests类。
    /// </summary>
    [TestClass()]
    public class CharExtensionTests
    {
        /// <summary>
        /// 测试IsChinese方法。
        /// </summary>
        [TestMethod()]
        public void IsChineseTest()
        {
            Assert.IsTrue('中'.IsChinese());
            Assert.IsFalse('A'.IsChinese());
        }

        /// <summary>
        /// 测试GetAsciiCode方法。
        /// </summary>
        [TestMethod()]
        public void GetAsciiCodeTest()
        {
            Assert.AreEqual(-10544, '中'.GetAsciiCode());
            Assert.AreEqual(65, 'A'.GetAsciiCode());
        }
    }
}

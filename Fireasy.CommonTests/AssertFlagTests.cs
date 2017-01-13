// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Test
{
    /// <summary>
    /// AssertFlagTests类。
    /// </summary>
    [TestClass()]
    public class AssertFlagTests
    {
        /// <summary>
        /// 构造器测试。
        /// </summary>
        [TestMethod()]
        public void AssertFlagTest()
        {
            var assert = new AssertFlag();

            Assert.IsNotNull(assert);
        }

        /// <summary>
        /// 测试AssertTrue方法。
        /// </summary>
        [TestMethod()]
        public void AssertTrueTest()
        {
            var assert = new AssertFlag();

            //第一次调用AssertTrue返回true，第二次调用AssertTrue返回false
            Assert.IsTrue(assert.AssertTrue());
            Assert.IsFalse(assert.AssertTrue());
        }

        /// <summary>
        /// 测试Reset方法。
        /// </summary>
        [TestMethod()]
        public void ResetTest()
        {
            var assert = new AssertFlag();

            //第一次调用AssertTrue返回true，第二次调用AssertTrue返回false
            Assert.IsTrue(assert.AssertTrue());
            Assert.IsFalse(assert.AssertTrue());

            //重置后，再调用AssertTrue，返回true
            assert.Reset();
            Assert.IsTrue(assert.AssertTrue());
        }
    }
}

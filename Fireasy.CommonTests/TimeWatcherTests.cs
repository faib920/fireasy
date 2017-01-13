// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Test
{
    /// <summary>
    /// TimeWatcherTests类。
    /// </summary>
    [TestClass()]
    public class TimeWatcherTests
    {
        /// <summary>
        /// 构造器测试。
        /// </summary>
        [TestMethod()]
        public void WatchTest()
        {
            var time =TimeWatcher.Watch(
                () =>
                {
                    Thread.Sleep(1000);
                });

            Assert.IsNotNull(time);
            Console.WriteLine(time);
        }

        /// <summary>
        /// 测试WatchApart方法。
        /// </summary>
        [TestMethod()]
        public void WatchApartTest()
        {
            var times = TimeWatcher.WatchApart(
                () =>
                {
                    Thread.Sleep(1000);
                },
                () =>
                {
                    Thread.Sleep(1000);
                });

            Assert.IsNotNull(times);
            foreach (var time in times)
            {
                Console.WriteLine(time);
            }
        }

        /// <summary>
        /// 测试WatchAround方法。
        /// </summary>
        [TestMethod()]
        public void WatchAroundTest()
        {
            var times = TimeWatcher.WatchAround(
                () =>
                {
                    Thread.Sleep(1000);
                },
                () =>
                {
                    Thread.Sleep(1000);
                });

            Assert.IsNotNull(times);
            foreach (var time in times)
            {
                Console.WriteLine(time);
            }
        }
    }
}

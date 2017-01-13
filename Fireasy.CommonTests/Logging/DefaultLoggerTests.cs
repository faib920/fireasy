// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fireasy.Common.Logging;

namespace Fireasy.Common.Logging.Test
{
    /// <summary>
    /// DefaultLoggerTests类。
    /// </summary>
    [TestClass()]
    public class DefaultLoggerTests
    {
        /// <summary>
        /// 测试并行下的Write方法。
        /// </summary>
        [TestMethod()]
        public void WriteForParallel()
        {
            Parallel.For(1, 100, i =>
                {
                    DefaultLogger.Instance.Info(string.Format("{0} -- 发生错误:{1}", i, "未知错误"));
                });
        }

        [TestMethod()]
        public void ErrorTest()
        {
            LoggerFactory.CreateLogger().Error("发生错误了，请检查");
        }

        [TestMethod()]
        public void InfoTest()
        {
            DefaultLogger.Instance.Info("工资已经计算完成");
        }

        [TestMethod()]
        public void WarnTest()
        {
            DefaultLogger.Instance.Warn("警告警告！");
        }

        [TestMethod()]
        public void DebugTest()
        {
            DefaultLogger.Instance.Debug("这是一个调试");
        }

        [TestMethod()]
        public void FatalTest()
        {
            DefaultLogger.Instance.Fatal("程序发生致命错误，将被销毁");
        }
    }
}

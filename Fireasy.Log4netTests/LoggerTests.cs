// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Fireasy.Common.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fireasy.Log4net;
using log4net;

namespace Fireasy.Log4net.Test
{
    [TestClass()]
    public class LoggerTests
    {

        [TestMethod()]
        public void ErrorTest()
        {
            var logger = LoggerFactory.CreateLogger("a1");
            logger.Error("发生错误了，请检查", new NotImplementedException("没有实现"));
        }

        [TestMethod()]
        public void InfoTest()
        {
            var logger = LoggerFactory.CreateLogger("a2");
            logger.Info("工资已经计算完成");
        }

        [TestMethod()]
        public void WarnTest()
        {
            var logger = LoggerFactory.CreateLogger();
            logger.Warn("警告警告！");
        }

        [TestMethod()]
        public void DebugTest()
        {
            var logger = LoggerFactory.CreateLogger();
            logger.Debug("这是一个调试");
        }

        [TestMethod()]
        public void FatalTest()
        {
            var logger = LoggerFactory.CreateLogger();
            logger.Fatal("程序发生致命错误，将被销毁");
        }
    }
}

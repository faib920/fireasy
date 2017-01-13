// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fireasy.Common.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Fireasy.Common.Logging.Test
{
    [TestClass()]
    public class LoggerFactoryTests
    {
        [TestMethod()]
        public void CreateLoggerTest()
        {
            var logManager = LoggerFactory.CreateLogger();
            Assert.IsNotNull(logManager);
        }

        [TestMethod()]
        public void CreateLoggerNoneTest()
        {
            var logManager = LoggerFactory.CreateLogger("none");
            Assert.IsNull(logManager);
        }

        [TestMethod()]
        public void CreateLoggerInnerTest()
        {
            var logManager = LoggerFactory.CreateLogger("inner");
            Assert.IsNotNull(logManager);
        }
    }

    internal class InnerLoggerManager : ILogger
    {
        private ILogger proxy = DefaultLogger.Instance;

        public void Error(object message, Exception exception = null)
        {
            proxy.Error(message, exception);
        }

        public void Info(object message, Exception exception = null)
        {
            proxy.Info(message, exception);
        }

        public void Warn(object message, Exception exception = null)
        {
            proxy.Warn(message, exception);
        }

        public void Debug(object message, Exception exception = null)
        {
            proxy.Debug(message, exception);
        }

        public void Fatal(object message, Exception exception = null)
        {
            proxy.Fatal(message, exception);
        }
    }
}

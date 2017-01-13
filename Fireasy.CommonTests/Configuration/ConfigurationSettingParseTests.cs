using Fireasy.Common.Caching.Configuration;
using Fireasy.Common.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fireasy.Common.Extensions;
using Fireasy.Common.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Configuration.Test
{
    [TestClass]
    public class ConfigurationSettingParseTests
    {
        [TestMethod]
        public void TestParseSetting()
        {
            var logger = LoggerFactory.CreateLogger();
            logger.Error("error", new NotImplementedException());
        }
    }

    [ConfigurationSectionStorage("fireasy/log")]
    public class LoggingConfigurationSection : ConfigurationSection
    {
        public override void Initialize(System.Xml.XmlNode section)
        {
        }
    }

    [ConfigurationSettingParseType(typeof(LoggingSettingParseHandler))]
    public class MyLoggingSetting : LoggingConfigurationSetting
    {
        public MyLoggingSetting()
        {
            Appenders = new List<LoggingAppender>();
        }

        /// <summary>
        /// 日志呈现器列表。
        /// </summary>
        public List<LoggingAppender> Appenders { get; set; }
    }

    /// <summary>
    /// 日志呈现的抽象类。
    /// </summary>
    public abstract class LoggingAppender
    {
        /// <summary>
        /// 日志写入的格式。
        /// </summary>
        public string Format { get; set; }
    }

    /// <summary>
    /// 呈现到文件。
    /// </summary>
    public class FileAppender : LoggingAppender
    {
        /// <summary>
        /// 目录。
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// 文件名。
        /// </summary>
        public string FileName { get; set; }
    }

    /// <summary>
    /// 呈现到数据库。
    /// </summary>
    public class DatabaseAppender : LoggingAppender
    {
        /// <summary>
        /// 提供者类型。
        /// </summary>
        public string ProviderType { get; set; }

        /// <summary>
        /// 连接字符串。
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 日志数据表。
        /// </summary>
        public string Table { get; set; }
    }

    public class LoggingSectionHandler : ConfigurationSectionHandler<LoggingConfigurationSection>
    {
    }

    [ConfigurationSetting(typeof(MyLoggingSetting))]
    public class MyLogger : ILogger, IConfigurationSettingHostService
    {
        private MyLoggingSetting setting;

        public void Error(object message, Exception exception = null)
        {
            WriteLog(message, exception);
        }

        public void Info(object message, Exception exception = null)
        {
            WriteLog(message, exception);
        }

        public void Warn(object message, Exception exception = null)
        {
            WriteLog(message, exception);
        }

        public void Debug(object message, Exception exception = null)
        {
            WriteLog(message, exception);
        }

        public void Fatal(object message, Exception exception = null)
        {
            WriteLog(message, exception);
        }

        /// <summary>
        /// 写日志。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exp"></param>
        private void WriteLog(object message, Exception exp)
        {
            foreach (var appender in setting.Appenders)
            {
                var writer = GetAppenderWriter(appender);
                if (writer != null)
                {
                    writer.WriteLog(message, exp);
                }
            }
        }

        /// <summary>
        /// 根据呈现配置获取相应的输出器。
        /// </summary>
        /// <param name="appender"></param>
        /// <returns></returns>
        private IAppenderWriter GetAppenderWriter(LoggingAppender appender)
        {
            if (appender is FileAppender)
            {
                return new FileAppenderWriter { Appender = (FileAppender)appender };
            }
            else if (appender is DatabaseAppender)
            {
                return new DatabaseAppenderWriter { Appender = (DatabaseAppender)appender };
            }

            return null;
        }

        void IConfigurationSettingHostService.Attach(IConfigurationSettingItem setting)
        {
            this.setting = (MyLoggingSetting)setting;
        }

        IConfigurationSettingItem IConfigurationSettingHostService.GetSetting()
        {
            return setting;
        }

    }

    /// <summary>
    /// 自定义的设置项解析类。
    /// </summary>
    public class LoggingSettingParseHandler : IConfigurationSettingParseHandler
    {
        public IConfigurationSettingItem Parse(System.Xml.XmlNode section)
        {
            //logger实现类的类型名称
            var cacheTypeName = section.GetAttributeValue("type");
            if (string.IsNullOrEmpty(cacheTypeName))
            {
                return null;
            }

            var setting = new MyLoggingSetting();
            setting.Name = section.GetAttributeValue("node");
            setting.LogType = Type.GetType(cacheTypeName);

            foreach (XmlNode node in section.ChildNodes)
            {
                var appender = ParseLoggingAppender(node);
                if (appender != null)
                {
                    setting.Appenders.Add(appender);
                }
            }

            return setting;
        }

        /// <summary>
        /// 解析呈现器。
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private LoggingAppender ParseLoggingAppender(XmlNode node)
        {
            switch (node.Name)
            {
                case "file":
                    return new FileAppender
                    {
                        Directory = node.GetAttributeValue("directiory"),
                        FileName = node.GetAttributeValue("fileName"),
                        Format = node.GetAttributeValue("format")
                    };
                case "database":
                    return new DatabaseAppender
                    {
                        ProviderType = node.GetAttributeValue("providerType"),
                        ConnectionString = node.GetAttributeValue("connectionString"),
                        Table = node.GetAttributeValue("table"),
                        Format = node.GetAttributeValue("format")
                    };
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// 呈现输出器接口。
    /// </summary>
    public interface IAppenderWriter
    {
        /// <summary>
        /// 写日志。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exp"></param>
        void WriteLog(object message, Exception exp);
    }

    /// <summary>
    /// 呈现输出器的抽象类。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppenderWriter<T> : IAppenderWriter
        where T : LoggingAppender
    {
        public T Appender { get; set; }

        public abstract void WriteLog(object message, Exception exp);
    }

    /// <summary>
    /// 基于文件的呈现输出器。
    /// </summary>
    public class FileAppenderWriter : AppenderWriter<FileAppender>
    {
        public override void WriteLog(object message, Exception exp)
        {
            Console.WriteLine(string.Format("写入到文件 {0}: {1}", Appender.FileName, message));
        }
    }

    /// <summary>
    /// 基于数据库的呈现输出器。
    /// </summary>
    public class DatabaseAppenderWriter : AppenderWriter<DatabaseAppender>
    {
        public override void WriteLog(object message, Exception exp)
        {
            Console.WriteLine(string.Format("写入到数据库 {0} 表中: {1}", Appender.Table, message));
        }
    }
}

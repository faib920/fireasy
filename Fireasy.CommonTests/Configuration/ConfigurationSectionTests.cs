using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fireasy.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Configuration.Test
{

    [TestClass]
    public class ConfigurationSectionTests
    {
        [TestMethod]
        public void Test1()
        {
            var s = ConfigurationUnity.GetSection<Test1ConfigurationSection>();
            Console.WriteLine(s.Server);
        }

        [TestMethod]
        public void Test2()
        {
            var s = ConfigurationUnity.GetSection<Test2ConfigurationSection>();
            Console.WriteLine(s.Settings["a1"].Method);
        }
    }


    [ConfigurationSectionStorage("fireasy/test1")]
    public sealed class Test1ConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// 使用配置节点对当前配置进行初始化。
        /// </summary>
        /// <param name="section">对应的配置节点。</param>
        public override void Initialize(XmlNode section)
        {
            Server = section.GetAttributeValue("server");
            Port = section.GetAttributeValue<int>("port");
        }

        public string Server { get; set; }

        public int Port { get; set; }
    }

    public class Test1ConfigurationSectionHandler : ConfigurationSectionHandler<Test1ConfigurationSection>
    {
    }

    [ConfigurationSectionStorage("fireasy/test2")]
    public sealed class Test2ConfigurationSection : ConfigurationSection<Test2ConfigurationSetting>
    {
        /// <summary>
        /// 使用配置节点对当前配置进行初始化。
        /// </summary>
        /// <param name="section">对应的配置节点。</param>
        public override void Initialize(XmlNode section)
        {
            foreach (XmlNode node in section.SelectNodes("nd"))
            {
                var name = node.GetAttributeValue("name");
                var setting = new Test2ConfigurationSetting
                {
                    Name = name,
                    Method = node.GetAttributeValue("method")
                };

                Settings.Add(name, setting);
            }
        }
    }

    public class Test2ConfigurationSetting : IConfigurationSettingItem
    {
        /// <summary>
        /// 获取或设置配置名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置方法。
        /// </summary>
        public string Method { get; set; }
    }

    public class Test2ConfigurationSectionHandler : ConfigurationSectionHandler<Test2ConfigurationSection>
    {
    }

}

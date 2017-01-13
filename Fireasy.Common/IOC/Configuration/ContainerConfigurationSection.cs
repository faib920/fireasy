// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;

namespace Fireasy.Common.Ioc.Configuration
{
    /// <summary>
    /// 表示容器的配置节。无法继承此类。
    /// </summary>
    [ConfigurationSectionStorage("fireasy/containers")]
    public sealed class ContainerConfigurationSection : ConfigurationSection<ContainerConfigurationSetting>
    {
        private string defaultInstanceName;

        /// <summary>
        /// 使用配置节点对当前配置进行初始化。
        /// </summary>
        /// <param name="section">对应的配置节点。</param>
        public override void Initialize(XmlNode section)
        {
            InitializeNode(
                section,
                "container",
                null,
                node => InitializeSetting(new ContainerConfigurationSetting
                    {
                        Name = node.GetAttributeValue("name")
                    }, node));
            
            //取默认实例
            defaultInstanceName = section.GetAttributeValue("default");

            base.Initialize(section);
        }

        /// <summary>
        /// 获取默认的配置项。
        /// </summary>
        public ContainerConfigurationSetting Default
        {
            get { return string.IsNullOrEmpty(defaultInstanceName) ? Settings["setting0"] : Settings[defaultInstanceName]; }
        }

        private ContainerConfigurationSetting InitializeSetting(ContainerConfigurationSetting setting, XmlNode node)
        {
            var list = new List<RegistrationSetting>();
            foreach (XmlNode child in node.SelectNodes("registration"))
            {
                var serviceType = child.GetAttributeValue("serviceType");
                var componentType = child.GetAttributeValue("componentType");

                if (string.IsNullOrEmpty(serviceType) ||
                    string.IsNullOrEmpty(componentType))
                {
                    continue;
                }

                list.Add(new RegistrationSetting
                    {
                        ServiceType = serviceType.ParseType(),
                        ComponentType = componentType.ParseType()
                    });
            }

            setting.Registrations = list.ToReadOnly();
            return setting;
        }
    }
}

﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using Fireasy.Common.Caching;
using Fireasy.Common.Extensions;

namespace Fireasy.Common.Configuration
{
    /// <summary>
    /// 应用程序配置的管理单元。
    /// </summary>
    public static class ConfigurationUnity
    {
        private const string CUSTOM_CONFIG_NAME = "my-config-file";

        /// <summary>
        /// 获取配置节实例。
        /// </summary>
        /// <typeparam name="T">配置节的类型。</typeparam>
        /// <returns></returns>
        public static T GetSection<T>() where T : IConfigurationSection
        {
            var attribute = typeof(T).GetCustomAttributes<ConfigurationSectionStorageAttribute>().FirstOrDefault();
            if (attribute == null)
            {
                return default(T);
            }

            return (T)GetSection(attribute.Name);
        }

        /// <summary>
        /// 为具有 <see cref="IConfigurationSettingHostService"/> 接口的对象附加相应的配置对象。
        /// </summary>
        /// <param name="hostService"></param>
        /// <param name="setting"></param>
        public static void AttachSetting(IConfigurationSettingHostService hostService, IConfigurationSettingItem setting)
        {
            if (hostService != null)
            {
                hostService.Attach(setting);
            }
        }

        private static IConfigurationSection GetSection(string sectionName)
        {
            var cacheMgr = MemoryCacheManager.Instance;

            //使用appSetting名称为FireasyConfigFileName放置自定义配置文件
            var configFileName = ConfigurationManager.AppSettings[CUSTOM_CONFIG_NAME];
            if (string.IsNullOrEmpty(configFileName))
            {
                return cacheMgr.TryGet(sectionName, () => ConfigurationManager.GetSection(sectionName) as IConfigurationSection);
            }

            configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFileName);
            return cacheMgr.TryGet(sectionName, () => GetCustomConfiguration(sectionName, configFileName), () => new FileDependency(configFileName));
        }

        /// <summary>
        /// 从自定义配置文件中读取相应的配置。
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        private static IConfigurationSection GetCustomConfiguration(string sectionName, string configFileName)
        {
            var config = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap { ExeConfigFilename = configFileName },
                ConfigurationUserLevel.None);
            var section = config.GetSection(sectionName);
            return ReadSection(sectionName, section);
        }

        private static IConfigurationSection ReadSection(string sectionName, System.Configuration.ConfigurationSection section)
        {
            if (section == null)
            {
                return null;
            }

            var handlerType = Type.GetType(section.SectionInformation.Type, false);
            if (handlerType == null)
            {
                throw new ConfigurationErrorsException(SR.GetString(SRKind.UnableReadConfiguration, sectionName),
                    new TypeLoadException(section.SectionInformation.Type, null));
            }

            var handler = handlerType.New<IConfigurationSectionHandler>();
            var doc = new XmlDocument();
            var xml = section.SectionInformation.GetRawXml();
            try
            {
                doc.LoadXml(xml);
                return handler.Create(null, null, doc.ChildNodes[0]) as IConfigurationSection;
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(SR.GetString(SRKind.UnableReadConfiguration, sectionName), ex);
            }
        }
    }
}

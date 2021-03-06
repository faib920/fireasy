﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;
using Fireasy.Data.Provider;

namespace Fireasy.Data.Configuration
{
    /// <summary>
    /// 一个提供数据库字符串配置的类，使用XML文件进行配置。
    /// </summary>
    [Serializable]
    public sealed class XmlInstanceSetting : IInstanceConfigurationSetting
    {
        /// <summary>
        /// 返回提供者配置名称。
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 获取实例名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 返回数据库类型。
        /// </summary>
        public string ProviderType { get; set; }

        /// <summary>
        /// 返回数据库类型。
        /// </summary>
        public Type DatabaseType { get; set; }

        /// <summary>
        /// 返回数据库连接字符串。
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 返回Xml文件名称。
        /// </summary>
        public string FileName { get; set; }

        internal class SettingParseHandler : IConfigurationSettingParseHandler
        {
            public IConfigurationSettingItem Parse(XmlNode node)
            {
                var setting = new XmlInstanceSetting();
                setting.Name = node.GetAttributeValue("name");
                var file = node.GetAttributeValue("fileName");
                DbUtility.ParseDataDirectory(ref file);
                setting.FileName = file;
                if (!File.Exists(setting.FileName))
                {
                    throw new FileNotFoundException(SR.GetString(SRKind.FileNotFound, setting.FileName), setting.FileName);
                }

                var xpath = node.GetAttributeValue("xmlPath");

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(setting.FileName);
                var connNode = xmlDoc.SelectSingleNode(xpath);
                if (connNode == null)
                {
                    throw new XPathException(xpath);
                }

                setting.ProviderName = connNode.GetAttributeValue("providerName");
                setting.ProviderType = connNode.GetAttributeValue("providerType");
                setting.DatabaseType = Type.GetType(connNode.GetAttributeValue("databaseType"), false, true);
                setting.ConnectionString = ConnectionStringHelper.GetConnectionString(connNode.GetAttributeValue("connectionString"));

                return setting;
            }
        }
    }
}

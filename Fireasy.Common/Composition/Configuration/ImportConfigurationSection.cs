﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Xml;
using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;

namespace Fireasy.Common.Composition.Configuration
{
    /// <summary>
    /// 表示 MEF 的导入配置节。
    /// </summary>
    [ConfigurationSectionStorage("fireasy/imports")]
    public sealed class ImportConfigurationSection : ConfigurationSection<ImportConfigurationSetting>
    {
        /// <summary>
        /// 使用配置节点对当前配置进行初始化。
        /// </summary>
        /// <param name="section">对应的配置节点。</param>
        public override void Initialize(XmlNode section)
        {
            InitializeNode(
                section, 
                "import", 
                null, 
                node => 
                new ImportConfigurationSetting
                    {
                        Assembly = node.GetAttributeValue("assembly"),
                        ContractType = Type.GetType(node.GetAttributeValue("contractType"), false, true),
                        ImportType = Type.GetType(node.GetAttributeValue("importType"), false, true)
                    });
        }
    }
}

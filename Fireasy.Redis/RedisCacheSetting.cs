﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Caching.Configuration;
using Fireasy.Common.Configuration;
using System;
using System.Collections.Generic;

namespace Fireasy.Redis
{
    /// <summary>
    /// Redis 的基本配置。
    /// </summary>
    [ConfigurationSettingParseType(typeof(RedisCacheSettingParser))]
    public class RedisCacheSetting : CachingConfigurationSetting
    {
        public RedisCacheSetting()
        {
            Hosts = new List<RedisCacheHost>();
        }

        /// <summary>
        /// 获取 Redis 主机群。
        /// </summary>
        public List<RedisCacheHost> Hosts { get; private set; }

        /// <summary>
        /// 获取或设置最大读连接数。
        /// </summary>
        public int MaxReadPoolSize { get; set; }

        /// <summary>
        /// 获取或设置最大写连接数。
        /// </summary>
        public int MaxWritePoolSize { get; set; }

        /// <summary>
        /// 获取或设置缺省的数据库编号。
        /// </summary>
        public int DefaultDb { get; set; }

        /// <summary>
        /// 获取或设置对象序列化器的类型。
        /// </summary>
        public Type SerializerType { get; set; }
    }

    /// <summary>
    /// Redis 主机配置。
    /// </summary>
    public class RedisCacheHost
    {
        /// <summary>
        /// 获取或设置主机IP。
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// 获取或设置密码。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取是否只读。
        /// </summary>
        public bool ReadOnly { get; set; }
    }
}

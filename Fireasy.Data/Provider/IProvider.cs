﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.Common;

namespace Fireasy.Data.Provider
{
    /// <summary>
    /// 为不同的数据库类型提供创建工厂及插件服务。
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// 获取描述数据库的名称。
        /// </summary>
        string DbName { get; }

        /// <summary>
        /// 获取数据库提供者工厂。
        /// </summary>
        DbProviderFactory DbProviderFactory { get; }

        /// <summary>
        /// 获取当前连接的参数。
        /// </summary>
        /// <param name="connectionString">连接字符串对象。</param>
        /// <returns>连接字符串参数对象。</returns>
        ConnectionParameter GetConnectionParameter(ConnectionString connectionString);

        /// <summary>
        /// 使用参数更新指定的连接。
        /// </summary>
        /// <param name="connectionString">连接字符串对象。</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        string UpdateConnectionString(ConnectionString connectionString, ConnectionParameter parameter);

        /// <summary>
        /// 获取注册到数据库提供者的插件服务实例。
        /// </summary>
        /// <typeparam name="TProvider">插件服务的类型。</typeparam>
        /// <returns></returns>
        TProvider GetService<TProvider>() where TProvider : class, IProviderService;

        /// <summary>
        /// 获取注册到数据库提供者的所有插件服务。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProviderService> GetServices();
    }
}

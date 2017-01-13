// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Common;
using Fireasy.Data.Extensions;
using System.Text.RegularExpressions;

namespace Fireasy.Data.Provider
{
    /// <summary>
    /// 基本的数据库提供者。
    /// </summary>
    public abstract class ProviderBase : IProvider
    {
        /// <summary>
        /// 表示 <see cref="DbProviderFactory"/> 对象。
        /// </summary>
        protected DbProviderFactory Factory;
        private readonly string providerName;

        /// <summary>
        /// 初始化 <see cref="ProviderBase"/> 类的新实例。
        /// </summary>
        protected ProviderBase()
        {
        }

        /// <summary>
        /// 使用提供者名称初始化 <see cref="ProviderBase"/> 类的新实例。
        /// </summary>
        /// <param name="providerName"></param>
        protected ProviderBase(string providerName)
        {
            this.providerName = providerName;
        }

        public abstract string DbName { get; }

        /// <summary>
        /// 获取数据库提供者工厂。
        /// </summary>
        public virtual DbProviderFactory DbProviderFactory
        {
            get
            {
                if (Factory == null)
                {
                    Factory = DbProviderFactories.GetFactory(providerName);
                    if (Factory == null)
                    {
                        throw new NotSupportedException(SR.GetString(SRKind.StandardDbPfNull));
                    }
                }

                return Factory;
            }
        }

        /// <summary>
        /// 获取当前连接的参数。
        /// </summary>
        /// <returns></returns>
        public abstract ConnectionParameter GetConnectionParameter(ConnectionString connectionString);

        /// <summary>
        /// 使用参数更新指定的连接。
        /// </summary>
        /// <param name="connectionString">连接字符串对象。</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract string UpdateConnectionString(ConnectionString connectionString, ConnectionParameter parameter);

        /// <summary>
        /// 获取注册到数据库提供者的插件服务实例。
        /// </summary>
        /// <typeparam name="TProvider">插件服务的类型。</typeparam>
        /// <returns></returns>
        public virtual TProvider GetService<TProvider>() where TProvider : class, IProviderService
        {
            return ProviderExtension.GetService<TProvider>(this);
        }

        /// <summary>
        /// 获取注册到数据库提供者的所有插件服务。
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<IProviderService> GetServices()
        {
            return ProviderExtension.GetServices(this);
        }
    }
}

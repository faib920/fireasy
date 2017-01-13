// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Fireasy.Common;
using Fireasy.Common.Extensions;
using Fireasy.Common.Ioc;
using Fireasy.Data.Provider;
using Fireasy.Data.Syntax;

namespace Fireasy.Data.Extensions
{
    /// <summary>
    /// 数据库提供者的扩展方法。
    /// </summary>
    public static class ProviderExtension
    {
        /// <summary>
        /// 创建一个新的 <see cref="DbConnection"/> 对象。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="connectionString">数据库连接字符串。</param>
        /// <returns></returns>
        public static DbConnection CreateConnection(this IProvider provider, string connectionString)
        {
            Guard.ArgumentNull(provider, "provider");
            Guard.NullReference(provider.DbProviderFactory);

            var connection = provider.DbProviderFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        /// <summary>
        /// 创建一个新的 <see cref="DbCommand"/> 对象。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DbCommand CreateCommand(this IProvider provider, DbConnection connection, DbTransaction transaction, string commandText, CommandType commandType = CommandType.Text, IEnumerable<Parameter> parameters = null)
        {
            Guard.ArgumentNull(provider, "provider");
            Guard.NullReference(provider.DbProviderFactory);

            var syntax = provider.GetService<ISyntaxProvider>();

            var command = provider.DbProviderFactory.CreateCommand();
            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandText = commandText;
            command.Transaction = transaction;

            if (parameters != null)
            {
                command.PrepareParameters(provider, parameters);
            }
            return command;
        }

        /// <summary>
        /// 创建一个新的 <see cref="DbParameter"/> 对象。
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DbParameter CreateParameter(this IProvider provider, string parameterName, object value)
        {
            Guard.ArgumentNull(provider, "provider");
            Guard.NullReference(provider.DbProviderFactory);

            var parameter = provider.DbProviderFactory.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            return parameter;
        }

        /// <summary>
        /// 为数据库提供者注册一个插件服务。
        /// </summary>
        /// <typeparam name="TProvider">插件服务的类型。</typeparam>
        /// <typeparam name="TService">插件的实现类型。</typeparam>
        /// <param name="provider">数据库提供者对象。</param>
        /// <param name="category">类别标识。</param>
        /// <returns></returns>
        public static IProvider RegisterService<TProvider, TService>(this IProvider provider, string category = null)
            where TProvider : class, IProviderService
            where TService : class, TProvider
        {
            return RegisterService(provider, typeof(TProvider), typeof(TService), category);
        }

        /// <summary>
        /// 为数据库提供者注册一个插件服务。
        /// </summary>
        /// <param name="provider">数据库提供者对象。</param>
        /// <param name="serviceType">插件的实现类型。</param>
        /// <param name="category">类别标识。</param>
        /// <returns></returns>
        public static IProvider RegisterService(this IProvider provider, Type serviceType, string category = null)
        {
            var providerService = serviceType.GetDirectImplementInterface(typeof(IProviderService));
            return RegisterService(provider, providerService, serviceType, category);
        }

        /// <summary>
        /// 为数据库提供者注册一个插件服务。
        /// </summary>
        /// <param name="provider">数据库提供者对象。</param>
        /// <param name="providerService">插件服务的类型。</param>
        /// <param name="serviceType">插件的实现类型。</param>
        /// <param name="category">类别标识。</param>
        /// <returns></returns>
        public static IProvider RegisterService(this IProvider provider, Type providerService, Type serviceType, string category = null)
        {
            Guard.ArgumentNull(provider, "provider");
            Guard.ArgumentNull(providerService, "providerService");
            Guard.ArgumentNull(serviceType, "serviceType");

            var key = string.Concat(provider.GetType().FullName, category);
            var container = ContainerUnity.GetContainer(key);
            container.RegisterSingleton(providerService, () => serviceType.New());
            return provider;
        }

        /// <summary>
        /// 获取注册到数据库提供者的插件服务实例。
        /// </summary>
        /// <typeparam name="TProvider">插件服务的类型。</typeparam>
        /// <param name="provider">数据库提供者对象。</param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static TProvider GetService<TProvider>(this IProvider provider, string category = null)
            where TProvider : class, IProviderService
        {
            Guard.ArgumentNull(provider, "provider");

            var key = string.Concat(provider.GetType().FullName, category);
            var container = ContainerUnity.GetContainer(key);
            var instance = container.Resolve<TProvider>();
            if (instance == null)
            {
                key = provider.GetType().FullName;
                container = ContainerUnity.GetContainer(key);
                instance = container.Resolve<TProvider>();
            }

            return instance;
        }

        /// <summary>
        /// 获取注册到数据库提供者的所有插件服务。
        /// </summary>
        /// <param name="provider">数据库提供者对象。</param>
        /// <returns></returns>
        public static IEnumerable<IProviderService> GetServices(this IProvider provider)
        {
            Guard.ArgumentNull(provider, "provider");

            var key = provider.GetType().FullName;
            var container = ContainerUnity.GetContainer(key);
            return container.GetRegistrations()
                .Select(registration => registration.Resolve().As<IProviderService>())
                .Where(service => service != null);
        }
    }
}
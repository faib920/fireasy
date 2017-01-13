// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using Fireasy.Common;
using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;
using Fireasy.Data.Extensions;
using Fireasy.Data.Provider.Configuration;

namespace Fireasy.Data.Provider
{
    /// <summary>
    /// <see cref="IProvider"/> 的辅助类。
    /// </summary>
    public static class ProviderHelper
    {
        private static readonly ConcurrentDictionary<string, IProvider> dicProviders = new ConcurrentDictionary<string, IProvider>();

        static ProviderHelper()
        {
            dicProviders.TryAdd("OleDb", OleDbProvider.Instance);
            dicProviders.TryAdd("Odbc", OdbcProvider.Instance);
            dicProviders.TryAdd("MsSql", MsSqlProvider.Instance);
            dicProviders.TryAdd("Oracle", OracleProvider.Instance);
            dicProviders.TryAdd("SQLite", SQLiteProvider.Instance);
            dicProviders.TryAdd("MySql", MySqlProvider.Instance);
            dicProviders.TryAdd("PostgreSql", PostgreSqlProvider.Instance);
            dicProviders.TryAdd("Firebird", FirebirdProvider.Instance);

            var section = ConfigurationUnity.GetSection<ProviderConfigurationSection>();
            if (section != null)
            {
                RegisterCustomProviders(section);
            }
        }

        /// <summary>
        /// 根据 <paramref name="providerName"/> 获取预定的 <see cref="IProvider"/> 对象。
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static IProvider GetDefinedProviderInstance(string providerName)
        {
            var provider = dicProviders.FirstOrDefault(s => s.Key.Equals(providerName, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(provider.Key))
            {
                return provider.Value;
            }

            return null;
        }

        /// <summary>
        /// 使用代码注册一个 <see cref="IProvider"/> 对象。
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static bool RegisterProvider(string providerName, IProvider provider)
        {
            return dicProviders.TryAdd(providerName, provider);
        }

        /// <summary>
        /// 获取所提供的所有数据库提供者名称。
        /// </summary>
        /// <returns></returns>
        public static string[] GetSupportedProviders()
        {
            return dicProviders.Select(s => s.Key).ToArray();
        }

        private static void RegisterCustomProviders(ProviderConfigurationSection section)
        {
            foreach (var key in section.Settings.Keys)
            {
                var setting = section.Settings[key];
                if (dicProviders.ContainsKey(setting.Name))
                {
                    continue;
                }

                var provider = setting.Type.New<IProvider>();
                if (provider == null)
                {
                    continue;
                }

                foreach (var type in setting.ServiceTypes)
                {
                    provider.RegisterService(type);
                }

                dicProviders.TryAdd(setting.Name, provider);
            }
        }
    }
}

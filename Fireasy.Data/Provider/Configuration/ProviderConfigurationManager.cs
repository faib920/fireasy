// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Configuration;

namespace Fireasy.Data.Provider.Configuration
{
    public sealed class ProviderConfigurationManager
    {
        private static ProviderConfiguration _configuration = null;
        private static object m_locker = new object();

        /// <summary>
        /// 实例化，初始载入实例配置。
        /// </summary>
        static ProviderConfigurationManager()
        {
            if (_configuration == null)
            {
                Reload();
            }
        }

        /// <summary>
        /// 返回当前应用程序的数据库实例集。
        /// </summary>
        public static ConfigurationSettings<ProviderSetting> Settings
        {
            get
            {
                return _configuration == null ? new ConfigurationSettings<ProviderSetting>() : _configuration.Settings;
            }
        }

        /// <summary>
        /// 重新加载配置节 fireasy/dataProviders。
        /// </summary>
        public static void Reload()
        {
            lock (m_locker)
            {
                _configuration = ConfigurationUnity.Load<ProviderSetting>("fireasy/dataProviders") as ProviderConfiguration;
            }
        }


    }
}

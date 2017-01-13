using Fireasy.Common;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Caching;
using Fireasy.Common.Configuration;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using Fireasy.Common.Extensions;

namespace Fireasy.Redis
{
    /// <summary>
    /// 基于 Redis 的缓存管理器。
    /// </summary>
    [ConfigurationSetting(typeof(RedisCacheSetting))]
    public class RedisCacheManager : ICacheManager, IConfigurationSettingHostService
    {
        private ObjectSerializer serializer;
        private PooledRedisClientManager manager;
        private RedisCacheSetting setting;
        private static ReadWriteLocker locker = new ReadWriteLocker();

        /// <summary>
        /// 将对象插入到缓存管理器中。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <param name="value">要插入到缓存的对象。</param>
        /// <param name="expire">对象存放于缓存中的有效时间，到期后将从缓存中移除。如果此值为 null，则默认有效时间为 30 分钟。</param>
        /// <param name="removeCallback">当对象从缓存中移除时，使用该回调方法通知应用程序。</param>
        public T Add<T>(string cacheKey, T value, System.TimeSpan? expire = null, CacheItemRemovedCallback removeCallback = null)
        {
            try
            {
                using (var client = manager.GetClient())
                {
                    if (expire == null)
                    {
                        client.Set<T>(cacheKey, value);
                    }
                    else
                    {
                        client.Set<T>(cacheKey, value, DateTime.Now + (TimeSpan)expire);
                    }
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("无法完成缓存操作。", exp);
            }

            return value;
        }

        /// <summary>
        /// 将对象插入到缓存管理器中。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <param name="value">要插入到缓存的对象。</param>
        /// <param name="expiration">判断对象过期的对象。</param>
        /// <param name="removeCallback">当对象从缓存中移除时，使用该回调方法通知应用程序。</param>
        public T Add<T>(string cacheKey, T value, ICacheItemExpiration expiration, CacheItemRemovedCallback removeCallback = null)
        {
            try
            {
                using (var client = manager.GetClient())
                {
                    client.Set<T>(cacheKey, value);
                    return value;
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("无法完成缓存操作。", exp);
            }
        }

        /// <summary>
        /// 确定缓存中是否包含指定的缓存键的对象。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <returns>如果缓存中包含指定缓存键的对象，则为 true，否则为 false。</returns>
        public bool Contains<T>(string cacheKey)
        {
            using (var client = manager.GetClient())
            {
                return client.As<T>().ContainsKey(cacheKey);
            }
        }

        /// <summary>
        /// 获取缓存中指定缓存键的对象。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <returns>检索到的缓存对象，未找到时为 null。</returns>
        public T Get<T>(string cacheKey)
        {
            using (var client = manager.GetClient())
            {
                return client.As<T>().GetValue(cacheKey);
            }
        }

        /// <summary>
        /// 尝试获取指定缓存键的对象，如果没有则使用工厂函数添加对象到缓存中。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <param name="factory">用于添加缓存对象的工厂函数。</param>
        /// <param name="expiration">判断对象过期的对象。</param>
        /// <returns></returns>
        public T TryGet<T>(string cacheKey, System.Func<T> factory, System.Func<ICacheItemExpiration> expiration = null)
        {
            try
            {
                using (var client = manager.GetClient())
                {
                    var set = client.As<T>();

                    T value = default(T);
                    locker.LockRead(() =>
                        {
                            if (!set.ContainsKey(cacheKey))
                            {
                                if (factory != null)
                                {
                                    locker.LockWrite(() =>
                                        {
                                            value = factory();
                                            DateTime? time = null;

                                            if (expiration != null)
                                            {
                                                var relative = expiration() as RelativeTime;
                                                if (relative != null)
                                                {
                                                    time = DateTime.Now + relative.Expiration;
                                                }
                                            }

                                            if (time == null)
                                            {
                                                client.Set<T>(cacheKey, value);
                                            }
                                            else
                                            {
                                                client.Set<T>(cacheKey, value, time.Value);
                                            }
                                        });
                                }
                            }
                            else
                            {
                                value = set.GetValue(cacheKey);
                            }
                        });

                    return value;
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("无法完成缓存操作。", exp);
            }
        }

        /// <summary>
        /// 尝试获取指定缓存键的对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGet<T>(string cacheKey, out T value)
        {
            using (var client = manager.GetClient())
            {
                var set = client.As<T>();

                if (!set.ContainsKey(cacheKey))
                {
                    value = default(T);
                    return false;
                }
                else
                {
                    value = set.GetValue(cacheKey);
                    return true;
                }
            }
        }

        /// <summary>
        /// 从缓存中移除指定缓存键的对象。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        public void Remove<T>(string cacheKey)
        {
            using (var client = manager.GetClient())
            {
                client.Remove(cacheKey);
            }
        }

        /// <summary>
        /// 清除指定类型下的所有缓存。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        public void Clear<T>()
        {
            using (var client = manager.GetClient())
            {
                var set = client.As<T>();
                set.DeleteAll();
            }
        }

        /// <summary>
        /// 清除所有缓存。
        /// </summary>
        public void ClearAll()
        {
            using (var client = manager.GetClient())
            {
                client.FlushAll();
            }
        }

        void IConfigurationSettingHostService.Attach(IConfigurationSettingItem setting)
        {
            this.setting = (RedisCacheSetting)setting;
            if (this.setting.SerializerType != null)
            {
                serializer = this.setting.SerializerType.New<ObjectSerializer>();
            }
            else
            {
                serializer = new ObjectSerializer();
            }

            var hosts = new List<string>();
            var readHosts = new List<string>();
            foreach (var h in this.setting.Hosts)
            {
                var address = h.EndPoint;
                if (!string.IsNullOrEmpty(h.Password))
                {
                    address = h.Password + "@" + address;
                }

                hosts.Add(address);
                if (h.ReadOnly)
                {
                    readHosts.Add(address);
                }
            }

            manager = new PooledRedisClientManager(hosts.ToArray(), readHosts.ToArray(), new RedisClientManagerConfig
                {
                    MaxReadPoolSize = this.setting.MaxReadPoolSize,
                    MaxWritePoolSize = this.setting.MaxWritePoolSize,
                    DefaultDb = this.setting.DefaultDb
                });
        }

        IConfigurationSettingItem IConfigurationSettingHostService.GetSetting()
        {
            return setting;
        }
    }
}

// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Common.Extensions;
using System;
using System.Collections.Concurrent;

namespace Fireasy.Common.Caching
{
    /// <summary>
    /// 基于内存的缓存管理。无法继承此类。
    /// </summary>
    public sealed class MemoryCacheManager : ICacheManager, ICacheItemEnumerator, IDisposable
    {
        //private readonly CacheController controller;
        private bool isDisposed;

        /// <summary>
        /// 获取 <see cref="MemoryCacheManager"/> 的静态实例。
        /// </summary>
        public readonly static MemoryCacheManager Instance = new MemoryCacheManager();

        private readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, CacheItem>> cacheDictionary = 
            new ConcurrentDictionary<Type, ConcurrentDictionary<string, CacheItem>>();

        /// <summary>
        /// 初始化 <see cref="MemoryCacheManager"/> 类的新实例。
        /// </summary>
        public MemoryCacheManager()
        {
            //controller = new CacheController(this);
        }

        /// <summary>
        /// 将对象插入到缓存管理器中。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <param name="value">要插入到缓存的对象。</param>
        /// <param name="expire">对象存放于缓存中的有效时间，到期后将从缓存中移除。如果此值为 null，则默认有效时间为 30 分钟。</param>
        /// <param name="removeCallback">当对象从缓存中移除时，使用该回调方法通知应用程序。</param>
        public T Add<T>(string cacheKey, T value, TimeSpan? expire = null, CacheItemRemovedCallback removeCallback = null)
        {
            var second = InitSecondDictionary<T>();
            var entry = new CacheItem(cacheKey, value, expire == null ? NeverExpired.Instance : new RelativeTime(expire.Value), removeCallback);
            second.AddOrUpdate(cacheKey, entry, (s,o) => entry);

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
            var second = InitSecondDictionary<T>();
            var entry = new CacheItem(cacheKey, value, expiration, removeCallback);
            second.AddOrUpdate(cacheKey, entry, (s, o) => entry);

            return value;
        }

        /// <summary>
        /// 确定缓存中是否包含指定的缓存键的对象。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <returns>如果缓存中包含指定缓存键的对象，则为 true，否则为 false。</returns>
        /// <exception cref="NotSupportedException">不支持该方法。</exception>
        public bool Contains<T>(string cacheKey)
        {
            var second = InitSecondDictionary<T>(true);
            if (second == null)
            {
                return false;
            }

            return second.ContainsKey(cacheKey);
        }

        /// <summary>
        /// 获取缓存中指定缓存键的对象。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <returns>检索到的缓存对象，未找到时为 null。</returns>
        /// <exception cref="NotSupportedException">不支持该方法。</exception>
        public T Get<T>(string cacheKey)
        {
            var second = InitSecondDictionary<T>(true);
            if (second == null)
            {
                return default(T);
            }

            CacheItem entry;
            if (second.TryGetValue(cacheKey, out entry))
            {
                if (entry.Expiration.HasExpired(entry))
                {
                    if (second.TryRemove(cacheKey, out entry))
                    {
                        NotifyCacheRemoved(entry);
                        return default(T);
                    }
                }

                return (T)entry.Value;
            }

            return default(T);
        }

        /// <summary>
        /// 尝试获取指定缓存键的对象，如果没有则使用工厂函数添加对象到缓存中。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <param name="factory">用于添加缓存对象的工厂函数。</param>
        /// <param name="expiration">判断对象过期的对象。</param>
        /// <returns></returns>
        public T TryGet<T>(string cacheKey, Func<T> factory, Func<ICacheItemExpiration> expiration = null)
        {
            var second = InitSecondDictionary<T>();
            CacheItem entry;
            var lazy = new Lazy<CacheItem>(() => CreateCacheItem(cacheKey, factory, expiration));

            if (second.TryGetValue(cacheKey, out entry))
            {
                //判断是否过期，移除后再添加
                if (entry.Expiration.HasExpired(entry))
                {
                    if (second.TryRemove(cacheKey, out entry))
                    {
                        NotifyCacheRemoved(entry);
                    }

                    entry = second.GetOrAdd(cacheKey, s => lazy.Value);
                }
            }
            else
            {
                entry = second.GetOrAdd(cacheKey, s => lazy.Value);
            }

            return (T)entry.Value;
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
            var second = InitSecondDictionary<T>(true);
            if (second == null)
            {
                value = default(T);
                return false;
            }

            CacheItem entry;
            if (second.TryGetValue(cacheKey, out entry))
            {
                //判断是否过期
                if (entry.Expiration.HasExpired(entry))
                {
                    if (second.TryRemove(cacheKey, out entry))
                    {
                        NotifyCacheRemoved(entry);
                        value = default(T);
                        return false;
                    }
                }

                value = (T)entry.Value;
                return true;
            }
            else
            {
                value = default(T);
                return false;
            }
        }

        /// <summary>
        /// 从缓存中移除指定缓存键的对象。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <exception cref="NotSupportedException">不支持该方法。</exception>
        public void Remove<T>(string cacheKey)
        {
            var second = InitSecondDictionary<T>(true);
            if (second != null)
            {
                CacheItem entry;
                if (second.TryRemove(cacheKey, out entry))
                {
                    NotifyCacheRemoved(entry);
                }
            }
        }

        /// <summary>
        /// 清除指定类型下的所有缓存。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <exception cref="NotSupportedException">不支持该方法。</exception>
        public void Clear<T>()
        {
            var second = InitSecondDictionary<T>(true);
            if (second != null)
            {
                second.Clear();
            }
        }

        /// <summary>
        /// 清除所有缓存。
        /// </summary>
        public void ClearAll()
        {
            cacheDictionary.Clear();
        }

        void ICacheItemEnumerator.Enumerate()
        {
        }

        /// <summary>
        /// 释放对象所占用的所有资源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// 释放对象所占用的非托管和托管资源。
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        private void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            //controller.Dispose();
            isDisposed = true;
        }

        private CacheItem CreateCacheItem<T>(string cacheKey, Func<T> factory, Func<ICacheItemExpiration> expiration)
        {
            return new CacheItem(
                cacheKey,
                factory(),
                expiration == null ? null : expiration(),
                null);
        }

        private ConcurrentDictionary<string, CacheItem> InitSecondDictionary<T>(bool noCreate = false)
        {
            if (noCreate && !cacheDictionary.ContainsKey(typeof(T)))
            {
                return null;
            }

            var lazy = new Lazy<ConcurrentDictionary<string, CacheItem>>(() => new ConcurrentDictionary<string, CacheItem>());
            return cacheDictionary.GetOrAdd(typeof(T), s => lazy.Value);
        }

        /// <summary>
        /// 通知缓存项已移除。
        /// </summary>
        /// <param name="entry"></param>
        private void NotifyCacheRemoved(CacheItem entry)
        {
            if (entry.NotifyRemoved != null)
            {
                entry.NotifyRemoved(entry.Key, entry.Value);
            }
        }
    }
}

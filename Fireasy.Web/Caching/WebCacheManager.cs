// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Web;
using System.Web.Caching;
using Fireasy.Common;
using Fireasy.Common.Caching;
using Fireasy.Common.Configuration;
using Fireasy.Common.Extensions;

namespace Fireasy.Web.Caching
{
    /// <summary>
    /// 基于 Asp.Net 应用程序的 <see cref="Cache"/> 对象的缓存管理。该管理器中的缓存数据在 Web 服务器环境改变时将被清空。无法继承此类。
    /// </summary>
    public sealed class WebCacheManager : ICacheManager
    {
        /// <summary>
        /// 获取 <see cref="WebCacheManager"/> 的静态实例。
        /// </summary>
        public readonly static WebCacheManager Instance = new WebCacheManager();

        private readonly Cache webCache;

        /// <summary>
        /// 初始化 <see cref="WebCacheManager"/> 类的新实例。
        /// </summary>
        public WebCacheManager()
        {
            webCache = HttpRuntime.Cache;
        }

        /// <summary>
        /// 将对象插入到缓存管理器中。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <param name="value">要插入到缓存的对象。</param>
        /// <param name="expire">对象存放于缓存中的有效时间，到期后将从缓存中移除。如果此值为 null，则默认有效时间为 30 分钟。</param>
        /// <param name="removeCallback">当对象从缓存中移除时，使用该回调方法通知应用程序。</param>
        public T Add<T>(string cacheKey, T value, TimeSpan? expire = null, Fireasy.Common.Caching.CacheItemRemovedCallback removeCallback = null)
        {
            var expireDate = DateTime.Now.Add(expire != null ? (TimeSpan)expire : TimeSpan.FromMinutes(30));
            webCache.Insert(
                cacheKey, 
                value, 
                null, 
                expireDate, 
                Cache.NoSlidingExpiration, 
                CacheItemPriority.Normal, 
                (k, v, r) =>
                    {
                        if (removeCallback != null)
                        {
                            removeCallback(k, v);
                        }
                    });
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
        public T Add<T>(string cacheKey, T value, ICacheItemExpiration expiration, Fireasy.Common.Caching.CacheItemRemovedCallback removeCallback = null)
        {
            if (expiration is FileDependency)
            {
                webCache.Insert(cacheKey, value, new CacheDependency((expiration as FileDependency).FilePath));
            }
            else
            {
                var expire = TimeSpan.Zero;
                if (expiration is NeverExpired)
                {
                    expire = Cache.NoSlidingExpiration;
                }
                else if (expiration is AbsoluteTime)
                {
                    expire = (expiration as AbsoluteTime).ExpirationTime - DateTime.Now;
                }
                else if (expiration is RelativeTime)
                {
                    expire = (expiration as RelativeTime).Expiration;
                }

                return Add(cacheKey, value, expire, removeCallback);
            }

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
            object value;
            if ((value = webCache[cacheKey]) != null)
            {
                if (value.GetType() == typeof(T))
                {
                    return true;
                }
            }

            return false;
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
            object value;
            if ((value = webCache[cacheKey]) != null)
            {
                if (value.GetType() == typeof(T))
                {
                    return (T)value;
                }
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
            Guard.ArgumentNull(factory, "factory");

            object value;
            if ((value = webCache[cacheKey]) != null)
            {
                if (value.GetType() == typeof(T))
                {
                    return (T)value;
                }
            }

            var item = factory();
            Add(cacheKey, item, expiration == null ? null : expiration());
            return item;
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
            var value1 = webCache[cacheKey];
            if (value1 == null || value1.GetType() == typeof(T))
            {
                value = default(T);
                return false;
            }

            value = (T)value1;
            return true;
        }

        /// <summary>
        /// 从缓存中移除指定缓存键的对象。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <param name="cacheKey">用于引用对象的缓存键。</param>
        /// <exception cref="NotSupportedException">不支持该方法。</exception>
        public void Remove<T>(string cacheKey)
        {
            if (Contains<T>(cacheKey))
            {
                webCache.Remove(cacheKey);
            }
        }

        /// <summary>
        /// 清除指定类型下的所有缓存。
        /// </summary>
        /// <typeparam name="T">缓存对象的类型。</typeparam>
        /// <exception cref="NotSupportedException">不支持该方法。</exception>
        public void Clear<T>()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 清除所有缓存。
        /// </summary>
        public void ClearAll()
        {
            throw new NotSupportedException();
        }
    }
}

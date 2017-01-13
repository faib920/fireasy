using Fireasy.Common.Configuration;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Caching.Test
{
    /// <summary>
    /// CacheManagerFactoryTests类。
    /// </summary>
    [TestClass()]
    public class CacheManagerFactoryTests
    {
        [TestMethod()]
        public void CreateManagerTest()
        {
            var cacheManager = CacheManagerFactory.CreateManager();
            Assert.IsNotNull(cacheManager);
        }

        [TestMethod()]
        public void CreateManagerNoneTest()
        {
            var cacheManager = CacheManagerFactory.CreateManager("none");
            Assert.IsNull(cacheManager);
        }

        [TestMethod()]
        public void CreateManagerInnerTest()
        {
            var cacheManager = CacheManagerFactory.CreateManager("inner");
            Assert.IsNotNull(cacheManager);
        }
    }

    internal class InnerCacheManager : ICacheManager
    {
        private ICacheManager proxy = MemoryCacheManager.Instance;

        public T Add<T>(string cacheKey, T value, System.TimeSpan? expire = null, CacheItemRemovedCallback removeCallback = null)
        {
            return proxy.Add(cacheKey, value, expire, removeCallback);
        }

        public T Add<T>(string cacheKey, T value, ICacheItemExpiration expiration, CacheItemRemovedCallback removeCallback = null)
        {
            return proxy.Add(cacheKey, value, expiration, removeCallback);
        }

        public bool Contains<T>(string cacheKey)
        {
            return proxy.Contains<T>(cacheKey);
        }

        public T Get<T>(string cacheKey)
        {
            return proxy.Get<T>(cacheKey);
        }

        public T TryGet<T>(string cacheKey, System.Func<T> factory, System.Func<ICacheItemExpiration> expiration = null)
        {
            return proxy.TryGet(cacheKey, factory, expiration);
        }

        public bool TryGet<T>(string cacheKey, out T value)
        {
            return proxy.TryGet(cacheKey, out value);
        }

        public void Remove<T>(string cacheKey)
        {
            proxy.Remove<T>(cacheKey);
        }

        public void Clear<T>()
        {
            proxy.Clear<T>();
        }

        public void ClearAll()
        {
            proxy.ClearAll();
        }

    }
}

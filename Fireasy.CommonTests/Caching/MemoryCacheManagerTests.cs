// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fireasy.Common.Caching.Test
{
    /// <summary>
    /// MemoryCacheManagerTests类。
    /// </summary>
    [TestClass()]
    public class MemoryCacheManagerTests
    {
        [TestMethod()]
        public void MemoryCacheManagerTest()
        {
            Assert.IsNotNull(MemoryCacheManager.Instance);
        }

        /// <summary>
        /// 测试Add方法。
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item);

            Thread.Sleep(1000);

            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        /// <summary>
        /// 测试使用时间间隔作为失效的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithTimeSpanTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, TimeSpan.FromSeconds(1));
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            Thread.Sleep(2000);

            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        /// <summary>
        /// 测试使用绝对时间作为失效的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithAbsoluteTimeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, new AbsoluteTime(DateTime.Now.AddSeconds(1)));
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            Thread.Sleep(2000);

            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        /// <summary>
        /// 测试使用相对时间作为失效的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithRelativeTimeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, new RelativeTime(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            //有效期是1秒，延时2秒后读取，缓存失效
            Thread.Sleep(2000);

            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        /// <summary>
        /// 测试使用文件依赖作为失效的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithFileDependencyTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dependency.txt");
            UpdaeFileDependency(fileName);

            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, new FileDependency(fileName));
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            Thread.Sleep(1000);

            //文件更改后，缓存失效
            UpdaeFileDependency(fileName);

            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        /// <summary>
        /// 测试只读取一次的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithOnceTimeTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, new OnceTime());
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            //第二次读取将失效
            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        /// <summary>
        /// 使用并行运算测试只读取一次的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithOnceTimeParallelTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, new OnceTime());

            var times = 0;

            Parallel.For(1, 100, i =>
                {
                    if (MemoryCacheManager.Instance.Get<CacheData>(key) != null)
                    {
                        times += 1;
                    }
                });

            Assert.AreEqual(1, times);
        }

        /// <summary>
        /// 测试使用相对时间进行延时的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithRelativeTimeDelayTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, TimeSpan.FromSeconds(2));

            //读取的时间不要超出有效时间，多次读取仍然有效
            Thread.Sleep(1500);
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            Thread.Sleep(1500);
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            Thread.Sleep(1500);
            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));

            Thread.Sleep(3000);
            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        /// <summary>
        /// 测试移除缓存通知的Add方法。
        /// </summary>
        [TestMethod()]
        public void AddWithRemoveCallback()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item, TimeSpan.FromSeconds(1), (k, value) =>
                {
                    Console.WriteLine("{0}被移除了", k);
                });

            Thread.Sleep(6000);

            MemoryCacheManager.Instance.Remove<CacheData>(key);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item);

            Assert.IsTrue(MemoryCacheManager.Instance.Contains<CacheData>(key));
            Assert.IsFalse(MemoryCacheManager.Instance.Contains<CacheData>(key + 1));
        }

        [TestMethod()]
        public void GetTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item);

            Assert.AreEqual(item, MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        [TestMethod()]
        public void TryGetTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item);

            CacheData d1, d2;
            Assert.IsTrue(MemoryCacheManager.Instance.TryGet(key, out d1));
            Assert.IsFalse(MemoryCacheManager.Instance.TryGet(key + 1, out d2));

            Assert.AreEqual(item, d1);
            Assert.IsNull(d2);
        }


        [TestMethod()]
        public void TryGetWithFuncTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item);

            var d1 = MemoryCacheManager.Instance.TryGet(key, () => new CacheData { Name = "李超" });
            var d2 = MemoryCacheManager.Instance.TryGet(key + 1, () => new CacheData { Name = "李超" });

            Assert.AreEqual(item, d1);
            Assert.AreNotEqual(item, d2);
        }

        [TestMethod()]
        public void TryGetWithFuncParallelTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;

            Parallel.For(0, 10, (i) =>
                {
                    var d = MemoryCacheManager.Instance.TryGet(key, () => new CacheData { Name = Guid.NewGuid().ToString() });
                    Assert.IsNotNull(d);
                    Console.WriteLine(d.Name);
                });
        }

        [TestMethod()]
        public void TryGetWithFuncExpireTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = MemoryCacheManager.Instance.TryGet(key, () => new CacheData { Name = "fireasy" }, () => new RelativeTime(TimeSpan.FromSeconds(1)));

            Assert.IsNotNull(MemoryCacheManager.Instance.Get<CacheData>(key));

            Thread.Sleep(2000);

            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item);
            Assert.IsNotNull(MemoryCacheManager.Instance.Get<CacheData>(key));

            MemoryCacheManager.Instance.Remove<CacheData>(key);

            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key));
        }

        [TestMethod()]
        public void ClearTest()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            var item = new CacheData { Name = "fireasy" };
            MemoryCacheManager.Instance.Add(key, item);
            MemoryCacheManager.Instance.Add(key + 1, item);

            MemoryCacheManager.Instance.Clear<CacheData>();

            Assert.IsNull(MemoryCacheManager.Instance.Get<CacheData>(key + 1));
        }

        [TestMethod()]
        public void DisposeTest()
        {
        }

        private void UpdaeFileDependency(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
            }
        }

        private class CacheData
        {
            public string Name { get; set; }
        }
    }
}

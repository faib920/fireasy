// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading;

namespace Fireasy.Common.Caching
{
    /// <summary>
    /// 缓存管理的控制器，用于定时扫描并移除过期的缓存项。无法继承此类。
    /// </summary>
    public sealed class CacheController : IDisposable
    {
        private readonly ICacheItemEnumerator enumerator;
        private Timer timer;

        /// <summary>
        /// 初始化 <see cref="CacheController"/> 类的新实例。
        /// </summary>
        /// <param name="cacheManager">缓存管理器。</param>
        public CacheController(ICacheManager cacheManager)
        {
            enumerator = cacheManager as ICacheItemEnumerator;
            if (enumerator != null)
            {
                InitTimer();
            }
        }

        /// <summary>
        /// 初始化定时器。
        /// </summary>
        private void InitTimer()
        {
            //1分钟进行一次扫描清理
            timer = new Timer(o => enumerator.Enumerate(), null, 1000 * 5, 1000 * 60);
        }

        /// <summary>
        /// 释放对象所占用的所有资源。
        /// </summary>
        public void Dispose()
        {
            timer.Dispose();
            timer = null;
        }
    }
}

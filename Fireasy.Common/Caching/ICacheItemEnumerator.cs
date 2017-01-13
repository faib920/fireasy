// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Fireasy.Common.Caching
{
    /// <summary>
    /// 提供对缓存管理器中缓存项的枚举
    /// </summary>
    public interface ICacheItemEnumerator
    {
        /// <summary>
        /// 枚举管理器中的缓存项。该方法只能由控制器调用。
        /// </summary>
        void Enumerate();

    }
}

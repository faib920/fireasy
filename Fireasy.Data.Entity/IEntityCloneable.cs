// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 支持实体的克隆。
    /// </summary>
    public interface IEntityCloneable : ICloneable
    {
        /// <summary>
        /// 克隆出一个新的实体对象。
        /// </summary>
        /// <param name="dismodified">如果为 true，将丢弃实体被修改后的属性值，沿用原来的值。</param>
        /// <returns></returns>
        IEntity Clone(bool dismodified = false);
    }
}

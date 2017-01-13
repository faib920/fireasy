// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 实体集的相关方法。
    /// </summary>
    public interface IEntitySet : IEnumerable
    {
        /// <summary>
        /// 获取或设置是否批量插入集合中的实体。
        /// </summary>
        bool AllowBatchInsert { get; set; }

        /// <summary>
        /// 获取或设置是否批量更新集合中的实体。
        /// </summary>
        bool AllowBatchUpdate { get; set; }
    }
}

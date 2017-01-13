// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Fireasy.Data.Entity
{
    internal interface IEntitySetInternalExtension
    {
        /// <summary>
        /// 获取实体的类型。
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// 获取移除的列表。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEntity> GetDetachedList();

        /// <summary>
        /// 获取添加的列表。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEntity> GetAttachedList();

        /// <summary>
        /// 获取修改的列表。
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEntity> GetModifiedList();

        /// <summary>
        /// 重置移除、添加和修改列表。
        /// </summary>
        void Reset();

        /// <summary>
        /// 获取或设置是否清空。
        /// </summary>
        bool IsNeedClear { get; set; }

        /// <summary>
        /// 转移移除的列表到当前集合中。
        /// </summary>
        /// <param name="source"></param>
        void ShiftDetachedList(IEntitySetInternalExtension source);
    }
}

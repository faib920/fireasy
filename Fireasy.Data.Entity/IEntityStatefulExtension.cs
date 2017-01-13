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
    /// 提供实体内部状态化的扩展支持。
    /// </summary>
    public interface IEntityStatefulExtension
    {
        /// <summary>
        /// 将实体修改为指定的状态。
        /// </summary>
        /// <param name="state">新的状态。</param>
        void SetState(EntityState state);

        /// <summary>
        /// 重置实体的状态。
        /// </summary>
        void ResetUnchanged();

        /// <summary>
        /// 获取已经修改的属性名称数组。
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use the method 'IsModified'.")]
        string[] GetModifiedProperties();

        /// <summary>
        /// 获取属性修改前的值。
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        PropertyValue GetOldValue(IProperty property);

        /// <summary>
        /// 直接获取属性的值。
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        PropertyValue GetDirectValue(IProperty property);

        /// <summary>
        /// 初始化属性的值。
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="modify"></param>
        void InitializateValue(IProperty property, PropertyValue value, bool modify = false);

        /// <summary>
        /// 是否处于修改锁定状态。
        /// </summary>
        /// <returns></returns>
        bool IsModifyLocked { get; set; }

        /// <summary>
        /// 通知属性已被修改。
        /// </summary>
        /// <param name="propertyName">属性名称。</param>
        void NotifyModified(string propertyName);

        /// <summary>
        /// 判断是否已经修改。
        /// </summary>
        /// <param name="propertyName">属性名称。</param>
        /// <returns></returns>
        bool IsModified(string propertyName);
    }
}

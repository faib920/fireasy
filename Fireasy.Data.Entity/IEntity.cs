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
    /// 实体的接口。
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取实体的状态。
        /// </summary>
        EntityState EntityState { get; }

        /// <summary>
        /// 获取实体的类型。
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// 获取指定属性的值。
        /// </summary>
        /// <param name="propertyName">实体属性名称。</param>
        /// <returns></returns>
        PropertyValue GetValue(string propertyName);

        /// <summary>
        /// 设置指定属性的值。
        /// </summary>
        /// <param name="propertyName">实体属性名称。</param>
        /// <param name="value">要设置的值。</param>
        void SetValue(string propertyName, PropertyValue value);
    }
}

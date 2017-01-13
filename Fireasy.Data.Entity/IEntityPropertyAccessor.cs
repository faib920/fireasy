// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 提供对实体属性访问的方法。
    /// </summary>
    public interface IEntityPropertyAccessor
    {
        /// <summary>
        /// 获取指定属性的值。
        /// </summary>
        /// <param name="property">实体属性。</param>
        /// <returns></returns>
        PropertyValue GetValue(IProperty property);

        /// <summary>
        /// 设置指定属性的值。
        /// </summary>
        /// <param name="property">实体属性。</param>
        /// <param name="value">要设置的值。</param>
        void SetValue(IProperty property, PropertyValue value);
    }
}

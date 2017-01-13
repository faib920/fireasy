using Fireasy.Common;
// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 提供对指定类型的实体进行值读取的方法。无法继承此类。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public sealed class EntityObjectReader<TEntity> : ObjectReader<TEntity>, IPropertyFieldMappingResolver where TEntity : class, IEntity
    {
        /// <summary>
        /// 读取实体实例的所有值。
        /// </summary>
        /// <param name="instance">要读取的实体实例。</param>
        /// <returns>所有属性的值。</returns>
        public override IEnumerable<object> ReadValues(TEntity instance)
        {
            return PropertyUnity.GetLoadedProperties(typeof(TEntity), true)
                .Select(p => instance.InternalGetValue(p))
                .Select(value => PropertyValue.IsNullOrEmpty(value) ? null : value.GetStorageValue());
        }

        /// <summary>
        /// 获取指定属性的值。
        /// </summary>
        /// <param name="instance">要读取的实体实例。</param>
        /// <param name="propertyName">要读取的属性的名称。</param>
        /// <returns>指定属性的值。</returns>
        public override object ReadValue(TEntity instance, string propertyName)
        {
            var property = PropertyUnity.GetProperty(typeof(TEntity), propertyName, true);
            if (property != null && property is ILoadedProperty)
            {
                var value = instance.InternalGetValue(property);
                return PropertyValue.IsNullOrEmpty(value) ? null : value.GetStorageValue();
            }

            return null;
        }

        /// <summary>
        /// 获取可以读取值的属性名称序列。
        /// </summary>
        /// <returns>所有可以读取值的属性名称序列。</returns>
        public override IEnumerable<string> GetCanReadProperties()
        {
            return from s in PropertyUnity.GetLoadedProperties(typeof(TEntity), true)
                   select s.Name;
        }

        IEnumerable<PropertyFieldMapping> IPropertyFieldMappingResolver.GetDbMapping()
        {
            return EntityPropertyFieldMappingResolver.GetDbMapping(typeof(TEntity));
        }
    }
}

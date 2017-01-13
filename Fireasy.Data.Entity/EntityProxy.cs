// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using Fireasy.Common.Extensions;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 一个代理，对实体进行其他操作。
    /// </summary>
    public class EntityProxy
    {
        private IEntity entity;
        private IEntityStatefulExtension extend;

        /// <summary>
        /// 初始化 <see cref="EntityProxy"/> 类的新实例。
        /// </summary>
        /// <param name="entity"></param>
        protected EntityProxy(IEntity entity)
        {
            this.entity = entity;
            this.extend = (IEntityStatefulExtension)entity;
        }

        /// <summary>
        /// 获取实体对象的代理。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EntityProxy Get(IEntity entity)
        {
            return new EntityProxy(entity);
        }

        /// <summary>
        /// 获取实体的类型。
        /// </summary>
        public Type EntityType
        {
            get { return entity.EntityType; }
        }

        /// <summary>
        /// 获取或设置实体的状态。
        /// </summary>
        public EntityState State
        {
            get { return entity.EntityState; }
            set 
            {
                if (value == EntityState.Unchanged)
                {
                    extend.ResetUnchanged();
                }
                else
                {
                    extend.SetState(value);
                }
            }
        }

        /// <summary>
        /// 获取属性修改前的值。
        /// </summary>
        /// <param name="property">属性。</param>
        /// <returns></returns>
        public PropertyValue GetOldValue(IProperty property)
        {
            return extend.GetOldValue(property);
        }

        /// <summary>
        /// 通知属性已被修改。
        /// </summary>
        /// <param name="property">属性。</param>
        public void NotifyModified(IProperty property)
        {
            extend.NotifyModified(property.Name);
        }

        /// <summary>
        /// 通知属性已被修改。
        /// </summary>
        /// <param name="propertyName">属性名称。</param>
        public void NotifyModified(string propertyName)
        {
            extend.NotifyModified(propertyName);
        }

        /// <summary>
        /// 判断属性是否被修改。
        /// </summary>
        /// <param name="property">属性。</param>
        /// <returns></returns>
        public bool IsModified(IProperty property)
        {
            return extend.IsModified(property.Name);
        }

        /// <summary>
        /// 判断属性是否被修改。
        /// </summary>
        /// <param name="propertyName">属性名称。</param>
        /// <returns></returns>
        public bool IsModified(string propertyName)
        {
            return extend.IsModified(propertyName);
        }
    }
}

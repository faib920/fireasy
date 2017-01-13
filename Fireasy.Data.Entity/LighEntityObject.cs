// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Aop;
using Fireasy.Common.Extensions;
using Fireasy.Data.Entity.Properties;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 精简的数据实体，继承此类不需要显式定义 <see cref="IProperty"/> 。该类型基于 AOP 实现，属性必须使用 Virtual 声明。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    [Intercept(typeof(LighEntityInterceptor))]
    public abstract class LighEntityObject<TEntity> : EntityObject, 
        IAopSupport, 
        IEntityPropertyInitialize,
        IPropertyAccessorBypass
        where TEntity : IEntity
    {
        /// <summary>
        /// 构造一个代理对象。
        /// </summary>
        /// <returns></returns>
        public static TEntity New()
        {
            return (TEntity)EntityCompiler.NewProxy(typeof(TEntity));
        }

        /// <summary>
        /// 通过 <see cref="MemberInitExpression"/> 表达式来构造一个代理对象。
        /// </summary>
        /// <param name="factory">一个成员绑定的表达式。</param>
        /// <returns></returns>
        public static TEntity Wrap(Expression<Func<TEntity>> factory)
        {
            var entity = New();
            entity.InitByExpression(factory);
            return entity;
        }

        public override PropertyValue GetValue(IProperty property)
        {
            var value = property.Info.ReflectionInfo.GetValue(this, null);
            return PropertyValue.New(value, property.Type);
        }

        public override void SetValue(IProperty property, PropertyValue value)
        {
            base.SetValue(property, value);
            property.Info.ReflectionInfo.SetValue(this, value.GetStorageValue(), null);
        }

        PropertyValue IPropertyAccessorBypass.GetValue(IProperty proprty)
        {
            return base.GetValue(proprty);
        }
        
        void IPropertyAccessorBypass.SetValue(IProperty proprty, object value)
        {
            base.SetValue(proprty, PropertyValue.New(value, proprty.Type));
        }

        void IEntityPropertyInitialize.Initialize()
        {
            var entityType = this.GetType();

            foreach (var property in entityType.BaseType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.DeclaringType == entityType.BaseType)
                {
                    //定义为 virtual
                    var getMth = property.GetGetMethod();
                    if (getMth != null && getMth.IsVirtual && !getMth.IsFinal)
                    {
                        RegisterProperty(entityType.BaseType, property);
                    }
                }
            }
        }

        private void RegisterProperty(Type entityType, PropertyInfo property)
        {
            //关联属性，即关联实体或子实体集属性
            if (typeof(IEntity).IsAssignableFrom(property.PropertyType) ||
                typeof(IEntitySet).IsAssignableFrom(property.PropertyType))
            {
                var mapping = property.GetCustomAttributes<PropertyMappingAttribute>().FirstOrDefault();
                var options = mapping != null && mapping.GetFlag(PropertyMappingAttribute.SetMark.LoadBehavior) ?
                    new RelationOptions(mapping.LoadBehavior) : null;

                PropertyUnity.RegisterSupposedProperty(property.Name, property.PropertyType, entityType, options: options);
            }
            else
            {
                var gp = new GeneralProperty()
                    {
                        Name = property.Name,
                        Type = property.PropertyType,
                        EntityType = entityType,
                        Info = new PropertyMapInfo { ReflectionInfo = property, FieldName = property.Name }
                    };

                var mapping = property.GetCustomAttributes<PropertyMappingAttribute>().FirstOrDefault();
                if (mapping != null)
                {
                    InitMapInfo(mapping, gp.Info);
                }

                PropertyUnity.RegisterProperty(entityType, gp);
            }
        }

        /// <summary>
        /// 根据映射特性设置属性的映射信息。
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="mapInfo"></param>
        private void InitMapInfo(PropertyMappingAttribute mapping, PropertyMapInfo mapInfo)
        {
            mapInfo.FieldName = mapping.ColumnName;
            mapInfo.Description = mapping.Description;
            mapInfo.GenerateType = mapping.GenerateType;

            if (mapping.GetFlag(PropertyMappingAttribute.SetMark.DataType))
            {
                mapInfo.DataType = mapping.DataType;
            }

            if (mapping.GetFlag(PropertyMappingAttribute.SetMark.IsPrimaryKey))
            {
                mapInfo.IsPrimaryKey = mapping.IsPrimaryKey;
            }

            if (mapping.GetFlag(PropertyMappingAttribute.SetMark.IsDeletedKey))
            {
                mapInfo.IsDeletedKey = mapping.IsDeletedKey;
            }

            if (mapping.DefaultValue != null)
            {
                mapInfo.DefaultValue = PropertyValue.New(mapping.DefaultValue, mapInfo.ReflectionInfo.PropertyType);
            }

            if (mapping.GetFlag(PropertyMappingAttribute.SetMark.Length))
            {
                mapInfo.Length = mapping.Length;
            }

            if (mapping.GetFlag(PropertyMappingAttribute.SetMark.Precision))
            {
                mapInfo.Precision = mapping.Precision;
            }

            if (mapping.GetFlag(PropertyMappingAttribute.SetMark.Scale))
            {
                mapInfo.Scale = mapping.Scale;
            }
        }
    }

    /// <summary>
    /// 用于绕开 GetValue 和 SetValue 方法。
    /// </summary>
    internal interface IPropertyAccessorBypass
    {
        PropertyValue GetValue(IProperty property);

        void SetValue(IProperty property, object value);
    }
}

// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Fireasy.Common.Extensions;
using Fireasy.Data.Entity.Extensions;
using Fireasy.Data.Entity.Metadata;
using Fireasy.Data.Entity.Properties;
using Fireasy.Data.Entity.Validation;
using Fireasy.Data.Extensions;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 实体属性的管理单元。
    /// </summary>
    public static class PropertyUnity
    {
        private const string NullFieldName = "NL<>";

        /// <summary>
        /// 注册基本的实体属性。
        /// </summary>
        /// <typeparam name="TEntity">实体的类型。</typeparam>
        /// <param name="expression">指定注册的属性的表达式。</param>
        /// <param name="info">属性映射信息。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        public static IProperty RegisterProperty<TEntity>(Expression<Func<TEntity, object>> expression, PropertyMapInfo info = null) where TEntity : IEntity
        {
            var propertyInfo = PropertySearchVisitor.FindProperty(expression);
            if (propertyInfo == null)
            {
                throw new InvalidOperationException(SR.GetString(SRKind.InvalidRegisterExpression));
            }

            return RegisterProperty(propertyInfo, typeof(TEntity), info);
        }
        
        /// <summary>
        /// 注册基本的实体属性。
        /// </summary>
        /// <param name="propertyName">属性名称。</param>
        /// <param name="propertyType">属性类型。</param>
        /// <param name="entityType">实体类型。</param>
        /// <param name="info">属性映射信息。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        public static IProperty RegisterProperty(string propertyName, Type propertyType, Type entityType, PropertyMapInfo info = null)
        {
            var propertyInfo = entityType.GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new PropertyNotFoundException(propertyName);
            }

            return RegisterProperty(propertyInfo, entityType, info);
        }

        /// <summary>
        /// 注册特殊的实体属性，这类属性为附加自实体间关系的不可持久化的属性。
        /// </summary>
        /// <typeparam name="TEntity">实体的类型。</typeparam>
        /// <param name="expression">指定注册的属性的表达式。</param>
        /// <param name="referenceProperty">参数或引用的属性。</param>
        /// <param name="options">关联选项。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        public static IProperty RegisterSupposedProperty<TEntity>(Expression<Func<TEntity, object>> expression, IProperty referenceProperty = null, RelationOptions options = null) where TEntity : IEntity
        {
            var propertyInfo = PropertySearchVisitor.FindProperty(expression);
            if (propertyInfo == null)
            {
                throw new InvalidOperationException(SR.GetString(SRKind.InvalidRegisterExpression));
            }

            return RegisterSupposedProperty(propertyInfo, typeof(TEntity), referenceProperty, options);
        }
        
        /// <summary>
        /// 注册特殊的实体属性，这类属性为附加自实体间关系的不可持久化的属性。
        /// </summary>
        /// <param name="propertyName">属性名称。</param>
        /// <param name="propertyType">属性类型。</param>
        /// <param name="entityType">实体类型。</param>
        /// <param name="referenceProperty">参数或引用的属性。</param>
        /// <param name="options">关联选项。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        public static IProperty RegisterSupposedProperty(string propertyName, Type propertyType, Type entityType, IProperty referenceProperty = null, RelationOptions options = null)
        {
            var propertyInfo = entityType.GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new PropertyNotFoundException(propertyName);
            }

            return RegisterSupposedProperty(propertyInfo, entityType, referenceProperty, options);
        }

        /// <summary>
        /// 注册实体属性，将属性放入到缓存表中。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <param name="property">实体属性。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        public static IProperty RegisterProperty(Type entityType, IProperty property)
        {
            var metadata = EntityMetadataUnity.InternalGetEntityMetadata(entityType);
            if (metadata != null)
            {
                metadata.InternalAddProperty(InitProperty(entityType, property));
            }

            return property;
        }

        /// <summary>
        /// 获取指定名称的实体属性。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <param name="propertyName">属性名称。</param>
        /// <param name="inherited">是否获取继承的实体属性。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        public static IProperty GetProperty(Type entityType, string propertyName, bool inherited = false)
        {
            return GetProperties(entityType, inherited)
                .FirstOrDefault(property => property.Name.Equals(propertyName));
        }

        /// <summary>
        /// 获取实体的所有属性。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <param name="inherited">是否获取继承的实体属性。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象枚举器。</returns>
        public static IEnumerable<IProperty> GetProperties(Type entityType, bool inherited = false)
        {
            if (!inherited)
            {
                return EntityMetadataUnity.InternalGetEntityMetadata(entityType).Properties;
            }

            var properties = new Dictionary<string, IProperty>();
            foreach (var type in entityType.GetBaseTypes())
            {
                if (type.IsAbstract)
                {
                    continue;
                }

                foreach (var p in GetProperties(type))
                {
                    if (!properties.ContainsKey(p.Name))
                    {
                        properties.Add(p.Name, p);
                    }
                }
            }

            return properties.Values;
        }

        /// <summary>
        /// 获取实体的具有主键的所有属性。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <param name="inherited">是否获取继承的实体属性。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象枚举器。</returns>
        public static IEnumerable<IProperty> GetPrimaryProperties(Type entityType, bool inherited = false)
        {
            return GetProperties(entityType, inherited)
                .Where(property => property is ISavedProperty && property.Info.IsPrimaryKey);
        }

        /// <summary>
        /// 获取实体的可持久化的属性。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <param name="inherited">是否获取继承的实体属性。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象枚举器。</returns>
        public static IEnumerable<IProperty> GetPersistentProperties(Type entityType, bool inherited = false)
        {
            return GetProperties(entityType, inherited)
                .Where(property => property is ISavedProperty);
        }

        /// <summary>
        /// 获取实体的可以加载的属性。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <param name="inherited">是否获取继承的实体属性。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象枚举器。</returns>
        public static IEnumerable<IProperty> GetLoadedProperties(Type entityType, bool inherited = false)
        {
            return GetProperties(entityType, inherited)
                .Where(property => property is ILoadedProperty);
        }

        /// <summary>
        /// 获取实体的关联属性。
        /// </summary>
        /// <param name="entityType">实体类型。</param>
        /// <param name="inherited">是否获取继承的实体属性。</param>
        /// <param name="behavior">属性的加载行为。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象枚举器。</returns>
        public static IEnumerable<IProperty> GetRelatedProperties(Type entityType, bool inherited = false, LoadBehavior? behavior = null)
        {
            return GetProperties(entityType, inherited)
                .Where(property => property is RelationProperty)
                .Where(property => behavior == null || property.As<RelationProperty>().Options.LoadBehavior == behavior);
        }

        /// <summary>
        /// 注册基本的实体属性。
        /// </summary>
        /// <param name="propertyInfo">属性信息。</param>
        /// <param name="entityType">实体类型。</param>
        /// <param name="info">属性映射信息。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        private static IProperty RegisterProperty(PropertyInfo propertyInfo, Type entityType, PropertyMapInfo info = null)
        {
            var property = new GeneralProperty
                {
                    Name = propertyInfo.Name,
                    Type = propertyInfo.PropertyType,
                    EntityType = entityType,
                    Info = InitPropertyInfo(info, propertyInfo)
                };

            return RegisterProperty(entityType, property);
        }

        /// <summary>
        /// 注册特殊的实体属性，这类属性为附加自实体间关系的不可持久化的属性。
        /// </summary>
        /// <param name="propertyInfo">属性名称。</param>
        /// <param name="entityType">实体类型。</param>
        /// <param name="referenceProperty">参数或引用的属性。</param>
        /// <param name="options">关联选项。</param>
        /// <returns>一个 <see cref="IProperty"/> 对象。</returns>
        private static IProperty RegisterSupposedProperty(PropertyInfo propertyInfo, Type entityType, IProperty referenceProperty = null, RelationOptions options = null)
        {
            IProperty property;
            if (referenceProperty != null)
            {
                if (referenceProperty.Type.IsEnum)
                {
                    property = new EnumProperty
                        {
                            Name = propertyInfo.Name,
                            Type = propertyInfo.PropertyType,
                            EntityType = entityType,
                            RelationType = referenceProperty.Type,
                            Reference = referenceProperty,
                            Info = InitRelatedPropertyInfo(propertyInfo),
                            Options = options ?? RelationOptions.Default
                        };
                }
                else
                {
                    //引用属性
                    property = new ReferenceProperty
                        {
                            Name = propertyInfo.Name,
                            Type = propertyInfo.PropertyType,
                            EntityType = entityType,
                            RelationType = referenceProperty.EntityType,
                            Reference = referenceProperty,
                            Info = InitRelatedPropertyInfo(propertyInfo),
                            Options = options ?? RelationOptions.Default
                        };
                }
            }
            else if (typeof(IEntity).IsAssignableFrom(propertyInfo.PropertyType))
            {
                //实体引用属性
                property = new EntityProperty
                    {
                        RelationType = propertyInfo.PropertyType,
                        Name = propertyInfo.Name,
                        Type = propertyInfo.PropertyType,
                        EntityType = entityType,
                        Info = InitRelatedPropertyInfo(propertyInfo),
                        Options = options ?? RelationOptions.Default
                    };
            }
            else if (propertyInfo.PropertyType.IsGenericType &&
                typeof(IEntitySet).IsAssignableFrom(propertyInfo.PropertyType))
            {
                //实体集属性
                property = new EntitySetProperty
                    {
                        RelationType = propertyInfo.PropertyType.GetGenericArguments()[0],
                        Name = propertyInfo.Name,
                        Type = propertyInfo.PropertyType,
                        EntityType = entityType,
                        Info = InitRelatedPropertyInfo(propertyInfo),
                        Options = options ?? RelationOptions.Default
                    };
            }
            else
            {
                throw new NotImplementedException();
            }

            return RegisterProperty(entityType, property);
        }

        /// <summary>
        /// 初始化属性映射信息。
        /// </summary>
        /// <param name="info">实体映射信息。</param>
        /// <param name="propertyInfo">属性信息。</param>
        /// <returns></returns>
        private static PropertyMapInfo InitPropertyInfo(PropertyMapInfo info, PropertyInfo propertyInfo)
        {
            if (info == null)
            {
                info = new PropertyMapInfo();
            }

            if (string.IsNullOrEmpty(info.FieldName))
            {
                info.FieldName = propertyInfo.Name;
            }

            info.ReflectionInfo = propertyInfo;
            return info;
        }

        private static IProperty InitProperty(Type entityType, IProperty property)
        {
            if (property.EntityType == null)
            {
                property.EntityType = entityType;
            }

            if (property.Info == null)
            {
                property.Info = new PropertyMapInfo();
            }

            if (string.IsNullOrEmpty(property.Info.FieldName))
            {
                property.Info.FieldName = property.Name;
            }

            if (property.Info.ReflectionInfo == null)
            {
                var propertyInfo = entityType.GetProperty(property.Name);
                if (propertyInfo == null)
                {
                    throw new PropertyNotFoundException(property.Name);
                }

                property.Info.ReflectionInfo = propertyInfo;
                property.Type = propertyInfo.PropertyType;
            }

            if (property.Info.DataType == null)
            {
                property.Info.DataType = property.Type.GetDbType();
            }

            if (IsNeedCorrectDefaultValue(property))
            {
                property.Info.DefaultValue.Correct(property.Type);
            }

            return property;
        }

        /// <summary>
        /// 初始化属性映射信息。
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private static PropertyMapInfo InitRelatedPropertyInfo(PropertyInfo propertyInfo)
        {
            return new PropertyMapInfo { FieldName = NullFieldName, ReflectionInfo = propertyInfo };
        }

        /// <summary>
        /// 判断属性是否需要纠正默认值的类型。
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static bool IsNeedCorrectDefaultValue(IProperty property)
        {
            return !property.Info.DefaultValue.IsNullOrEmpty() && 
                (property.Type.IsEnum || property.Type == typeof(bool) || property.Type == typeof(bool?));
        }

        /// <summary>
        /// 在表达式中搜索属性的信息。
        /// </summary>
        private class PropertySearchVisitor : Fireasy.Common.Linq.Expressions.ExpressionVisitor
        {
            private PropertyInfo propertyInfo;
            private Type entityType;

            internal static PropertyInfo FindProperty(Expression expression)
            {
                var lambda = expression as LambdaExpression;
                if (lambda == null)
                {
                    return null;
                }

                var visitor = new PropertySearchVisitor { entityType = lambda.Parameters[0].Type };
                visitor.Visit(expression);
                return visitor.propertyInfo;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Member.DeclaringType == entityType &&
                    node.Member is PropertyInfo)
                {
                    propertyInfo = node.Member.As<PropertyInfo>();
                    return node;
                }

                return base.VisitMember(node);
            }
        }
    }
}

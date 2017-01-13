// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Fireasy.Common;
using Fireasy.Common.Extensions;
using Fireasy.Common.Linq.Expressions;
using Fireasy.Data.Entity.Metadata;
using Fireasy.Data.Entity.Properties;
using Fireasy.Data.RecordWrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Fireasy.Data.Entity
{
    /// <summary>
    /// 实体的一些扩展方法。
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// 为实体加载指定的具有延迟行为的属性的值，该属性为 <see cref="RelationProperty"/> 的子类，且 <see cref="LoadBehavior"/> 属性应设置为 <see cref="LoadBehavior.Lazy"/>。
        /// </summary>
        /// <param name="entity">当前的实体对象。</param>
        /// <param name="property">要进行加载的属性。</param>
        public static void Lazyload(this IEntity entity, IProperty property)
        {
            var value = EntityLazyloader.Load(entity, property);
            var extend = entity as IEntityStatefulExtension;
            if (extend != null)
            {
                extend.InitializateValue(property, value);
            }
            else
            {
                entity.InternalSetValue(property, value);
            }
        }

        /// <summary>
        /// 获取实体被修改的属性列表。
        /// </summary>
        /// <param name="entity">当前的实体对象。</param>
        /// <returns></returns>
        public static string[] GetModifiedProperties(this IEntity entity)
        {
            if (entity.EntityState == EntityState.Attached ||
                entity.EntityState == EntityState.Modified)
            {
                var ext = entity as IEntityStatefulExtension;
                if (ext != null)
                {
                    return ext.GetModifiedProperties();
                }
            }

            return new string[0];
        }

        /// <summary>
        /// 获取实体指定属性修改前的值。
        /// </summary>
        /// <param name="entity">当前的实体对象。</param>
        /// <param name="propertyName">属性名称。</param>
        /// <returns></returns>
        public static PropertyValue GetOldValue(this IEntity entity, string propertyName)
        {
            if (entity.EntityState == EntityState.Attached ||
                entity.EntityState == EntityState.Modified)
            {
                var property = PropertyUnity.GetProperty(entity.EntityType, propertyName);
                var ext = entity as IEntityStatefulExtension;
                if (property != null && ext != null)
                {
                    return ext.GetOldValue(property);
                }
            }

            return null;
        }

        /// <summary>
        /// 使用指定的实体的属性集来构造一个 <see cref="DataTable"/>，<see cref="DataTable"/> 里的列与实体属性一一对应。
        /// </summary>
        /// <param name="entity">当前的实体对象。</param>
        /// <returns>一个包含实体结构的空 <see cref="DataTable"/>。</returns>
        public static DataTable Construct(this IEntity entity)
        {
            Guard.ArgumentNull(entity, "entity");
            return Construct(entity.EntityType);
        }

        /// <summary>
        /// 将一个实体对象添加到 <see cref="DataTable"/> 对象里，该 <see cref="DataTable"/> 的结构必须保证与实体结构相符。
        /// </summary>
        /// <param name="entity">当前的实体对象。</param>
        /// <param name="table">一个使用 <see cref="Construct"/> 构造的 <see cref="DataTable"/>。</param>
        public static void Putin(this IEntity entity, DataTable table)
        {
            Guard.ArgumentNull(entity, "entity");
            Guard.ArgumentNull(table, "table");

            var properties = PropertyUnity.GetPersistentProperties(entity.EntityType)
                .Where(s => table.Columns.Contains(s.Name)).ToList();

            var count = properties.Count;
            var data = new object[count];
            for (var i = 0; i < count; i++)
            {
                var value = entity.InternalGetValue(properties[i]);
                data[i] = PropertyValue.IsNullOrEmpty(value) ? DBNull.Value : value.GetStorageValue();
            }

            table.Rows.Add(data);
        }

        /// <summary>
        /// 通过主键值使对象正常化。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValues">主键值数组。</param>
        /// <returns></returns>
        public static T Normalize<T>(this T entity, params object[] keyValues) where T : IEntity
        {
            var primaryKeys = PropertyUnity.GetPrimaryProperties(entity.EntityType).ToArray();
            if (primaryKeys.Length != 0 && keyValues == null ||
                primaryKeys.Length != keyValues.Length)
            {
                throw new Exception(SR.GetString(SRKind.DisaccordArgument, primaryKeys.Length, keyValues.Length));
            }

            var extend = entity as IEntityStatefulExtension;
            if (extend == null)
            {
                return entity;
            }

            for (var i = 0; i < primaryKeys.Length; i++)
            {
                extend.InitializateValue(primaryKeys[i], PropertyValue.New(keyValues[i], primaryKeys[i].Type));
            }

            extend.SetState(EntityState.Modified);

            return entity;
        }

        /// <summary>
        /// 设置实体的状态。
        /// </summary>
        /// <param name="entity">要设置状态的实体。</param>
        /// <param name="state">要设置的状态。</param>
        internal static void SetState(this IEntity entity, EntityState state)
        {
            var extend = entity as IEntityStatefulExtension;
            if (extend == null)
            {
                return;
            }

            if (state == EntityState.Unchanged)
            {
                extend.ResetUnchanged();
            }
            else
            {
                extend.SetState(state);
            }
        }

        /// <summary>
        /// 锁定实体执行一个方法，即当前实体修改期间，不能再次对该实体进行操作。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        internal static void TryLockModifing(this IEntity entity, Action action)
        {
            var extend = entity.As<IEntityStatefulExtension>();
            if (extend == null || extend.IsModifyLocked)
            {
                return;
            }

            extend.IsModifyLocked = true;
            action();
            extend.IsModifyLocked = false;
        }

        /// <summary>
        /// 获取实体的根实体类型。
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static Type GetRootType(this Type entityType)
        {
            while (true)
            {
                if (!entityType.BaseType.IsDefined<EntityMappingAttribute>() || 
                    !entityType.BaseType.IsDirectImplementInterface(typeof(IEntity)))
                {
                    break;
                }

                entityType = entityType.BaseType;
            }

            return entityType;
        }

        /// <summary>
        /// 枚举实体的所有父实体类型。
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetBaseTypes(this Type entityType)
        {
            Guard.ArgumentNull(entityType, "entityType");
            if (entityType.IsInterface)
            {
                yield break;
            }

            var stack = new Stack<Type>();
            var type = entityType;

            while (!type.IsDirectImplementInterface(typeof(IEntity)))
            {
                stack.Push(type);
                type = type.BaseType;
            }

            while (stack.Count > 0)
            {
                yield return stack.Pop();
            }
        }

        /// <summary>
        /// 执行一个查询，返回一个序列。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database"></param>
        /// <param name="queryCommand"></param>
        /// <param name="segment"></param>
        /// <param name="parameters"></param>
        /// <param name="initializer"></param>
        /// <param name="setter"></param>
        /// <returns></returns>
        internal static IEnumerable<T> InternalExecuteEnumerable<T>(this IDatabase database, IQueryCommand queryCommand, IDataSegment segment = null, ParameterCollection parameters = null, Action<object> initializer = null, Action<IDataReader, T> setter = null)
        {
            var mapper = RowMapperFactory.CreateMapper<T>();
            Guard.ArgumentNull(mapper, "mapper");

            mapper.RecordWrapper = database.Provider.GetService<IRecordWrapper>();
            mapper.Initializer = initializer;

            using (var reader = database.ExecuteReader(queryCommand, segment, parameters))
            {
                while (reader.Read())
                {
                    var item = mapper.Map(reader);
                    if (setter != null)
                    {
                        setter(reader, item);
                    }

                    yield return item;
                }
            }
        }

        /// <summary>
        /// 执行一个查询，返回一个序列。
        /// </summary>
        /// <param name="database"></param>
        /// <param name="elementType"></param>
        /// <param name="queryCommand"></param>
        /// <param name="segment"></param>
        /// <param name="parameters"></param>
        /// <param name="initializer"></param>
        /// <param name="setter"></param>
        /// <returns></returns>
        internal static IEnumerable InternalExecuteEnumerable(this IDatabase database, Type elementType, IQueryCommand queryCommand, IDataSegment segment = null, ParameterCollection parameters = null, Action<object> initializer = null, Action<IDataReader, object> setter = null)
        {
            var mapper = RowMapperFactory.CreateMapper(elementType);
            Guard.ArgumentNull(mapper, "mapper");

            mapper.RecordWrapper = database.Provider.GetService<IRecordWrapper>();
            mapper.Initializer = initializer;
            
            using (var reader = database.ExecuteReader(queryCommand, segment, parameters))
            {
                while (reader.Read())
                {
                    var item = mapper.Map(reader);
                    if (setter != null)
                    {
                        setter(reader, item);
                    }

                    yield return item;
                }
            }
        }

        /// <summary>
        /// 获取实体指定属性的值。判断实体是否实现了 <see cref="IEntityPropertyAccessor"/> 接口。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        internal static PropertyValue InternalGetValue(this IEntity entity, IProperty property)
        {
            var accessor = entity as IEntityPropertyAccessor;
            return accessor != null ? accessor.GetValue(property) : entity.GetValue(property.Name);
        }

        /// <summary>
        /// 设置实体指定属性的值。判断实体是否实现了 <see cref="IEntityPropertyAccessor"/> 接口。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        internal static void InternalSetValue(this IEntity entity, IProperty property, PropertyValue value)
        {
            var accessor = entity as IEntityPropertyAccessor;
            if (accessor != null)
            {
                accessor.SetValue(property, value);
            }
            else
            {
                entity.SetValue(property.Name, value);
            }
        }

        /// <summary>
        /// 如果对象实现了 <see cref="IEntityPersistentInstanceContainer"/> 接口，则会将 <paramref name="instanceName"/> 附加到该对象。
        /// </summary>
        /// <param name="item"></param>
        /// <param name="instanceName"></param>
        internal static T InitializeInstanceName<T>(this T item, string instanceName)
        {
            if (item == null)
            {
                return default(T);
            }

            item.As<IEntityPersistentInstanceContainer>(e => 
                    e.InstanceName = instanceName);

            return item;
        }

        /// <summary>
        /// 如果对象实现了 <see cref="IEntityPersistentEnvironment"/> 接口，则会将 <paramref name="environment"/> 附加到该对象；
        /// </summary>
        /// <param name="item"></param>
        /// <param name="environment"></param>
        internal static T InitializeEnvironment<T>(this T item, EntityPersistentEnvironment environment)
        {
            if (item == null)
            {
                return default(T);
            }

            item.As<IEntityPersistentEnvironment>(e =>
                {
                    if (environment != null)
                    {
                        e.Environment = environment;
                    }
                });

            return item;
        }

        /// <summary>
        /// 依据一个属性生成一个 <see cref="DataColumn"/> 对象。
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static DataColumn ToDataColumn(this IProperty property)
        {
            if (property is RelationProperty)
            {
                return null;
            }

            var dataType = property.Type.GetNonNullableType();
            var column = new DataColumn(property.Info.FieldName, dataType);

            //默认值
            if (!property.Info.DefaultValue.IsNullOrEmpty())
            {
                column.DefaultValue = property.Info.DefaultValue.GetStorageValue();
            }

            //长度 
            if (property.Type == typeof(string) && property.Info.Length != null)
            {
                column.MaxLength = (int)property.Info.Length;
            }

            //主键
            //if (property.Info.IsPrimaryKey)
            //{
            //    column.Unique = true;
            //}

            //可空
            column.AllowDBNull = property.Info.IsNullable;

            return column;
        }

        /// <summary>
        /// 通过一个 <see cref="MemberInitExpression"/> 表达式将属性值绑定到实体对象中。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static IEntity InitByExpression(this IEntity entity, LambdaExpression factory)
        {
            var initExp = factory.Body as MemberInitExpression;
            if (initExp != null)
            {
                foreach (var b in initExp.Bindings)
                {
                    var assign = b as MemberAssignment;
                    if (assign == null)
                    {
                        continue;
                    }

                    var exp = PartialEvaluator.Eval(assign.Expression);
                    var constExp = exp as ConstantExpression;
                    if (constExp != null)
                    {
                        entity.SetValue(assign.Member.Name, PropertyValue.New(constExp.Value, assign.Member.GetMemberType()));
                    }
                }
            }

            return entity;
        }

        /// <summary>
        /// 使用指定的实体的属性集来构造一个 <see cref="DataTable"/>，<see cref="DataTable"/> 里的列与实体属性一一对应。
        /// </summary>
        /// <param name="entityType">实体的类型。</param>
        /// <returns></returns>
        private static DataTable Construct(Type entityType)
        {
            Guard.ArgumentNull(entityType, "entityType");
            var metadata = EntityMetadataUnity.GetEntityMetadata(entityType);
            var table = new DataTable(metadata.TableName);
            foreach (var property in PropertyUnity.GetPersistentProperties(entityType))
            {
                table.Columns.Add(property.ToDataColumn());
            }

            return table;
        }
    }
}

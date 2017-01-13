// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Fireasy.Common.Extensions;
using Fireasy.Data.Batcher;
using Fireasy.Data.Entity.Metadata;
using Fireasy.Data.Entity.Properties;
using Fireasy.Data.Entity.QueryBuilder;
using Fireasy.Data.Entity.Subscribes;
using Fireasy.Data.Entity.Validation;
using Fireasy.Data.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fireasy.Data.Entity.Linq
{
    /// <summary>
    /// 缺省的仓储服务实现，使用 Linq to SQL。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public sealed class DefaultRepositoryProvider<TEntity> : IRepositoryProvider<TEntity> where TEntity : IEntity
    {
        private InternalContext context;

        /// <summary>
        /// 初始化 <see cref="DefaultRepositoryProvider"/> 类的新实例。
        /// </summary>
        /// <param name="context"></param>
        public DefaultRepositoryProvider(InternalContext context)
        {
            this.context = context;
            var entityQueryProvider = new EntityQueryProvider(context);
            context.As<IEntityPersistentInstanceContainer>(s => entityQueryProvider.InitializeInstanceName(s.InstanceName));
            QueryProvider = new QueryProvider(entityQueryProvider);
            Queryable = new QuerySet<TEntity>(QueryProvider, null);
        }

        public IQueryable Queryable { get; private set; }

        public IQueryProvider QueryProvider { get; private set; }

        public int Insert(TEntity entity)
        {
            EntityPersistentSubscribePublisher.OnBeforeCreate(entity);
            ValidationUnity.Validate(entity);

            var trans = CheckRelationHasModified(entity);
            if (trans)
            {
                context.Database.BeginTransaction();
            }

            int result = 0;

            try
            {
                if ((result = Queryable.CreateEntity(entity)) > 0)
                {
                    entity.As<IEntityPersistentEnvironment>(s => s.Environment = context.Environment);
                    entity.As<IEntityPersistentInstanceContainer>(s => s.InstanceName = context.InstanceName);
                    
                    HandleRelationProperties(entity);
                    EntityPersistentSubscribePublisher.OnAfterCreate(entity);
                }

                if (trans)
                {
                    context.Database.CommitTransaction();
                }
            }
            catch (Exception exp)
            {
                if (trans)
                {
                    context.Database.RollbackTransaction();
                }

                throw exp;
            }

            return result;
        }

        public int Update(TEntity entity)
        {
            EntityPersistentSubscribePublisher.OnBeforeUpdate(entity);
            ValidationUnity.Validate(entity);

            var trans = CheckRelationHasModified(entity);
            if (trans)
            {
                context.Database.BeginTransaction();
            }

            int result = 0;

            try
            {
                if ((result = Queryable.UpdateEntity(entity)) > 0)
                {
                    EntityPersistentSubscribePublisher.OnAfterUpdate(entity);
                }

                HandleRelationProperties(entity);

                if (trans)
                {
                    context.Database.CommitTransaction();
                }
            }
            catch (Exception exp)
            {
                if (trans)
                {
                    context.Database.RollbackTransaction();
                }

                throw exp;
            }

            return result;
        }

        public void BatchInsert(IEnumerable<TEntity> entities, int batchSize = 1000, Action<int> completePercentage = null)
        {
            var batcher = context.Database.Provider.GetService<IBatcherProvider>();
            if (batcher == null)
            {
                throw new EntityPersistentException(SR.GetString(SRKind.NotSupportBatcher), null);
            }

            var syntax = context.Database.Provider.GetService<ISyntaxProvider>();
            var rootType = typeof(TEntity).GetRootType();
            var tableName = string.Empty;

            entities.ForEach(s => EntityPersistentSubscribePublisher.OnBeforeCreate(s));

            //if (Environment != null)
            {
                //    tableName = DbUtility.FormatByQuote(syntax, Environment.GetVariableTableName(rootType));
            }
            //else
            {
                var metadata = EntityMetadataUnity.GetEntityMetadata(rootType);
                tableName = DbUtility.FormatByQuote(syntax, metadata.TableName);
            }

            batcher.Insert(context.Database, entities, tableName, batchSize, completePercentage);
        }

        public int Delete(TEntity entity, bool logicalDelete = true)
        {
            EntityPersistentSubscribePublisher.OnBeforeRemove(entity);

            int result;
            if ((result = Queryable.RemoveEntity(entity, logicalDelete)) > 0)
            {
                EntityPersistentSubscribePublisher.OnAfterRemove(entity);
            }

            return result;
        }

        public int Delete(object[] primaryValues, bool logicalDelete = true)
        {
            return Queryable.RemoveByPrimary(primaryValues, logicalDelete);
        }

        public TEntity Get(params object[] primaryValues)
        {
            return (TEntity)Queryable.GetByPrimary(primaryValues);
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate, bool logicalDelete = true)
        {
            return Queryable.RemoveWhere(predicate, logicalDelete);
        }

        public int Update(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            return Queryable.UpdateWhere(entity, predicate);
        }

        public int Update(Expression<Func<TEntity, TEntity>> calculator, Expression<Func<TEntity, bool>> predicate)
        {
            return Queryable.UpdateWhere(calculator, predicate);
        }

        public int Batch(IEnumerable<TEntity> instances, Expression<Func<IRepository<TEntity>, TEntity, int>> fnOperation)
        {
            return Queryable.BatchOperate(instances.Cast<IEntity>(), fnOperation);
        }

        public IEnumerable<TEntity> Where(string condition, string orderBy, IDataSegment segment = null, ParameterCollection parameters = null)
        {
            var syntax = context.Database.Provider.GetService<ISyntaxProvider>();
            var query = new EntityQueryBuilder(syntax, null, typeof(TEntity), parameters).Select().All().From().Where(condition).OrderBy(orderBy);
            return context.Database.InternalExecuteEnumerable<TEntity>(query.ToSqlCommand(), segment, parameters);
        }

        /// <summary>
        /// 检查有没有关联属性被修改.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool CheckRelationHasModified(IEntity entity)
        {
            var modified = false;
            entity.As<IEntityStatefulExtension>(ext =>
                {
                    modified = PropertyUnity.GetRelatedProperties(entity.EntityType).Any(s => ext.IsModified(s.Name));
                });

            return modified;
        }

        /// <summary>
        /// 检查实体的关联属性。
        /// </summary>
        /// <param name="entity"></param>
        private void HandleRelationProperties(IEntity entity)
        {
            entity.As<IEntityStatefulExtension>(ext =>
                {
                    var properties = PropertyUnity.GetRelatedProperties(entity.EntityType).Where(s => ext.IsModified(s.Name)).ToList();
                    if (properties.Count > 0)
                    {
                        HandleRelationProperties(entity, properties);
                    }
                });
        }

        /// <summary>
        /// 处理实体的关联的属性。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="properties"></param>
        private void HandleRelationProperties(IEntity entity, List<IProperty> properties)
        {
            foreach (RelationProperty property in properties)
            {
                var queryable = (IQueryable)context.GetDbSet(property.RelationType);

                switch (property.RelationPropertyType)
                {
                    case RelationPropertyType.Entity:
                        var refEntity = (IEntity)entity.InternalGetValue(property).GetStorageValue();
                        switch (refEntity.EntityState)
                        {
                            case EntityState.Modified:
                                queryable.UpdateEntity(refEntity);
                                refEntity.SetState(EntityState.Unchanged);
                                break;
                        }

                        HandleRelationProperties(refEntity);
                        break;
                    case RelationPropertyType.EntitySet:
                        var entitySet = (IEntitySet)entity.InternalGetValue(property).GetStorageValue();
                        HandleRelationEntitySet(queryable, entity, entitySet, property);
                        break;
                }
            }
        }

        /// <summary>
        /// 处理关联的实体集合。
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="entity"></param>
        /// <param name="entitySet"></param>
        /// <param name="property"></param>
        private void HandleRelationEntitySet(IQueryable queryable, IEntity entity, IEntitySet entitySet, IProperty property)
        {
            var list = (IEntitySetInternalExtension)entitySet;
            var added = list.GetAttachedList();
            var modified = list.GetModifiedList();
            var deleted = list.GetDetachedList();

            if (deleted.Count() > 0)
            {
                queryable.BatchOperate(deleted, queryable.CreateDeleteExpression(true));
            }

            if (modified.Count() > 0)
            {
                if (entitySet.AllowBatchUpdate)
                {
                    queryable.BatchOperate(modified, queryable.CreateUpdateExpression());
                }
                else
                {
                    foreach (var e in modified)
                    {
                        queryable.UpdateEntity(e);
                        e.SetState(EntityState.Unchanged);
                        HandleRelationProperties(e);
                    }
                }
            }

            if (added.Count() > 0)
            {
                var relation = RelationshipUnity.GetRelationship(property);
                added.ForEach(e =>
                    {
                        foreach (var key in relation.Keys)
                        {
                            var value = entity.InternalGetValue(key.ThisProperty);
                            e.InternalSetValue(key.OtherProperty, value);
                        }
                    });

                if (entitySet.AllowBatchInsert)
                {
                    queryable.BatchOperate(added, queryable.CreateInsertExpression());
                }
                else
                {
                    foreach (var e in added)
                    {
                        queryable.CreateEntity(e);
                        e.SetState(EntityState.Unchanged);
                        HandleRelationProperties(e);
                    }
                }
            }

            list.Reset();
        }
    }
}

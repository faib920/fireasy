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

namespace Fireasy.Data.Entity.Linq
{
    /// <summary>
    /// 仓储提供者接口。
    /// </summary>
    public interface IRepositoryProvider
    {
        IQueryable Queryable { get; }

        IQueryProvider QueryProvider { get; }
    }

    /// <summary>
    /// 仓储提供者接口。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryProvider<TEntity> : IRepositoryProvider where TEntity : IEntity
    {

        int Insert(TEntity entity);

        int Update(TEntity entity);

        void BatchInsert(IEnumerable<TEntity> entities, int batchSize = 1000, Action<int> completePercentage = null);

        int Delete(TEntity entity, bool logicalDelete = true);

        int Delete(object[] primaryValues, bool logicalDelete = true);

        TEntity Get(params object[] primaryValues);

        int Delete(Expression<Func<TEntity, bool>> predicate, bool logicalDelete = true);

        int Update(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        int Update(Expression<Func<TEntity, TEntity>> calculator, Expression<Func<TEntity, bool>> predicate);

        int Batch(IEnumerable<TEntity> instances, Expression<Func<IRepository<TEntity>, TEntity, int>> fnOperation);

        IEnumerable<TEntity> Where(string condition, string orderBy, IDataSegment segment = null, ParameterCollection parameters = null);
    }
}

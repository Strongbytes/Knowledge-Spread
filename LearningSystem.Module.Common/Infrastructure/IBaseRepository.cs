using LearningSystem.Module.Common.Infrastructure.EagerLoading;
using LearningSystem.Module.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LearningSystem.Module.Common.Infrastructure
{
    public interface IBaseRepository<TEntity> where TEntity : BaseDbEntity
    {
        Task<bool> HasRows();

        Task<int> Count();

        Task<TEntity> Get(params object[] primaryKeyValues);

        Task<IEnumerable<TEntity>> GetAll(QueryTracking queryTrackingOptions = QueryTracking.AsTracking);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, QueryTracking queryTrackingOptions = QueryTracking.AsTracking);

        Task<IEnumerable<TEntity>> FindRange<TValue>(Expression<Func<TEntity, TValue>> valueSelector, TValue[] entitiesIds, QueryTracking queryTrackingOptions = QueryTracking.AsTracking);

        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, QueryTracking queryTrackingOptions = QueryTracking.AsTracking);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Clear();

        IQueryInclude<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);

        IQueryable<TEntity> AsNoTracking();
    }
}

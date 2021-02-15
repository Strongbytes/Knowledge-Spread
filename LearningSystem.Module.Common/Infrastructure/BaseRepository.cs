using LearningSystem.Module.Common.Extensions;
using LearningSystem.Module.Common.Extensions.QueryInclude;
using LearningSystem.Module.Common.Infrastructure.EagerLoading;
using LearningSystem.Module.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LearningSystem.Module.Common.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseDbEntity
    {
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(DbContext context)
        {
            DbSet = context.Set<TEntity>();
        }

        public virtual Task<bool> HasRows()
        {
            return DbSet.AnyAsync();
        }

        public virtual Task<int> Count()
        {
            return DbSet.CountAsync();
        }

        public virtual async Task<TEntity> Get(params object[] primaryKeyValues)
        {
            return await DbSet.FindAsync(primaryKeyValues);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(QueryTracking queryTrackingOptions = QueryTracking.AsTracking)
        {
            return await DbSet.SetTrackingOptions(queryTrackingOptions).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, QueryTracking queryTrackingOptions = QueryTracking.AsTracking)
        {
            return await DbSet.SetTrackingOptions(queryTrackingOptions).Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindRange<TValue>(Expression<Func<TEntity, TValue>> valueSelector, TValue[] entitiesIds, QueryTracking queryTrackingOptions = QueryTracking.AsTracking)
        {
            return await DbSet.SetTrackingOptions(queryTrackingOptions).Search(valueSelector, entitiesIds).ToListAsync();
        }

        public virtual async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, QueryTracking queryTrackingOptions = QueryTracking.AsTracking)
        {
            return await DbSet.SetTrackingOptions(queryTrackingOptions).SingleOrDefaultAsync(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual void Clear()
        {
            DbSet.RemoveRange(DbSet);
        }

        // WARNING: Do not make this method virtual, as it is a wrapper over QueryInclude methods and the tests will fail
        public IQueryInclude<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            return QueryIncludeExtensions.Include(DbSet, navigationProperty);
        }

        // WARNING: Do not make this method virtual, as it is a wrapper over EntityFrameowrkCore methods and the tests will fail
        public IQueryable<TEntity> AsNoTracking()
        {
            return QueryExtensions.AsNoTracking(DbSet);
        }
    }
}

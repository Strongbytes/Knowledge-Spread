using LearningSystem.Module.Common.Infrastructure.EagerLoading;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LearningSystem.Module.Common.Extensions.QueryInclude
{
    public static class QueryIncludeExtensions
    {
        public static IQueryInclude<TEntity, TProperty> Include<TEntity, TProperty>(this IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> propToExpand) where TEntity : class
        {
            return new QueryInclude<TEntity, TProperty>(EntityFrameworkQueryableExtensions.Include(query, propToExpand));
        }

        public static IQueryInclude<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(this IQueryInclude<TEntity, TPreviousProperty> query, Expression<Func<TPreviousProperty, TProperty>> propToExpand) where TEntity : class
        {
            return new QueryInclude<TEntity, TProperty>(EntityFrameworkQueryableExtensions.ThenInclude(query.GetQuery(), propToExpand));
        }

        public static IQueryInclude<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(this IQueryInclude<TEntity, ICollection<TPreviousProperty>> query, Expression<Func<TPreviousProperty, TProperty>> propToExpand) where TEntity : class
        {
            return new QueryInclude<TEntity, TProperty>(EntityFrameworkQueryableExtensions.ThenInclude(query.GetQuery(), propToExpand));
        }
    }
}

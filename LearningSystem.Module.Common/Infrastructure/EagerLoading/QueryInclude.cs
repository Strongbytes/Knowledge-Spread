using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LearningSystem.Module.Common.Infrastructure.EagerLoading
{
    public class QueryInclude<TEntity, TPreviousProperty> : IQueryInclude<TEntity, TPreviousProperty>
    {
        private readonly IIncludableQueryable<TEntity, TPreviousProperty> _query;

        public QueryInclude(IIncludableQueryable<TEntity, TPreviousProperty> query)
        {
            _query = query;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        public Expression Expression => _query.Expression;

        public Type ElementType => _query.ElementType;

        public IQueryProvider Provider => _query.Provider;

        public IIncludableQueryable<TEntity, TPreviousProperty> GetQuery()
        {
            return _query;
        }
    }
}

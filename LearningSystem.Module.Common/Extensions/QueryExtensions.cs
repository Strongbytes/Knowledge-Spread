using LearningSystem.Module.Common.Extensions;
using LearningSystem.Module.Common.Infrastructure;
using LearningSystem.Module.Common.Models;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace LearningSystem.Module.Common.Extensions
{
    public static class QueryExtensions
    {
        internal static IQueryable<TEntity> SetTrackingOptions<TEntity>(this IQueryable<TEntity> query, QueryTracking queryTrackingOptions) where TEntity : class
        {
            if (queryTrackingOptions == QueryTracking.AsTracking)
            {
                return query.AsTracking();
            }

            return EntityFrameworkQueryableExtensions.AsNoTracking(query);
        }

        public static IQueryable<TEntity> AsNoTracking<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            return EntityFrameworkQueryableExtensions.AsNoTracking(query);
        }

        public static Task<int> CountAsync<TEntity>(this IQueryable<TEntity> query)
        {
            return EntityFrameworkQueryableExtensions.CountAsync(query);
        }

        public static Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> query)
        {
            return EntityFrameworkQueryableExtensions.ToListAsync(query);
        }

        public static IOrderedQueryable<TSource> Where<TSource>(this IQueryable<TSource> query, PropertyInfo propertyInfo, object comparableProperty, ExpressionType expressionType)
        {
            if (propertyInfo == null)
            {
                return (IOrderedQueryable<TSource>)query;
            }

            ParameterExpression parameter = Expression.Parameter(typeof(TSource), nameof(propertyInfo));
            BinaryExpression comparison = Expression.MakeBinary(expressionType, Expression.Property(parameter, propertyInfo.Name), Expression.Constant(comparableProperty));
            LambdaExpression selector = Expression.Lambda<Func<TSource, bool>>(comparison, parameter);

            MethodInfo genericMethod = RetrieveQueryableMethodByName(nameof(Where)).MakeGenericMethod(typeof(TSource));
            return (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query, selector });
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, PropertyInfo propertyInfo)
        {
            return OrderData(query, propertyInfo, nameof(OrderBy));
        }

        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> query, PropertyInfo propertyInfo)
        {
            return OrderData(query, propertyInfo, nameof(OrderByDescending));
        }

        private static IOrderedQueryable<TSource> OrderData<TSource>(IQueryable<TSource> query, PropertyInfo propertyInfo, string methodName)
        {
            if (propertyInfo == null)
            {
                return (IOrderedQueryable<TSource>)query;
            }

            ParameterExpression arg = Expression.Parameter(typeof(TSource), nameof(propertyInfo));
            MemberExpression property = Expression.Property(arg, propertyInfo.Name);
            LambdaExpression selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            MethodInfo genericMethod = RetrieveQueryableMethodByName(methodName).MakeGenericMethod(typeof(TSource), propertyInfo.PropertyType);
            return (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query, selector });
        }

        private static MethodInfo RetrieveQueryableMethodByName(string methodName)
        {
            const int numberOfParametersForMethod = 2;

            return typeof(Queryable).GetMethods()
                 .Where(m => m.Name == methodName && m.IsGenericMethodDefinition)
                 .First(m => m.GetParameters().ToList().Count == numberOfParametersForMethod);
        }

        public static IQueryable<TSource> Search<TSource>(this IQueryable<TSource> query, string[] searchParams, params Expression<Func<TSource, string>>[] stringProperties)
        {
            return query.Where(query.Search(stringProperties).ContainingAll(searchParams).AsExpression());
        }

        public static IQueryable<TSource> Search<TSource, TValue>(this IQueryable<TSource> query, Expression<Func<TSource, TValue>> valueSelector, IEnumerable<TValue> values)
        {
            if (valueSelector == null)
            {
                throw new ArgumentNullException(nameof(valueSelector));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            ParameterExpression arg = valueSelector.Parameters.Single();

            if (!values.Any())
            {
                return query;
            }

            var equals = values.Select(value => (Expression)Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue))));
            var body = equals.Aggregate((accumulate, equal) => Expression.Or(accumulate, equal));

            return query.Where(Expression.Lambda<Func<TSource, bool>>(body, arg));
        }

        public static IQueryable<TSource> PaginateDataSet<TSource>(this IQueryable<TSource> dataSet, BaseDomainPagedRequestModel model)
        {
            if (model.Page == int.MinValue || model.PageSize == int.MinValue)
            {
                return dataSet;
            }

            return dataSet.Skip((model.Page - 1) * model.PageSize).Take(model.PageSize);
        }
    }
}

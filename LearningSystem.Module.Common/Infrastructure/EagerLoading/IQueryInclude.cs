using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace LearningSystem.Module.Common.Infrastructure.EagerLoading
{
    public interface IQueryInclude<out TEntity, out TProperty> : IQueryable<TEntity>
    {
        IIncludableQueryable<TEntity, TProperty> GetQuery();
    }
}

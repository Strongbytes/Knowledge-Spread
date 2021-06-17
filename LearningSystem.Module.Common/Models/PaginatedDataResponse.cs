using LearningSystem.Module.Common.Infrastructure.Pagination;
using System.Collections.Generic;

namespace LearningSystem.Module.Common.Models
{
    public class PaginatedDataResponse<T> : IPaginatedDataResponse<T>
    {
        public int Count { get; }

        public IEnumerable<T> Data { get; }
    }
}

using System.Collections.Generic;

namespace LearningSystem.Module.Common.Infrastructure.Pagination
{
    public interface IPaginatedDataResponse<out T>
    {
        IEnumerable<T> Data { get; }
    }
}

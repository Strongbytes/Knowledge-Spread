using LearningSystem.Module.Common.Infrastructure.Pagination;

namespace LearningSystem.Module.Common.Models
{
    public class PaginatedDataQuery : IPaginatedDataQuery
    {
        public int BatchSize { get; set; } = 5;
    }
}

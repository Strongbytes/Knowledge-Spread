using LearningSystem.Module.Common.Infrastructure.Pagination;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetPaginatedLearningPaths
{
    public class GetPaginatedLearningPathsQuery : IRequest<IPaginatedDataResponse<LearningPathDomainModel>>
    {
        internal IPaginatedDataQuery PaginatedDataQuery { get; set; }

        public GetPaginatedLearningPathsQuery(IPaginatedDataQuery paginatedDataQuery)
        {
            PaginatedDataQuery = paginatedDataQuery;
        }
    }
}
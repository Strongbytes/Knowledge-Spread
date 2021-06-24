using LearningSystem.Module.Common.Infrastructure.Pagination;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetPaginatedTutorials
{
    public class GetPaginatedTutorialsQuery : IRequest<IPaginatedDataResponse<TutorialDomainModel>>
    {
        internal IPaginatedDataQuery PaginatedDataQuery { get; }

        public GetPaginatedTutorialsQuery(IPaginatedDataQuery paginatedDataQuery)
        {
            PaginatedDataQuery = paginatedDataQuery ?? throw new ArgumentNullException(nameof(paginatedDataQuery));
        }
    }
}
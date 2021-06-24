using AutoMapper;
using LearningSystem.Module.Common.Infrastructure.Pagination;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetPaginatedTutorials
{
    internal class GetPaginatedTutorialsQueryHandler : IRequestHandler<GetPaginatedTutorialsQuery, IPaginatedDataResponse<TutorialDomainModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPaginatedTutorialsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IPaginatedDataResponse<TutorialDomainModel>> Handle(GetPaginatedTutorialsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
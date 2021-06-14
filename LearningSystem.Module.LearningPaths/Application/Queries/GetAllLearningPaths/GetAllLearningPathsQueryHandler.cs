using AutoMapper;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetAllLearningPaths
{
    internal class GetAllLearningPathsQueryHandler : IRequestHandler<GetAllLearningPathsQuery, IEnumerable<LearningPathDomainModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllLearningPathsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LearningPathDomainModel>> Handle(GetAllLearningPathsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
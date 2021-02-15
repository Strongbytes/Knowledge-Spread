using AutoMapper;
using LearningSystem.Module.Common.Infrastructure;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPath
{
    internal class GetAllLearningPathsQueryHandler : IRequestHandler<GetAllLearningPathsQuery, IList<LearningPathDomainModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllLearningPathsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<LearningPathDomainModel>> Handle(GetAllLearningPathsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IList<LearningPathDomainModel>>(await _unitOfWork.LearningPaths.GetAll(QueryTracking.AsNoTracking));
        }
    }
}
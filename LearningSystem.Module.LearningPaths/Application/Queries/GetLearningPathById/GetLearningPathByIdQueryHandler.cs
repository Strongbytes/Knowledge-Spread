using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Exceptions;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPath
{
    internal class GetLearningPathByIdQueryHandler : IRequestHandler<GetLearningPathByIdQuery, LearningPathDomainModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLearningPathByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LearningPathDomainModel> Handle(GetLearningPathByIdQuery request, CancellationToken cancellationToken)
        {
            LearningPath source = await _unitOfWork.LearningPaths.Get(request.LearningPathId);

            if (source == null)
            {
                throw new LearningPathNotFoundException($"{nameof(GetLearningPathByIdQuery)}, {request.LearningPathId}");
            }

            return _mapper.Map<LearningPathDomainModel>(source);
        }
    }
}
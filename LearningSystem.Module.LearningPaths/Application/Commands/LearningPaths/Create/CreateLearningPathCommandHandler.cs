using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create
{
    internal class CreateLearningPathCommandHandler : IRequestHandler<CreateLearningPathCommand, LearningPathDomainModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLearningPathCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LearningPathDomainModel> Handle(CreateLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath newLearningPath = _mapper.Map<LearningPath>(request.Model);
            _unitOfWork.LearningPaths.Add(newLearningPath);

            await _unitOfWork.Complete();

            return _mapper.Map<LearningPathDomainModel>(newLearningPath);
        }
    }
}
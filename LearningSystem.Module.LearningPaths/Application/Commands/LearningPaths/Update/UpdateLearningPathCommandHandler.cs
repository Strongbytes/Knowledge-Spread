using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Exceptions;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update
{
    internal class UpdateLearningPathCommandHandler : IRequestHandler<UpdateLearningPathCommand, LearningPathDomainModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLearningPathCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LearningPathDomainModel> Handle(UpdateLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath existingLearningPath = await _unitOfWork.LearningPaths.Get(request.LearningPathId);

            if (existingLearningPath == null)
            {
                throw new LearningPathNotFoundException($"{nameof(UpdateLearningPathCommand)}, {request.LearningPathId}");
            }

            _mapper.Map(request.Model, existingLearningPath);

            await _unitOfWork.Complete();
            return _mapper.Map<LearningPathDomainModel>(existingLearningPath);
        }
    }
}
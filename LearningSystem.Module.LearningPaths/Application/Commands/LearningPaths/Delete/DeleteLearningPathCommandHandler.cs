using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Delete
{
    internal class DeleteLearningPathCommandHandler : IRequestHandler<DeleteLearningPathCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLearningPathCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath source = await _unitOfWork.LearningPaths.Get(request.LearningPathId);

            if (source == null)
            {
                return Unit.Value;
            }

            _unitOfWork.LearningPaths.Remove(source);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.CreateLearningPath
{
    internal class CreateLearningPathCommandHandler : IRequestHandler<CreateLearningPathCommand, CreateLearningPathResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLearningPathCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateLearningPathResponseModel> Handle(CreateLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath newLearningPath = _mapper.Map<LearningPath>(request.Model);
            _unitOfWork.LearningPaths.Add(newLearningPath);

            await _unitOfWork.Complete();

            return _mapper.Map<CreateLearningPathResponseModel>(newLearningPath);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Module.LearningPath.Domain;
using MediatR;

namespace LearningSystem.Module.LearningPath.Application.Commands.CreateLearningPath
{
    public class CreateLearningPathCommandHandler : IRequestHandler<CreateLearningPathCommand, CreateLearningPathResponse>
    {
        private readonly ILearningPathRepository _repository;
        private readonly IMapper _mapper;

        public CreateLearningPathCommandHandler(ILearningPathRepository repository, IMapper mapper)
        {
            _repository = repository;  
            _mapper = mapper;
        }

        public async Task<CreateLearningPathResponse> Handle(CreateLearningPathCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateLearningPathResponse();
            return response;
        }
    }
}
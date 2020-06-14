using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Module.LearningPath.Domain;
using MediatR;

namespace LearningSystem.Module.LearningPath.Application.Queries.GetLearningPath
{
    public class GetLearningPathQueryHandler : IRequestHandler<GetLearningPathQuery, IList<LearningPathModel>>
    {
        private readonly ILearningPathRepository _repository;
        private readonly IMapper _mapper;

        public GetLearningPathQueryHandler(ILearningPathRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<LearningPathModel>> Handle(GetLearningPathQuery request, CancellationToken cancellationToken)
        {
            var learningPath = await _repository.GetLearningPath(request.UserId);
            var learningPathViewModel = _mapper.Map<IList<LearningPathModel>>(learningPath);
            return learningPathViewModel;
        }
    }
}
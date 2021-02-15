using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPath
{
    public class GetLearningPathByIdQuery : IRequest<LearningPathDomainModel>
    {
        public int LearningPathId { get; set; }

        public GetLearningPathByIdQuery(int learningPathId)
        {
            LearningPathId = learningPathId;
        }
    }
}

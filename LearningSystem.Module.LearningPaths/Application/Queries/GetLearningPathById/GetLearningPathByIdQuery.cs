using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPath
{
    public class GetLearningPathByIdQuery : IRequest<LearningPathDomainModel>
    {
        internal int LearningPathId { get; }

        public GetLearningPathByIdQuery(int learningPathId)
        {
            LearningPathId = learningPathId;
        }
    }
}

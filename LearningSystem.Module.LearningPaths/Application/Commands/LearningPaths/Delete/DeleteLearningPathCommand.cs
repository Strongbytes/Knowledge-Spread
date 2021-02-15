using MediatR;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Delete
{
    public class DeleteLearningPathCommand : IRequest<Unit>
    {
        internal int LearningPathId { get; }

        public DeleteLearningPathCommand(int learningPathId)
        {
            LearningPathId = learningPathId;
        }
    }
}

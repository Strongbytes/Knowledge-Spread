using System;
using MediatR;

namespace LearningSystem.Module.LearningPath.Application.Commands.CreateLearningPath
{
    public class CreateLearningPathCommand : IRequest<CreateLearningPathResponse>
    {
        public CreateLearningPathModel Model { get; }

        public CreateLearningPathCommand(CreateLearningPathModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}

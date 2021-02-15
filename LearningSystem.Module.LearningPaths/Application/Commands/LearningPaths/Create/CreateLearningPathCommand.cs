using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.CreateLearningPath
{
    public class CreateLearningPathCommand : IRequest<CreateLearningPathResponseModel>
    {
        public CreateLearningPathRequestModel Model { get; }

        public CreateLearningPathCommand(CreateLearningPathRequestModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}

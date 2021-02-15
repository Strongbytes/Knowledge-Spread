using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update
{
    public class UpdateLearningPathCommand : IRequest<LearningPathDomainModel>
    {
        internal UpdateLearningPathRequestModel Model { get; }

        internal int LearningPathId { get; }

        public UpdateLearningPathCommand(int learningPathId, UpdateLearningPathRequestModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            LearningPathId = learningPathId;
        }
    }
}

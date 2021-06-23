using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update
{
    public class UpdateLearningPathCommand : IRequest<LearningPathDomainModel>
    {
        internal UpdateLearningPathRequestModel Model { get; }

        internal int Id { get; }

        public UpdateLearningPathCommand(int id, UpdateLearningPathRequestModel model)
        {
            Id = id;
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
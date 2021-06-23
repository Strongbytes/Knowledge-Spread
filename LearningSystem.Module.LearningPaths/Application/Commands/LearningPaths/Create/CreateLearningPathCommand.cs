using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create
{
    public class CreateLearningPathCommand : IRequest<LearningPathDomainModel>
    {
        internal CreateLearningPathRequestModel Model { get; }

        public CreateLearningPathCommand(CreateLearningPathRequestModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
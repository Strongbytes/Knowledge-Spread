using LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Update.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Update
{
    public class UpdateTutorialCommand : IRequest<TutorialDomainModel>
    {
        internal UpdateTutorialRequestModel Model { get; }

        internal int Id { get; }

        public UpdateTutorialCommand(int id, UpdateTutorialRequestModel model)
        {
            Id = id;
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
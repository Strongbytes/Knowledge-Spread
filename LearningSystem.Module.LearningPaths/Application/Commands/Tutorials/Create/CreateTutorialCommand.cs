using LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Create.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Create
{
    public class CreateTutorialCommand : IRequest<TutorialDomainModel>
    {
        internal CreateTutorialRequestModel Model { get; }

        public CreateTutorialCommand(CreateTutorialRequestModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
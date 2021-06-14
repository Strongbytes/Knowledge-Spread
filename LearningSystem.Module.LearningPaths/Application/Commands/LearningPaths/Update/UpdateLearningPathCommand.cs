using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update
{
    public class UpdateLearningPathCommand : IRequest<LearningPathDomainModel>
    {
        internal UpdateLearningPathRequestModel Model { get; set; }

        internal int Id { get; set; }

        public UpdateLearningPathCommand(int id, UpdateLearningPathRequestModel model)
        {
            Id = id;
            Model = model;
        }
    }
}
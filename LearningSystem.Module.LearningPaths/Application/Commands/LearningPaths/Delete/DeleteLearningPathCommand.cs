using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Delete
{
    public class DeleteLearningPathCommand : IRequest<Unit>
    {
        internal int Id { get; set; }

        public DeleteLearningPathCommand(int id)
        {
            Id = id;
        }
    }
}
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Delete
{
    public class DeleteTutorialCommand : IRequest<Unit>
    {
        internal int Id { get; }

        public DeleteTutorialCommand(int id)
        {
            Id = id;
        }
    }
}
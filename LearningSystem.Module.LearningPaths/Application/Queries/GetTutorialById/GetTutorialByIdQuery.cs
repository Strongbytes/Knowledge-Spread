using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetTutorialById
{
    public class GetTutorialByIdQuery : IRequest<TutorialDomainModel>
    {
        internal int Id { get; }

        public GetTutorialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
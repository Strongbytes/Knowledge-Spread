using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPathById
{
    public class GetLearningPathByIdQuery : IRequest<LearningPathDomainModel>
    {
        internal int Id { get; set; }

        public GetLearningPathByIdQuery(int id)
        {
            Id = id;
        }
    }
}
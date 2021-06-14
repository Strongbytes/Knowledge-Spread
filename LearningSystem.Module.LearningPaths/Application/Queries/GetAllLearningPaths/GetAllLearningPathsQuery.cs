using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetAllLearningPaths
{
    public class GetAllLearningPathsQuery : IRequest<IEnumerable<LearningPathDomainModel>>
    {
    }
}
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPath
{
    public class GetAllLearningPathsQuery : IRequest<IList<LearningPathDomainModel>>
    {
    }
}

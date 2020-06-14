using System;
using System.Collections.Generic;
using MediatR;

namespace LearningSystem.Module.LearningPath.Application.Queries.GetLearningPath
{
    public class GetLearningPathQuery : IRequest<IList<LearningPathModel>>
    {
        public Guid UserId { get; set; }
        public GetLearningPathQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}

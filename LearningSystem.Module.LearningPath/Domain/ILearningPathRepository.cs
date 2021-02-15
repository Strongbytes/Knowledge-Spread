using LearningSystem.Module.LearningPath.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPath.Domain
{
    public interface ILearningPathRepository
    {
        Task<IList<LearningPathData>> GetLearningPath(Guid userId);
    }
}

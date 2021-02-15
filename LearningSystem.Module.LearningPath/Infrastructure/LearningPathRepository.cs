using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningSystem.Module.LearningPath.Domain;
using LearningSystem.Module.LearningPath.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Module.LearningPath.Infrastructure
{
    public class LearningPathRepository : ILearningPathRepository
    {
        private readonly LearningPathDbContext _learningPathDbContext;

        public LearningPathRepository(LearningPathDbContext learningPathDbContext)
        {
            _learningPathDbContext = learningPathDbContext;
        }

        public async Task<IList<LearningPathData>> GetLearningPath(Guid userId)
        {
            return await _learningPathDbContext.LearningPathData.Where(x => x.Id == userId).ToListAsync();
        }
    }
}

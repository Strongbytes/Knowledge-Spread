using LearningSystem.Module.Common.Infrastructure;
using LearningSystem.Module.Data.DatabaseContexts;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain.Repositories;

namespace LearningSystem.Module.LearningPaths.Infrastructure.Repositories
{
    internal class LearningPathsRepository : BaseRepository<LearningPath>, ILearningPathsRepository
    {
        public LearningPathsRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
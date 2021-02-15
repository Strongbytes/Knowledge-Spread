using LearningSystem.Module.Common.Infrastructure;
using LearningSystem.Module.LearningPaths.Domain.Repositories;

namespace LearningSystem.Module.LearningPaths.Domain
{
    internal interface IUnitOfWork : IBaseUnitOfWork
    {
        ILearningPathRepository LearningPaths { get; }
    }
}

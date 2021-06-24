using LearningSystem.Module.Common.Infrastructure;
using LearningSystem.Module.Data.DatabaseContexts;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Repositories;
using System;

namespace LearningSystem.Module.LearningPaths.Infrastructure
{
    internal class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public ILearningPathsRepository LearningPaths { get; internal set; }

        public ITutorialsRepository Tutorials { get; internal set; }

        public UnitOfWork(ApplicationDbContext context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {}
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearningSystem.Module.LearningPath.Infrastructure
{
    public class LearningPathDbContextFactory : IDesignTimeDbContextFactory<LearningPathDbContext>
    {
        public LearningPathDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine("Enter Connection string: ");
            var connectionString = Console.ReadLine();

            var optionsBuilder = new DbContextOptionsBuilder<LearningPathDbContext>();
            optionsBuilder.UseSqlServer(connectionString ?? throw new InvalidOperationException(), options =>
            {
                options.MigrationsHistoryTable("__EFMigrationsHistory_LearningSystem_History", "dbo");
                options.EnableRetryOnFailure();
            });

            return new LearningPathDbContext(optionsBuilder.Options);
        }
    }
}

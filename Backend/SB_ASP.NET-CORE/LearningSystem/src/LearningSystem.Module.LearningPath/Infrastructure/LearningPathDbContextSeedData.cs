using LearningSystem.Module.LearningPath.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LearningSystem.Module.LearningPath.Infrastructure
{
    internal static class LearningPathDbContextSeedData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LearningPathData>()
                .HasData(new[] {
                    new LearningPathData() { Id = Guid.NewGuid() }
                });
        }
    }
}

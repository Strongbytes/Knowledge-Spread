using LearningSystem.Module.LearningPath.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Module.LearningPath.Infrastructure
{
    public class LearningPathDbContext : DbContext
    {
        public LearningPathDbContext(DbContextOptions<LearningPathDbContext> options) : base(options)
        {
        }

        public DbSet<LearningPathData> LearningPathData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LearningPathData>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<LearningPathData>()
                .ToTable("LearningSystem_LearningPath", "dbo");
        }
    }
}

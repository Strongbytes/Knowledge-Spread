using LearningSystem.Module.UserProfile.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Module.UserProfile.Infrastructure
{
    public class UserProfileDbContext : DbContext
    {
        public UserProfileDbContext(DbContextOptions<UserProfileDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfileData> UserProfileData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfileData>()
                .ToTable("LearningSystem_UserProfile", "dbo");
           
        }
    }
}

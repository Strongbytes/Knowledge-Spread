using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearningSystem.Module.UserProfile.Infrastructure
{
    public class UserProfileDbContextFactory: IDesignTimeDbContextFactory<UserProfileDbContext>
    {
        public UserProfileDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine("Enter Connection string: ");
            var connectionString = Console.ReadLine();

            var optionsBuilder = new DbContextOptionsBuilder<UserProfileDbContext>();
            optionsBuilder.UseSqlServer(connectionString ?? throw new InvalidOperationException(), options =>
            {
                options.MigrationsHistoryTable("__EFMigrationsHistory_LearningSystem__UserProfile", "dbo");
                options.EnableRetryOnFailure(); 
            });

            return new UserProfileDbContext(optionsBuilder.Options);
        }
    }
}

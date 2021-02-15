using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LearningSystem.Module.Data.DatabaseContexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        internal const string DefaultMigrationsTable = "__EFMigrationsHistory";

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @".\Resources"))
                    .AddJsonFile("designtime.json", optional: false)
                    .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), options =>
            {
                options.MigrationsHistoryTable(DefaultMigrationsTable, "dbo");
                options.EnableRetryOnFailure();
            });

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

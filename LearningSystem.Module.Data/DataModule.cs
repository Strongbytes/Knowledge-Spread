using Autofac;
using LearningSystem.Module.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LearningSystem.Module.Data
{
    public class DataModule : Autofac.Module
    {
        private readonly DataConfiguration _configuration;

        public DataModule(IConfiguration configuration)
        {
            _configuration = new DataConfiguration(configuration);
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterConfigurations(builder);

            RegisterDbContext(builder);
        }

        private static void RegisterConfigurations(ContainerBuilder builder)
        {
            builder.RegisterType<DataConfiguration>()
                   .AsSelf()
                   .SingleInstance();
        }

        private void RegisterDbContext(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                DbContextOptionsBuilder<ApplicationDbContext> dbContextBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                dbContextBuilder.UseSqlServer(_configuration.GetDatabaseConnectionString(), options =>
                {
                    options.MigrationsHistoryTable(ApplicationDbContextFactory.DefaultMigrationsTable, "dbo");
                    options.EnableRetryOnFailure();
                });

                return new ApplicationDbContext(dbContextBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }
    }
}
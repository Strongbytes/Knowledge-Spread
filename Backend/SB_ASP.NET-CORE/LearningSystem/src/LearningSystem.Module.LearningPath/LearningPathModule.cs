using Autofac;
using FluentValidation;
using LearningSystem.Module.LearningPath.Domain;
using LearningSystem.Module.LearningPath.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LearningSystem.Module.LearningPath
{
    public class LearningPathModule : Autofac.Module
    {
        private readonly LearningPathConfiguration _configuration;

        public LearningPathModule(LearningPathConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterInstance(_configuration).SingleInstance();
            builder.RegisterType<LearningPathRepository>()
                .As<ILearningPathRepository>()
                .InstancePerDependency();

            builder.Register(c =>
            {
                var dbContextBuilder = new DbContextOptionsBuilder<LearningPathDbContext>();
                dbContextBuilder
                    .UseSqlServer(_configuration.GetConnectionString(), options =>
                    {
                        options.MigrationsHistoryTable("__EFMigrationsHistory_LearningSystem__LearningPath", "dbo");
                        options.EnableRetryOnFailure(); 
                    });
                return new LearningPathDbContext(dbContextBuilder.Options);
            }).AsSelf().InstancePerDependency();

            var moduleAssembly = typeof(LearningPathModule).GetTypeInfo().Assembly;

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(moduleAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder
                .RegisterAssemblyTypes(moduleAssembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
        }
    }
}
using Autofac;
using FluentValidation;
using LearningSystem.Module.UserProfile.Domain;
using LearningSystem.Module.UserProfile.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LearningSystem.Module.UserProfile
{
    public class UserProfileModule : Autofac.Module
    {
        private readonly UserProfileConfiguration _configuration;

        public UserProfileModule(UserProfileConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterInstance(_configuration).SingleInstance();
            builder.RegisterType<UserProfileRepository>()
                .As<IUserProfileRepository>()
                .InstancePerDependency();

            builder.Register(c =>
            {
                var dbContextBuilder = new DbContextOptionsBuilder<UserProfileDbContext>();
                dbContextBuilder
                    .UseSqlServer(_configuration.GetConnectionString(), options =>
                    {
                        options.MigrationsHistoryTable("__EFMigrationsHistory_LearningSystem__UserProfile", "dbo");
                        options.EnableRetryOnFailure(); 
                    });
                return new UserProfileDbContext(dbContextBuilder.Options);
            }).AsSelf().InstancePerDependency();

            var moduleAssembly = typeof(UserProfileModule).GetTypeInfo().Assembly;

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
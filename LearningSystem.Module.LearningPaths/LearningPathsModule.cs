using Autofac;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Repositories;
using LearningSystem.Module.LearningPaths.Infrastructure;
using LearningSystem.Module.LearningPaths.Infrastructure.Repositories;
using LearningSystem.Module.Common.Extensions;
using LearningSystem.Module.Data;
using LearningSystem.Module.LearningPaths.Services;

namespace LearningSystem.Module.LearningPaths
{
    public class LearningPathsModule : Autofac.Module
    {
        private static void RegisterConfigurations(ContainerBuilder builder)
        {
            builder.RegisterType<LearningPathsConfiguration>().AsSelf().SingleInstance();
            builder.RegisterType<DataConfiguration>().AsSelf().SingleInstance();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ThirdPartyService>().As<IThirdPartyService>().InstancePerDependency();
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterUnitOfWorkRepositories(builder);
            builder.RegisterCommandHandlersAndValidators(ThisAssembly);
            builder.RegisterProfile(ThisAssembly);
            RegisterConfigurations(builder);
            RegisterServices(builder);
        }

        private void RegisterUnitOfWorkRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                  .As<IUnitOfWork>()
                  .InstancePerLifetimeScope();

            builder.RegisterType<TutorialsRepository>()
                   .As<ITutorialsRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<LearningPathsRepository>()
                   .As<ILearningPathsRepository>()
                   .InstancePerLifetimeScope();
        }
    }
}
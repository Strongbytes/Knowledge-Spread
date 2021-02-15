using Autofac;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Reflection;

namespace LearningSystem.Module.Common.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterCommandHandlersAndValidators(this ContainerBuilder builder, Assembly moduleAssembly)
        {
            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(moduleAssembly)
                   .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder.RegisterAssemblyTypes(moduleAssembly)
                   .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                   .AsImplementedInterfaces();
        }

        public static void RegisterProfile(this ContainerBuilder builder, Assembly moduleAssembly)
        {
            builder.RegisterAssemblyTypes(moduleAssembly).AssignableTo(typeof(Profile)).As<Profile>();

            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(ctx.Resolve);

                foreach (Profile profile in ctx.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            }));
        }
    }
}

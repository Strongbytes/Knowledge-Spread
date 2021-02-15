using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;

namespace LearningSystem.Web
{
    public class AutoMapperModule : Autofac.Module
    {
        private readonly IEnumerable<Assembly> assembliesToScan;
        public AutoMapperModule(IEnumerable<Assembly> assembliesToScan)
        {
            this.assembliesToScan = assembliesToScan;
        }

        public AutoMapperModule(params Assembly[] assembliesToScan) : this((IEnumerable<Assembly>)assembliesToScan) { }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg => cfg.AddMaps(assembliesToScan)));
            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).InstancePerDependency();
        }
    }
}

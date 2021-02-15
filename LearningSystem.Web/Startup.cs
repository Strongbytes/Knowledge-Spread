using Autofac;
using AutoMapper;
using LearningSystem.Module.Data;
using LearningSystem.Module.LearningPaths;
using LearningSystem.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LearningSystem
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_configuration);

            services.AddCors();

            services.ConfigureControllers();

            services.ConfigureApiVersioning();

            services.ConfigureSwagger();

            services.AddMediatR(GetType().Assembly);

            services.ConfigurePipeline();

            services.AddRouting(options => options.LowercaseUrls = true);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<AutoMapper.IConfigurationProvider>(), ctx.Resolve))
                   .InstancePerDependency();

            builder.RegisterModule(new DataModule(_configuration));
            builder.RegisterModule<LearningPathsModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.ConfigureCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.ConfigureSwaggerUI();

            app.ConfigureEndpoints(_configuration);
        }
    }
}

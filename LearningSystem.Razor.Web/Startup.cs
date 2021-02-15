using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using LearningSystem.Module.LearningPath;
using LearningSystem.Module.UserProfile;
using LearningSystem.Razor.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LearningSystem.Razor.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddSingleton(typeof(IAsyncActionFilter), typeof(BusinessExceptionFilter));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register<AutoMapper.IConfigurationProvider>(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new Profile[] {
                    new LearningPathMapper(),
                    new UserProfileMapper(),
                });
            }));

            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<AutoMapper.IConfigurationProvider>(), ctx.Resolve))
                .InstancePerDependency();

            builder.RegisterModule(new UserProfileModule(new UserProfileConfiguration(Configuration.GetSection("Modules:UserProfile"))));
            builder.RegisterModule(new LearningPathModule(new LearningPathConfiguration(Configuration.GetSection("Modules:Organization"))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

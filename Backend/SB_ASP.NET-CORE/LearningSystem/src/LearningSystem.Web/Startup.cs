using System.Reflection;
using System.Threading.Tasks;
using LearningSystem.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using MediatR;
using AutoMapper;
using LearningSystem.Module.UserProfile;
using LearningSystem.Module.LearningPath;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using LearningSystem.Web;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem
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
            services.AddControllers();

            services.AddApiVersioning(options => {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(
                 options =>
                 {
                     // note: the specified format code will format the version as "'v'major[.minor][-status]"
                     options.GroupNameFormat = "'v'VVV";
                     // note: this option is only necessary when versioning by url segment.
                     options.SubstituteApiVersionInUrl = true;
                 });
            services.AddSwaggerGen();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add(typeof(BusinessExceptionFilter));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
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

            // register container dependencies
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning System (v1)");
            });

            app.UseMvc();
        }
    }
}

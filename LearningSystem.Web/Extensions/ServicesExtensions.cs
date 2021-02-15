using FluentValidation.AspNetCore;
using LearningSystem.Module.Common.Filters;
using LearningSystem.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Linq;

namespace LearningSystem.Web.Extensions
{
    internal static class ServicesExtensions
    {
        internal static void ConfigureLocalization(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                CultureInfo[] supportedCultures = new[]
                {
                    new CultureInfo("en") { NumberFormat = CultureInfo.InvariantCulture.NumberFormat },
                    new CultureInfo("de") { NumberFormat = CultureInfo.InvariantCulture.NumberFormat }
                };

                options.DefaultRequestCulture = new RequestCulture(supportedCultures.First());
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
        }

        internal static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });

                c.OperationFilter<AddAcceptLanguageHeaderFilter>();
            });
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(typeof(BusinessExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest)
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
              .AddDataAnnotationsLocalization()
              .AddNewtonsoftJson(options =>
              {
                  options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                  options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                  options.SerializerSettings.Converters.Add(new StringEnumConverter());
                  options.SerializerSettings.Culture = CultureInfo.InvariantCulture;
              });
        }

        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new HeaderApiVersionReader("API-Version");
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";
                // note: this option is only necessary when versioning by url segment.
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void ConfigurePipeline(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddSingleton(typeof(IAsyncActionFilter), typeof(BusinessExceptionFilter));
        }
    }
}

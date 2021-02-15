using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace LearningSystem.Web.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        internal static void ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .WithExposedHeaders("x-ms-request-id", "content-disposition"));
        }

        internal static void ConfigureEndpoints(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        internal static void ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning System (v1)");
            });
        }
    }
}

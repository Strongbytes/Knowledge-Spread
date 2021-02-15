using LearningSystem.Module.Common.Infrastructure;
using LearningSystem.Module.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LearningSystem.Module.Data.Extensions
{
    public static class IHostExtensions
    {
        public static IHost CreateAndMigrateStorageData(this IHost host)
        {
            using IServiceScope scope = host.Services.CreateScope();
            scope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();

            foreach (IDataSeedService dataSeedService in scope.ServiceProvider.GetServices<IDataSeedService>())
            {
                dataSeedService.EnsureDataIsSeed();
            }

            return host;
        }
    }
}

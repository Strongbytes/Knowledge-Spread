using Microsoft.Extensions.Configuration;

namespace LearningSystem.Module.Data
{
    public class DataConfiguration
    {
        private readonly IConfigurationSection _configuration;

        public DataConfiguration(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("Modules:Data");
        }

        public string GetDatabaseConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
using Microsoft.Extensions.Configuration;

namespace LearningSystem.Module.LearningPath
{
    public class LearningPathConfiguration
    {
        private readonly IConfigurationSection _configuration;

        public LearningPathConfiguration(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
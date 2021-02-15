using Microsoft.Extensions.Configuration;

namespace LearningSystem.Module.LearningPaths
{
    public class LearningPathsConfiguration
    {
        private readonly IConfigurationSection _configuration;

        public LearningPathsConfiguration(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }
    }
}
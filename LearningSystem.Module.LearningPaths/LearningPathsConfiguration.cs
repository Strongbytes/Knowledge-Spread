using Microsoft.Extensions.Configuration;

namespace LearningSystem.Module.LearningPaths
{
    public class LearningPathsConfiguration
    {
        private readonly IConfigurationSection _configuration;

        public LearningPathsConfiguration(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("Modules:LearningPaths");
        }

        public string GetThirdPartyServiceClientId()
        {
            return _configuration["ThirdPartyProvider:ClientId"];
        }

        public string GetThirdPartyServiceClientSecret()
        {
            return _configuration["ThirdPartyProvider:ClientSecret"];
        }
    }
}
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
using Microsoft.Extensions.Configuration;

namespace LearningSystem.Module.UserProfile
{
    public class UserProfileConfiguration
    {
        private readonly IConfigurationSection _configuration;

        public UserProfileConfiguration(IConfigurationSection configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
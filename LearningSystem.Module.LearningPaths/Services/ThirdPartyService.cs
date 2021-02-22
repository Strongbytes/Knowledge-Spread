using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Services
{
    internal class ThirdPartyService : IThirdPartyService
    {
        private readonly LearningPathsConfiguration _learningPathsConfiguration;

        public ThirdPartyService(LearningPathsConfiguration learningPathsConfiguration)
        {
            _learningPathsConfiguration = learningPathsConfiguration;
        }

        public async Task<string> RetrieveAuthorizeToken()
        {
            string clientId = _learningPathsConfiguration.GetThirdPartyServiceClientId();
            string clientSecret = _learningPathsConfiguration.GetThirdPartyServiceClientSecret();

            // use ClientId and ClientSecret to get the auth token instead of this completed task
            return await Task.FromResult(string.Empty);
        }
    }
}

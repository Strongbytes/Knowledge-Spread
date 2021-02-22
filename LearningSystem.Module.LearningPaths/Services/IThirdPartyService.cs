using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Services
{
    interface IThirdPartyService
    {
        public Task<string> RetrieveAuthorizeToken();
    }
}

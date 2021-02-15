using LearningSystem.Module.Common.Models;

namespace LearningSystem.Module.LearningPaths.Domain.Models
{
    public class TutorialDomainModel : BaseDomainResponseModel
    {
        public string Name { get; set; }

        public int LengthInMinutes { get; set; }
    }
}

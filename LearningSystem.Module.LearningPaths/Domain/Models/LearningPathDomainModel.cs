using LearningSystem.Module.Common.Models;
using System.Collections.Generic;

namespace LearningSystem.Module.LearningPaths.Domain.Models
{
    public class LearningPathDomainModel : BaseDomainResponseModel
    {
        public string Title { get; set; }

        public string Platform { get; set; }

        public ICollection<TutorialDomainModel> Tutorials { get; set; } = new HashSet<TutorialDomainModel>();
    }
}

using LearningSystem.Module.Common.Models;
using System.Collections.Generic;

namespace LearningSystem.Module.Data.Models
{
    public class User : BaseDbEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<LearningPath> LearningPaths { get; set; } = new HashSet<LearningPath>();
    }
}

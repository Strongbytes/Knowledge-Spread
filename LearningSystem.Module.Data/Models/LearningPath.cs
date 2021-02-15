using LearningSystem.Module.Common.Models;
using System.Collections.Generic;

namespace LearningSystem.Module.Data.Models
{
    public class LearningPath : BaseDbEntity
    {
        public string Title { get; set; }

        public string Platform { get; set; }

        public virtual ICollection<Tutorial> Tutorials { get; set; } = new HashSet<Tutorial>();
    }
}

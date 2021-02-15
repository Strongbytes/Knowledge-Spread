using LearningSystem.Module.Common.Models;

namespace LearningSystem.Module.Data.Models
{
    public class Tutorial : BaseDbEntity
    {
        public string Name { get; set; }

        public int LengthInMinutes { get; set; }
    }
}

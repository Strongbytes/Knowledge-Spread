using System.Collections.Generic;

namespace LearningSystem.Module.LearningPath.Application.Commands.CreateLearningPath
{
    public class CreateLearningPathResponse
    {
        public IEnumerable<int> PreviousRepairDiagnosisIds { get; set; }
    }
}
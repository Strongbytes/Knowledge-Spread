using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Application.Commands.CreateLearningPath
{
    public class CreateLearningPathRequestModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
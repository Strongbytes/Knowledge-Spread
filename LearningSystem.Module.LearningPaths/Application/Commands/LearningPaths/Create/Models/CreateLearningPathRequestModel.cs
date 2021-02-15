using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Models
{
    public class CreateLearningPathRequestModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
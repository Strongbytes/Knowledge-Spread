using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models
{
    public class UpdateLearningPathRequestModel
    {
        [Required]
        public string Title { get; set; }
    }
}
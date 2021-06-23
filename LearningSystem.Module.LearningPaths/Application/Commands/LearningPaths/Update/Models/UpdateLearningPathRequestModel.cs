using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models
{
    public class UpdateLearningPathRequestModel
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime LastModifiedOn { get; set; }

        public string Title { get; set; }

        public string Platform { get; set; }
    }
}
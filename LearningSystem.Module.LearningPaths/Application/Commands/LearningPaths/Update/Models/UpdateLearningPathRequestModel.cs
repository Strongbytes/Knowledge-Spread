using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models
{
    public class UpdateLearningPathRequestModel
    {
        public string Title { get; set; }

        public string Platform { get; set; }

        [Required]
        public DateTime BaseDbEntityCreatedOn { get; set; }

        [Required]
        public DateTime BaseDbEntityLastModifiedOn { get; set; }
    }
}
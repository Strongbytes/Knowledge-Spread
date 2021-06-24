using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Update.Models
{
    public class UpdateTutorialRequestModel
    {
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastModifiedOn { get; set; }
        public string Name { get; set; }
        public int LengthInMinutes { get; set; }
    }
}
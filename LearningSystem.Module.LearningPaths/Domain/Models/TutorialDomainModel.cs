using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Domain.Models
{
    public class TutorialDomainModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastModifiedOn { get; set; }
        public string Name { get; set; }
        public int LengthInMinutes { get; set; }
    }
}
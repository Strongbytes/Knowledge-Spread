using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Module.LearningPaths.Domain.Models
{
    public class LearningPathDomainModel
    {
        public string Title { get; set; }

        public string Platform { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime LastModifiedOn { get; set; }
    }
}
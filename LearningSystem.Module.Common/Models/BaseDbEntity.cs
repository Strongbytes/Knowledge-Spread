using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.Module.Common.Models
{
    public abstract class BaseDbEntity
    {
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
        public int Id { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime CreatetOn { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime LastModifiedOn { get; set; }
    }
}

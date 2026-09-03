using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class Exam : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string ExamName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string ExamCenter { get; set; } = string.Empty;

        [Required]
        public DateTime ExamSlot { get; set; }
    }
}
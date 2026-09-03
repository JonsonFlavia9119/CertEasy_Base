using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertEasy.Model
{
    public class Application : BaseEntity
    {
        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User? User { get; set; }

        [Required]
        public int CertificationID { get; set; }

        [ForeignKey("CertificationID")]
        public virtual Certification? Certification { get; set; }

        [Required]
        public int StatusID { get; set; }

        [ForeignKey("StatusID")]
        public virtual Status? Status { get; set; }

        public int? ExamID { get; set; }

        [ForeignKey("ExamID")]
        public virtual Exam? Exam { get; set; }

        public string? Remarks { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;
    }
}

using System.ComponentModel.DataAnnotations;

namespace CertEasy.Web.Models
{
    public class ApplicationViewModel
    {
        [Required]
        public int CertificationID { get; set; }

        public int? EducationLevelID { get; set; } // Optional if not required for application entity directly

        [Required]
        public int ExamID { get; set; }

        public string? Remarks { get; set; }
    }
}

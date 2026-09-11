using System.ComponentModel.DataAnnotations;

namespace CertEasy.Web.Models
{
    public class ApplicationViewModel
    {
        [Required]
        public int CertificationID { get; set; }

        [Required(ErrorMessage = "Education Level is required.")]
        public int? EducationLevelID { get; set; }

        [Required]
        public int ExamID { get; set; }

        public string? Remarks { get; set; }
    }
}
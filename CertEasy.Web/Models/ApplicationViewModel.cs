using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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

        public IFormFile? CertificationDocument { get; set; }

        public IFormFile? EducationDocument { get; set; }
    }
}
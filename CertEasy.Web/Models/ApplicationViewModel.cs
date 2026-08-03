using System.ComponentModel.DataAnnotations;

namespace CertEasy.Web.Models
{
    public class ApplicationViewModel
    {
        [Required]
        public int CertificationID { get; set; }

        [Required]
        public int EducationLevelID { get; set; }

        public string Remarks { get; set; }
    }
}
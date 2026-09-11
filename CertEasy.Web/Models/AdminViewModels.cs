using CertEasy.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertEasy.Web.Models
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Application> PendingApplications { get; set; } = new List<Application>();
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
        public IEnumerable<Certification> Certifications { get; set; } = new List<Certification>();
        public IEnumerable<Education> Educations { get; set; } = new List<Education>();
        public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();
    }

    public class EmailConfigurationViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email Provider Name")]
        public string ProviderName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Sender Email")]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Sender Name")]
        public string SenderName { get; set; } = string.Empty;

        [Display(Name = "Resend API Key")]
        [DataType(DataType.Password)]
        public string? ApiKey { get; set; }

        [Display(Name = "Enable SSL")]
        public bool EnableSsl { get; set; }

        public string? MaskedApiKey => !string.IsNullOrEmpty(ApiKey) ? "********" : null;
    }
}
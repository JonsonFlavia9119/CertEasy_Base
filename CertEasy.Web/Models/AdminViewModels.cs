using CertEasy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CertEasy.Web.Models
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Application> PendingApplications { get; set; } = new List<Application>();
        public IEnumerable<Application> CompletedApplications { get; set; } = new List<Application>();
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
        public IEnumerable<Certification> Certifications { get; set; } = new List<Certification>();
        public IEnumerable<Education> Educations { get; set; } = new List<Education>();
        public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();
    }

    public class AssignBadgeViewModel
    {
        public int ApplicationId { get; set; }
        public string UserFullName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string CertificationName { get; set; } = string.Empty;
        public int StatusID { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public DateTime SubmittedDate { get; set; }

        [Required(ErrorMessage = "Badge Name is required.")]
        [Display(Name = "Badge Name")]
        public string BadgeName { get; set; } = string.Empty;

        [Display(Name = "Badge ID")]
        public string? BadgeId { get; set; }
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

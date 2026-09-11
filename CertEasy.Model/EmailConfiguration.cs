using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class EmailConfiguration : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string ProviderName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string SenderName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ApiKey { get; set; }

        public bool EnableSsl { get; set; } = true;
    }
}
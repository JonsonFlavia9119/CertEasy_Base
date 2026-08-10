using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class Address : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Line1 { get; set; }
        [MaxLength(200)]
        public string? Line2 { get; set; }
        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(100)]
        public string State { get; set; }
        [Required, MaxLength(20)]
        public string ZipCode { get; set; }
        [Required, MaxLength(100)]
        public string Country { get; set; }

        // Navigation property
        public virtual ICollection<User>? Users { get; set; }
    }
}
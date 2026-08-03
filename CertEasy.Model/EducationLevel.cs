using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class EducationLevel : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
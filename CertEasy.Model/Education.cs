using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertEasy.Model
{
    [Table("Educations")]
    public class Education : BaseEntity
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(200)]
        public string? InstituteName { get; set; }
    }
}

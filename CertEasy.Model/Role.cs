using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        
        [StringLength(250)]
        public string? Description { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertEasy.Model
{
    public class User : BaseEntity
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }
        public string? PasswordHash { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role? Role { get; set; }

        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public virtual Address? Address { get; set; }

        public int StatusID { get; set; }
        [ForeignKey("StatusID")]
        public virtual Status? Status { get; set; }

        public virtual Account? Account { get; set; }
    }
}

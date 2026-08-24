using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertEasy.Model
{
    public class Account : BaseEntity
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int Status { get; set; }
    }
}

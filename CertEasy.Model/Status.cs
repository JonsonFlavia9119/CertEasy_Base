using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public enum ApplicationStatus
    {
        New = 1,
        UserProfile = 2,
        CertificationSelection = 3,
        EducationalQualification = 4,
        Invoice = 5,
        Review = 6,
        Approved = 7,
        Rejection = 8
    }

    public enum UserRole
    {
        Admin = 1,
        User = 2
    }

    public class Status : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string StatusName { get; set; }
    }
}
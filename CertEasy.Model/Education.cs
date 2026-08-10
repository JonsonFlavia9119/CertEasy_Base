using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class Education : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }

        [Required, MaxLength(200)]
        public string InstitutionName { get; set; }
        [Required, MaxLength(100)]
        public string FieldOfStudy { get; set; }
        public int GraduationYear { get; set; }

        public int EducationLevelId { get; set; }
        public virtual EducationLevel? EducationLevel { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CertEasy.Web.Models
{
    public class ApplyViewModel
    {
        public int CertificationID { get; set; }
        public int EducationLevelID { get; set; }
        public string Remarks { get; set; }
    }

    public class WorkflowStateViewModel
    {
        public int CurrentStep { get; set; }
        public UserProfileViewModel Profile { get; set; }
        // Other steps will be added here
    }

    public class UserProfileViewModel
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required, Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }

    public class SaveStepRequest
    {
        public int StepId { get; set; }
        public string DataJson { get; set; }
    }
}
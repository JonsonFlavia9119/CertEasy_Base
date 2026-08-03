using System.ComponentModel.DataAnnotations;

namespace CertEasy.Web.Models
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "First Name"), StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, Display(Name = "Last Name"), StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password), Display(Name = "Confirm Password"), Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
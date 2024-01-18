using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class RegisterRequest
    {
        [RegularExpression(@"^\b[A-Za-z0-9._%+-]+@vietjetair\.com\b$",
         ErrorMessage = "This must be an email address of Vietjet Air.")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[!@#$%^&*(),.?\"":{}|<>])(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$",
         ErrorMessage = "Password not allow.")]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        [RegularExpression(@"/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/",
        ErrorMessage = "The phone number must be appropriate.")]
        public string PhoneNumber { get; set; }
    }
}

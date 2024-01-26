using System.ComponentModel.DataAnnotations;

namespace Authenticate.Service.DTOs
{
    public class LoginRequest
    {
        [RegularExpression(@"^\b[A-Za-z0-9._%+-]+@vietjetair\.com\b$",
         ErrorMessage = "This must be an email address of Vietjet Air.")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[!@#$%^&*(),.?\"":{}|<>])(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$",
         ErrorMessage = "Password not allow.")]
        public string Password { get; set; }
    }
}

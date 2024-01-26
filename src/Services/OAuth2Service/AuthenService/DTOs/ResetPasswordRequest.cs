using System.ComponentModel.DataAnnotations;

namespace Authenticate.Service.DTOs
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Email { get; set; }

        [Required] 
        public string Password { get; set; }
    }
}

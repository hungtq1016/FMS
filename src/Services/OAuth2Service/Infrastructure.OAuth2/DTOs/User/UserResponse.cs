using Core;

namespace Infrastructure.OAuth2.DTOs
{
    public class UserResponse : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

using Core;

namespace Infrastructure.OAuth2.DTOs
{
    public class GroupResponse : Entity
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}

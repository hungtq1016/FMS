using Core;

namespace Infrastructure.OAuth2.Models.DTOs
{
    public class GroupResponse : Entity
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}

using Core;

namespace Infrastructure.OAuth2.DTOs
{
    public class RoleResponse: Entity
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }
}

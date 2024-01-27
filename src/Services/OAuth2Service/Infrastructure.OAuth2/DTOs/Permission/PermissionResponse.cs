using Core;

namespace Infrastructure.OAuth2.DTOs
{
    public class PermissionResponse : Entity
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}

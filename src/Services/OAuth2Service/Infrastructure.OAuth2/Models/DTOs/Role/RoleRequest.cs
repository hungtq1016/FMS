using Core;

namespace Infrastructure.OAuth2.Models.DTOs
{
    public class RoleRequest : EntityRequest
    {  
        public string Name { get; set; }
        public string Note { get; set; }
    }
}

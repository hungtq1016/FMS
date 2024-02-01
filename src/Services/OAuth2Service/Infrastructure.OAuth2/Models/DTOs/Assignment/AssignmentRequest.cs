
using Core;

namespace Infrastructure.OAuth2.Models.DTOs
{
    public class AssignmentRequest : EntityRequest
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}

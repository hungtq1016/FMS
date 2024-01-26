﻿using Core;

namespace Infrastructure.OAuth2.Models
{
    public class Assignment : EntityRootBase
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}

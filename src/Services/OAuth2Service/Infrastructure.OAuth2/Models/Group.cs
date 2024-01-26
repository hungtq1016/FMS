﻿using Core;

namespace Infrastructure.OAuth2.Models
{
    public class Group : EntityRootBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
﻿using Core;
using System.Text.Json.Serialization;

namespace Infrastructure.OAuth2.Models
{
    public class Assignment : Entity
    {
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}

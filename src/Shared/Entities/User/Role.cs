﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("ROLES")]
    public class Role : AbstractEntity
    {
        [Column("NAME", TypeName = "nvarchar"), MaxLength(100)]
        public string Name { get; set; }

        [Column("DESCRIPTION", TypeName = "nvarchar"), MaxLength(255)]
        public string Description { get; set; }

        public ICollection<UserRole> Users { get; } = new List<UserRole>();
        public ICollection<RolePermission> Permissions { get; } = new List<RolePermission>();
    }
}
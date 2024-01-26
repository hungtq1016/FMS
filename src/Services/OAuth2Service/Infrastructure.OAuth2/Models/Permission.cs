﻿using Core;

namespace Infrastructure.OAuth2.Models
{
    public class Permission: Entity
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}

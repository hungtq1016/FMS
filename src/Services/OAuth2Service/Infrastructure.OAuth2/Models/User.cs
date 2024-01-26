﻿using Core;

namespace Infrastructure.OAuth2.Models
{
    public sealed class User : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? ImageId { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}

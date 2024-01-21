using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    [Table("USERS")]
    public class User : AbstractEntity
    {
        [Column("FULL_NAME", TypeName = "nvarchar"), MaxLength(150)]
        public string FullName { get; set; }

        [Column("USER_NAME", TypeName = "nvarchar"), MaxLength(150)]
        public string UserName { get; set; }

        [Column("EMAIL", TypeName = "nvarchar"), MaxLength(100)]
        public string Email { get; set; }

        [Column("PASSWORD", TypeName = "nvarchar"), MaxLength(255)]
        public string Password { get; set; }

        [Column("PHONE_NUMBER", TypeName = "varchar"), MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Column("REFRESH_TOKEN", TypeName = "nvarchar"), MaxLength(100)]
        public string RefreshToken { get; set; }

        [Column("REFRESH_TOKEN_EXPIRED_TIME")]
        public DateTime RefreshTokenExpiredTime { get; set; }

        public ICollection<UserRole> Roles { get; } = new List<UserRole>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("USER_ROLE")]
    public class UserRole : AbstractEntity
    {
        [Column("USER_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Column("ROLE_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("ROLE_PERMISSION")]
    public class RolePermission : AbstractEntity
    {
        [Column("TYPE", TypeName = "nvarchar"), MaxLength(100)]
        public string Type { get; set; }

        [Column("VALUE", TypeName = "nvarchar"), MaxLength(100)]
        public string Value { get; set; }

        [Column("ROLE_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}

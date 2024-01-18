using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("RESET_PASSWORD")]
    public class ResetPassword : AbstractEntity
    {
        [Column("EMAIL", TypeName = "nvarchar"), MaxLength(100)]
        public string Email { get; set; }

        [Column("EXPIRED_TIME")]
        public DateTime ExpiredTime { get; set; }
    }
}

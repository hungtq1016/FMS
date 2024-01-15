using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Share.Entities
{
    public class Status
    {
        [Key]
        [Column("ID", TypeName = "varchar"), MaxLength(36)]
        public string Id { get; set; }

        [Column("NAME", TypeName = "nvarchar"), MaxLength(100)]
        public string Name { get; set; }

        [Column("HEX_CODE", TypeName = "nvarchar"), MaxLength(10)]
        public string HexCode { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("DOCUMENTS")]
    public class Document : AbstractEntity
    {
        [Column("NAME", TypeName = "nvarchar"), MaxLength(150)]
        public string Name { get; set; }

        [Column("TYPE", TypeName = "nvarchar"), MaxLength(50)]
        public string Type { get; set; }

        [Column("VERSION", TypeName = "nvarchar"), MaxLength(10)]
        public string Version { get; set; }

        [Column("FLIGHT_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("Flight")]
        public string? FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}

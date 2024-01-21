using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("DOCUMENTS")]
    public class Document : AbstractFile
    {
        [Column("TYPE", TypeName = "nvarchar"), MaxLength(50)]
        public string Type { get; set; }

        public ICollection<DocumentVersion> Versions { get; } = new List<DocumentVersion>();

        [Column("FLIGHT_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("Flight")]
        public string? FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}

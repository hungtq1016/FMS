using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    [Table("DOCUMENT_VERSIONS")]
    public class DocumentVersion : AbstractEntity
    {
        [Column("VERSION_NUMBER", TypeName = "nvarchar"), MaxLength(10)]
        public string VersionNumber { get; set; }

        [Column("DOCUMENT_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("Document")]
        public string DocumentId { get; set; }
        public Document Document { get; set; }
    }
}

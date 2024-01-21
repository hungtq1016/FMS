using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("FLIGHTS")]
    public class Flight : AbstractEntity
    {
        [Column("LOADING_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("Loading")]
        public string LoadingId { get; set; }
        public Airport Loading { get; set; }

        [Column("UNLOADING_ID", TypeName = "varchar"), MaxLength(36)]
        [ForeignKey("UnLoading")]
        public string UnloadingId { get; set; }
        public Airport UnLoading { get; set; }

        [Column("STATUS", TypeName = "nvarchar"), MaxLength(100)]
        public string Status { get; set; }

        [Column("DATE_TIME")]
        public DateTime DateTime { get; set; }

        public ICollection<Document> Documents { get; } = new List<Document>();
    }
}

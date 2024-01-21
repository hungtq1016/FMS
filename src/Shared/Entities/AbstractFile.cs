using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public abstract class AbstractFile : AbstractEntity
    {
        [Column("TITLE", TypeName = "nvarchar"), MaxLength(255)]
        public string Title { get; set; }

        [Column("ALT")]
        public string? Alt { get; set; }

        [Column("SIZE")]
        public long Size { get; set; }

        [Column("PATH")]
        public string Path { get; set; }

        [Column("EXTENSION"), MaxLength(10)]
        public string Extension { get; set; }
    }
}

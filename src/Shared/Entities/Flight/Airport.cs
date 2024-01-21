using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("AIRPORTS")]
    public class Airport : AbstractEntity
    {
        [Column("NAME", TypeName = "nvarchar"), MaxLength(150)]
        public string Name { get; set; }

        [Column("CITY", TypeName = "nvarchar"), MaxLength(150)]
        public string City { get; set; }

        [Column("COUNTRY", TypeName = "nvarchar"), MaxLength(150)]
        public string Country { get; set; }

        public ICollection<Flight> LoadingFlights { get; } = new List<Flight>();
        public ICollection<Flight> UnloadingFlights { get; } = new List<Flight>();
    }
}

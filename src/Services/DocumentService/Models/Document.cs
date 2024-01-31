using Core;

namespace DocumentService.Models
{
    public class Document : AbstractFile
    {
        public Guid FlightId { get; set; }
    }
}

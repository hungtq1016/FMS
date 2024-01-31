using Core;

namespace DocumentService.Models.DTOs
{
    public class DocumentRequest
    {
        public string Title { get; set; }

        public string? Alt { get; set; }

        public Guid FlightId { get; set; }
    }
}

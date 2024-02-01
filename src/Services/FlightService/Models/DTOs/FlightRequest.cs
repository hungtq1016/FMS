using Core;

namespace FlightService.Models.DTOs
{
    public class FlightRequest : EntityRequest
    {
        public Guid LoadingId { get; set; }
        public Guid UnloadingId { get; set; }

        public string Route { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}

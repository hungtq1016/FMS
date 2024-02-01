using Core;

namespace FlightService.Models.DTOs
{
    public class AirportRequest : EntityRequest
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ShortName { get; set; }
    }
}

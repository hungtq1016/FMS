using Core;
using System.Text.Json.Serialization;

namespace FlightService.Models
{
    public class Airport : Entity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ShortName { get; set; }

        [JsonIgnore]
        public ICollection<Flight> LoadingFlights { get; } = new List<Flight>();
        [JsonIgnore]

        public ICollection<Flight> UnloadingFlights { get; } = new List<Flight>();
    }
}

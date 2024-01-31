using Infrastructure.EFCore.Data;

namespace FlightService.Infrastructure.Data
{
    public class FlightContextFactory : AppDbContextFactory<FlightContext>
    {
        public FlightContextFactory() : base("flightDB")
        {
        }
    }
}

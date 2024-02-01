using AutoMapper;
using FlightService.Models;
using FlightService.Models.DTOs;

namespace FlightService.Infrastructure.Features
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<FlightRequest, Flight>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Flight, FlightResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AirportRequest, Airport>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Airport, AirportResponse>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

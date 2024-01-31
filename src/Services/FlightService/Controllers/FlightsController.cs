using FlightService.Models;
using FlightService.Models.DTOs;
using Infrastructure.EFCore.Controllers;
using Infrastructure.EFCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ResourceController<Flight, FlightRequest, FlightResponse>
    {
        public FlightsController(IService<Flight, FlightRequest, FlightResponse> service) : base(service)
        {
        }
    }
}

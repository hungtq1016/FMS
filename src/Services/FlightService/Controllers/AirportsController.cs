using FlightService.Models;
using FlightService.Models.DTOs;
using Infrastructure.EFCore.Controllers;
using Infrastructure.EFCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ResourceController<Airport, AirportRequest, AirportResponse>
    {
        public AirportsController(IService<Airport, AirportRequest, AirportResponse> service) : base(service)
        {
        }
    }
}

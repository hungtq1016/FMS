using FlightService.Models;
using FlightService.Models.DTOs;
using Infrastructure.EFCore.Controllers;
using Infrastructure.EFCore.Service;
using Microsoft.AspNetCore.Mvc;
using Ocelot.Values;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ResourceController<Flight, FlightRequest, FlightResponse>
    {
        private readonly IService<Flight, FlightRequest, FlightResponse> _service;
        public FlightsController(IService<Flight, FlightRequest, FlightResponse> service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            var result = await _service.FindAllAsync(properties: new string[]{ "Loading","Unloading"});
            return StatusCode(result.StatusCode, result);
        }
    }
}

using Infrastructure.OAuth2.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        [Permission("permission","Read")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

using Azure.Core;
using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.Filters;
using Infrastructure.OAuth2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IService<Role> _service;
        public RolesController(IService<Role> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.FindAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.FindByIdAsync(id);
            return StatusCode(result.StatusCode,result);
        }

        [HttpDelete("{id}")]
        [Permission("admin", "edit")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [Permission("admin","add")]
        public async Task<IActionResult> Post([FromBody] Role request)
        {
            var result = await _service.AddAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        [Permission("admin", "edit")]
        public async Task<IActionResult> Put([FromBody] Role request)
        {
            var result = await _service.EditAsync(request);
            return StatusCode(result.StatusCode, result);
        }
    }
}

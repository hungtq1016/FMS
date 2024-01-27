using Core;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.EFCore.Service
{
    public abstract class AbstactController<TEntity,TRequest,TResponse> : ControllerBase where TEntity : Entity
    {
        private readonly IService<TEntity,TRequest,TResponse> _service;
        public AbstactController(IService<TEntity,TRequest,TResponse> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _service.FindAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.FindByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TRequest request)
        {
            var result = await _service.AddAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:Guid}")]
        public virtual async Task<IActionResult> Put(Guid id, [FromBody] TRequest request)
        {
            var result = await _service.EditAsync(id,request);
            return StatusCode(result.StatusCode, result);
        }
    }
}

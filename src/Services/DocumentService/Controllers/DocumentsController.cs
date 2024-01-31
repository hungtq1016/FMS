using DocumentService.Infrastructure;
using DocumentService.Models;
using DocumentService.Models.DTOs;
using DocumentService.Models.Enums;
using Infrastructure.EFCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : FileController<Document, DocumentRequest, DocumentResponse, DocumentExtensionsEnum>
    {
        private readonly IDocumentService _service;
        public DocumentsController(IDocumentService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("{flightId:Guid}")]
        public virtual async Task<IActionResult> PostWithFlightID(Guid flightId, List<IFormFile> files)
        {
            var result = await _service.AddWithFlightId(flightId,files);
            return StatusCode(result.StatusCode, result);
        }
    }
}

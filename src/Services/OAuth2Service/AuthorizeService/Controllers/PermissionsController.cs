using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.DTOs;
using Infrastructure.OAuth2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ResourceController<Permission, PermissionRequest, PermissionResponse>
    {
        public PermissionsController(IService<Permission, PermissionRequest,PermissionResponse> service) : base(service)
        {
        }
    }
}

using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.DTOs;
using Infrastructure.OAuth2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ResourceController<Role,RoleRequest,RoleResponse>
    {
        public RolesController(IService<Role,RoleRequest,RoleResponse> service) : base(service)
        {
        }
    }
}

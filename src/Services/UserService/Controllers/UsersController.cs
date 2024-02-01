using Infrastructure.EFCore.Controllers;
using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.Models.DTOs;
using Infrastructure.OAuth2.Filters;
using Infrastructure.OAuth2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ResourceController<User,UserRequest,UserResponse>
    {
        public UsersController(IService<User, UserRequest, UserResponse> service) : base(service)
        {
            
        }
    }
}

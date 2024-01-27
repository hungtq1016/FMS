using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.DTOs;
using Infrastructure.OAuth2.Filters;
using Infrastructure.OAuth2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : AbstactController<User,UserRequest,UserResponse>
    {
        public UsersController(IService<User, UserRequest, UserResponse> service) : base(service)
        {
            
        }

        [Permission("permission","user.add")]
        public override async Task<IActionResult> Post(UserRequest request)
        {
            return await base.Post(request);
        }
    }
}

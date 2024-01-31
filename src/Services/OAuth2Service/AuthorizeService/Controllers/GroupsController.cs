using Infrastructure.EFCore.Controllers;
using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.DTOs;
using Infrastructure.OAuth2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : SingletonController<Group, GroupRequest, GroupResponse>
    {
        public GroupsController(IService<Group, GroupRequest, GroupResponse> service) : base(service)
        {
        }
    }
}

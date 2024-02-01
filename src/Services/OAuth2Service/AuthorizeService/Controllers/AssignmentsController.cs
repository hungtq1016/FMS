using Infrastructure.EFCore.Controllers;
using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.Models;
using Infrastructure.OAuth2.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : SingletonController<Assignment, AssignmentRequest, AssignmentResponse>
    {
        public AssignmentsController(IService<Assignment, AssignmentRequest, AssignmentResponse> service) : base(service)
        {
        }
    }
}

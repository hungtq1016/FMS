using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Infrastructure.Security
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute() : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { };
        }
    }

    public class PermissionFilter : IAsyncAuthorizationFilter
    {
        private readonly SharedContext _context;
        private readonly ILogger<PermissionFilter> _logger;

        public PermissionFilter(SharedContext context, ILogger<PermissionFilter> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity!.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            _logger.LogInformation($"Authorization check for user: {userId}");

            var permission = GetRequestedPermission(context.HttpContext.Request);
            _logger.LogInformation($"Requested permission: {permission}");

            if (!await HasPermission(userId, permission))
            {
                context.Result = new ForbidResult();
                return;
            }
        }

        private string GetRequestedPermission(HttpRequest request)
        {
            request.RouteValues.TryGetValue("controller", out var controllerValue);
            return $"{controllerValue}.{request.Method}";
        }

        private async Task<bool> HasPermission(string userId, string permission)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Roles)
                .SelectMany(ur => ur.Role.Permissions)
                .AnyAsync(p => (p.Type == "permission" && p.Value == permission) ||
                               (p.Type == "Admin" && p.Value == "All"));
        }
    }
}

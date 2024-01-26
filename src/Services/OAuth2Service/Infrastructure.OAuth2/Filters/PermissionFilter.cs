using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Infrastructure.OAuth2.Data;
using Microsoft.Extensions.Caching.Memory;
using Infrastructure.OAuth2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.OAuth2.Filters
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(string type = null, string value = null) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { type, value };
        }
    }

    public class PermissionFilter : IAsyncAuthorizationFilter
    {
        private readonly OAuth2Context _context;
        private readonly ILogger<PermissionFilter> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly string _type;
        private readonly string _value;

        public PermissionFilter(string type, string value, OAuth2Context context, ILogger<PermissionFilter> logger, IMemoryCache memoryCache)
        {
            _type = type;
            _value = value;
            _context = context;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!IsAuthenticated(context, userId)) return;

            var permission = $"{context.HttpContext.Request.RouteValues["controller"]}.{context.HttpContext.Request.Method}";

            if (!await HasPermission(new Guid(userId), permission))
            {
                context.Result = new ForbidResult();
            }
        }

        private bool IsAuthenticated(AuthorizationFilterContext context, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
                return false;
            }
            return true;
        }

        private async Task<bool> HasPermission(Guid userId, string permission)
        {
            if (!_memoryCache.TryGetValue(userId, out List<Permission> permissions))
            {
                permissions = await LoadPermissionsFromDb(userId);
                _memoryCache.Set(userId, permissions);
            }

            return CheckPermission(permissions, permission);
        }

        private async Task<List<Permission>> LoadPermissionsFromDb(Guid userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Groups)
                .SelectMany(g => g.Role.Assignments)
                .Select(a => a.Permission)
                .Distinct()
                .ToListAsync();
        }

        private bool CheckPermission(List<Permission> permissions, string permission)
        {
            var permissionLower = permission.ToLower();
            return permissions.Any(p =>
                (p.Type.ToLower() == "controller" && p.Value.ToLower() == permissionLower) ||
                (p.Type.ToLower() == _type?.ToLower() && p.Value.ToLower() == _value?.ToLower()) ||
                (p.Type.ToLower() == "admin" && p.Value.ToLower() == "all"));
        }
    }
}

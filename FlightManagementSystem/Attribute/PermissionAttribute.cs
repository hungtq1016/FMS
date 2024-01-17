using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightManagementSystem.Attribute
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute() : base(typeof(PermissionFilter))
        {
            Arguments = new string[] { };
        }
    }

    public class PermissionFilter : IAuthorizationFilter
    {

        public PermissionFilter() { }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity!.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }

}
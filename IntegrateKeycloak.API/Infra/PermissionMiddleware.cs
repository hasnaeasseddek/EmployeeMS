using IntegrateKeycloak.API.Services;
using System.Security.Claims;

namespace IntegrateKeycloak.API.Infra
{
    public class PermissionMiddleware
    {
        //private readonly RequestDelegate _next;

        //public PermissionMiddleware(RequestDelegate next)
        //{
        //    _next = next;
        //}

        //public async Task Invoke(HttpContext context, PermissionService permissionService)
        //{
        //    if (context.User.Identity.IsAuthenticated)
        //    {
        //        var roles = context.User.Claims
        //            .Where(c => c.Type == "realm_access" || c.Type == "resource_access")
        //            .SelectMany(c => c.Value.Split(","))
        //            .ToList();

        //        var permissions = await permissionService.GetPermissionsForRolesAsync(roles);

        //        var claimsIdentity = (ClaimsIdentity)context.User.Identity;
        //        foreach (var permission in permissions)
        //        {
        //            claimsIdentity.AddClaim(new Claim("permission", permission));
        //        }
        //    }

        //    await _next(context);
        //}
    }
}
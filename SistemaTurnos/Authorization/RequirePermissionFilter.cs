using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaTurnos.Common;
using System.Security.Claims;

namespace SistemaTurnos.Authorization
{
    public class RequirePermissionFilter : IAuthorizationFilter
    {
        private readonly Permission _permission;

        public RequirePermissionFilter(Permission permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //valida si existe el rol
            var userRole = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userRole == null || !Enum.TryParse<Role>(userRole, out var role))
            {
                context.Result = new ForbidResult();
                return;
            }
            //valida si existe el permiso en ese rol
            if (!role.HasPermission(_permission))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

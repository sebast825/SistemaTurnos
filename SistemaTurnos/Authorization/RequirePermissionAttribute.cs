using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;

namespace SistemaTurnos.Authorization
{
    public class RequirePermissionAttribute : TypeFilterAttribute
    {
        public RequirePermissionAttribute(Permission permission) : base(typeof(RequirePermissionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}

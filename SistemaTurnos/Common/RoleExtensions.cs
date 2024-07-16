namespace SistemaTurnos.Common
{
    public static class RoleExtensions
    {
        //indica si el permiso esta en el rol
        public static bool HasPermission(this Role role, Permission permission)
        {
            if (RolePermissionMapping.RolePermissions.TryGetValue(role, out var permissions))
            {
                return permissions.Contains(permission);
            }
            return false;
        }
    }
}

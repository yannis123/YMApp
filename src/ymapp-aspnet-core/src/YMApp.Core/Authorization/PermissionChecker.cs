using Abp.Authorization;
using YMApp.Authorization.Roles;
using YMApp.Authorization.Users;

namespace YMApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

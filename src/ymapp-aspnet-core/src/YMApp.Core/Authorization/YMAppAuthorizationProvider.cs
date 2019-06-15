using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using System.Linq;

namespace YMApp.Authorization
{
    public class YMAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了Article 的权限。
            var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

            var entityPermission_user = administration.CreateChildPermission(UserPermissions.Pages_Users, L("Users"));
            entityPermission_user.CreateChildPermission(UserPermissions.Query, L("QueryUser"));
            entityPermission_user.CreateChildPermission(UserPermissions.Create, L("CreateUser"));
            entityPermission_user.CreateChildPermission(UserPermissions.Edit, L("EditUser"));
            entityPermission_user.CreateChildPermission(UserPermissions.Delete, L("DeleteUser"));


            var entityPermission_role = administration.CreateChildPermission(RolePermissions.Pages_Roles, L("Roles"));
            entityPermission_role.CreateChildPermission(RolePermissions.Query, L("QueryRole"));
            entityPermission_role.CreateChildPermission(RolePermissions.Create, L("CreateRole"));
            entityPermission_role.CreateChildPermission(RolePermissions.Edit, L("EditRole"));
            entityPermission_role.CreateChildPermission(RolePermissions.Delete, L("DeleteRole"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, YMAppConsts.LocalizationSourceName);
        }
    }
}

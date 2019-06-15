namespace YMApp.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";
    }

    public class UserPermissions
    {
        public const string Pages_Users = "Pages.Users";
        /// <summary>
        /// Users查询授权
        ///</summary>
        public const string Query = "Pages.Users.Query";

        /// <summary>
        /// Users创建权限
        ///</summary>
        public const string Create = "Pages.Users.Create";

        /// <summary>
        /// Users修改权限
        ///</summary>
        public const string Edit = "Pages.Users.Edit";

        /// <summary>
        /// Users删除权限
        ///</summary>
        public const string Delete = "Pages.Users.Delete";
    }

    public class RolePermissions
    {
        public const string Pages_Roles = "Pages.Roles";
        /// <summary>
        /// Roles查询授权
        ///</summary>
        public const string Query = "Pages.Roles.Query";

        /// <summary>
        /// Roles创建权限
        ///</summary>
        public const string Create = "Pages.Roles.Create";

        /// <summary>
        /// Roles修改权限
        ///</summary>
        public const string Edit = "Pages.Roles.Edit";

        /// <summary>
        /// Roles删除权限
        ///</summary>
        public const string Delete = "Pages.Roles.Delete";
    }
}

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
        /// Users��ѯ��Ȩ
        ///</summary>
        public const string Query = "Pages.Users.Query";

        /// <summary>
        /// Users����Ȩ��
        ///</summary>
        public const string Create = "Pages.Users.Create";

        /// <summary>
        /// Users�޸�Ȩ��
        ///</summary>
        public const string Edit = "Pages.Users.Edit";

        /// <summary>
        /// Usersɾ��Ȩ��
        ///</summary>
        public const string Delete = "Pages.Users.Delete";
    }

    public class RolePermissions
    {
        public const string Pages_Roles = "Pages.Roles";
        /// <summary>
        /// Roles��ѯ��Ȩ
        ///</summary>
        public const string Query = "Pages.Roles.Query";

        /// <summary>
        /// Roles����Ȩ��
        ///</summary>
        public const string Create = "Pages.Roles.Create";

        /// <summary>
        /// Roles�޸�Ȩ��
        ///</summary>
        public const string Edit = "Pages.Roles.Edit";

        /// <summary>
        /// Rolesɾ��Ȩ��
        ///</summary>
        public const string Delete = "Pages.Roles.Delete";
    }
}

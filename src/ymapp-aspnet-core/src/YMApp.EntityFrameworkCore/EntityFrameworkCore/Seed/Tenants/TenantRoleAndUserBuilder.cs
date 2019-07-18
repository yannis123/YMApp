using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using YMApp.Authorization;
using YMApp.Authorization.Roles;
using YMApp.Authorization.Users;
using YMApp.ECommerce.Pictures.Authorization;
using YMApp.ECommerce.Products.Authorization;
using YMApp.ECommerce.Articles.Authorization;
using YMApp.Categorys.Authorization;
using YMApp.DocManage.Documents.Authorization;

namespace YMApp.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly YMAppDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(YMAppDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // Admin role

            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role

            var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == _tenantId && p.RoleId == adminRole.Id)
                .Select(p => p.Name)
                .ToList();

            var permissions = PermissionFinder
                .GetAllPermissions(new YMAppAuthorizationProvider())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                            !grantedPermissions.Contains(p.Name))
                .ToList();

            #region 将新增权限授予Admin

            var picturePermissions = PermissionFinder
                .GetAllPermissions(new PictureAuthorizationProvider()).ToList();
            permissions.AddRange(picturePermissions);

            var productPermissions = PermissionFinder
               .GetAllPermissions(new ProductAuthorizationProvider()).ToList();
            permissions.AddRange(productPermissions);

            var articlePermissions = PermissionFinder
               .GetAllPermissions(new ArticleAuthorizationProvider()).ToList();
            permissions.AddRange(articlePermissions);

            var categoryPermissions = PermissionFinder
              .GetAllPermissions(new CategoryAuthorizationProvider()).ToList();
            permissions.AddRange(categoryPermissions);

            var documentPermissions = PermissionFinder
            .GetAllPermissions(new DocumentAuthorizationProvider()).ToList();
            permissions.AddRange(documentPermissions);

            #endregion

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = adminRole.Id
                    })
                );
                _context.SaveChanges();
            }

            // Admin user

            var adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == AbpUserBase.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com");
                adminUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(adminUser, "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }
        }
    }
}



using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using YMApp.Authorization;

namespace YMApp.Categorys.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="DocumentPermissions" /> for all permission names. Document
    ///</summary>
    public class CategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CategoryAuthorizationProvider()
		{

		}

        public CategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Document 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(CategoryPermissions.Node , L("Category"));
			entityPermission.CreateChildPermission(CategoryPermissions.Query, L("QueryCategory"));
			entityPermission.CreateChildPermission(CategoryPermissions.Create, L("CreateCategory"));
			entityPermission.CreateChildPermission(CategoryPermissions.Edit, L("EditCategory"));
			entityPermission.CreateChildPermission(CategoryPermissions.Delete, L("DeleteCategory"));
			entityPermission.CreateChildPermission(CategoryPermissions.BatchDelete, L("BatchDeleteCategory"));
			entityPermission.CreateChildPermission(CategoryPermissions.ExportExcel, L("ExportExcelCategory"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, YMAppConsts.LocalizationSourceName);
		}
    }
}
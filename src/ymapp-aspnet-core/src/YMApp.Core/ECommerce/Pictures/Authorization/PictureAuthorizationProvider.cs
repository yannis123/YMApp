

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using YMApp.Authorization;

namespace YMApp.ECommerce.Pictures.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="PicturePermissions" /> for all permission names. Picture
    ///</summary>
    public class PictureAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public PictureAuthorizationProvider()
		{

		}

        public PictureAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public PictureAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Picture 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(PicturePermissions.Node , L("Picture"));
			entityPermission.CreateChildPermission(PicturePermissions.Query, L("QueryPicture"));
			entityPermission.CreateChildPermission(PicturePermissions.Create, L("CreatePicture"));
			entityPermission.CreateChildPermission(PicturePermissions.Edit, L("EditPicture"));
			entityPermission.CreateChildPermission(PicturePermissions.Delete, L("DeletePicture"));
			entityPermission.CreateChildPermission(PicturePermissions.BatchDelete, L("BatchDeletePicture"));
			entityPermission.CreateChildPermission(PicturePermissions.ExportExcel, L("ExportExcelPicture"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, YMAppConsts.LocalizationSourceName);
		}
    }
}
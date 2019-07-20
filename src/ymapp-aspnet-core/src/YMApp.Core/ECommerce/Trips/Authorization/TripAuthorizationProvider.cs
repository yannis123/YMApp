

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using YMApp.Authorization;

namespace YMApp.ECommerce.Trips.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="TripPermissions" /> for all permission names. Trip
    ///</summary>
    public class TripAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public TripAuthorizationProvider()
		{

		}

        public TripAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public TripAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Trip 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(TripPermissions.Node , L("Trip"));
			entityPermission.CreateChildPermission(TripPermissions.Query, L("QueryTrip"));
			entityPermission.CreateChildPermission(TripPermissions.Create, L("CreateTrip"));
			entityPermission.CreateChildPermission(TripPermissions.Edit, L("EditTrip"));
			entityPermission.CreateChildPermission(TripPermissions.Delete, L("DeleteTrip"));
			entityPermission.CreateChildPermission(TripPermissions.BatchDelete, L("BatchDeleteTrip"));
			entityPermission.CreateChildPermission(TripPermissions.ExportExcel, L("ExportExcelTrip"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, YMAppConsts.LocalizationSourceName);
		}
    }
}
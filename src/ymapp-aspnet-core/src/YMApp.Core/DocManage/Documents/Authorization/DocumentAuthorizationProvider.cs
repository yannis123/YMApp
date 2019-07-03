

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using YMApp.Authorization;

namespace YMApp.DocManage.Documents.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="DocumentPermissions" /> for all permission names. Document
    ///</summary>
    public class DocumentAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public DocumentAuthorizationProvider()
		{

		}

        public DocumentAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public DocumentAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Document 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(DocumentPermissions.Node , L("Document"));
			entityPermission.CreateChildPermission(DocumentPermissions.Query, L("QueryDocument"));
			entityPermission.CreateChildPermission(DocumentPermissions.Create, L("CreateDocument"));
			entityPermission.CreateChildPermission(DocumentPermissions.Edit, L("EditDocument"));
			entityPermission.CreateChildPermission(DocumentPermissions.Delete, L("DeleteDocument"));
			entityPermission.CreateChildPermission(DocumentPermissions.BatchDelete, L("BatchDeleteDocument"));
			entityPermission.CreateChildPermission(DocumentPermissions.ExportExcel, L("ExportExcelDocument"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, YMAppConsts.LocalizationSourceName);
		}
    }
}
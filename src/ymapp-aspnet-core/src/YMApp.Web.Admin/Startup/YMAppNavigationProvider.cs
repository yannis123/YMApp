using Abp.Application.Navigation;
using Abp.Localization;
using YMApp.Authorization;
using YMApp.DocManage.Documents.Authorization;
using YMApp.ECommerce.Products.Authorization;

namespace YMApp.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class YMAppNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                            PageNames.Home,
                            L("HomePage"),
                            url: "",
                            icon: "layui-icon-home",
                            requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            PageNames.Users,
                            L("Users"),
                            url: "",
                            icon: "layui-icon-user",
                            requiresAuthentication: true
                        ).AddItem(
                            new MenuItemDefinition(
                                    PageNames.Users,
                                    L("Users"),
                                    url: "Users",
                                    icon: "people",
                                    requiredPermissionName: UserPermissions.Pages_Users
                                )
                        ).AddItem(
                            new MenuItemDefinition(
                                    PageNames.Roles,
                                    L("Roles"),
                                    url: "Roles",
                                    icon: "local_offer",
                                    requiredPermissionName: RolePermissions.Pages_Roles
                                )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            PageNames.Product,
                            L("Product"),
                            url: "",
                            icon: "layui-icon-app",
                            requiresAuthentication: true
                        ).AddItem(
                            new MenuItemDefinition(
                                    PageNames.Product,
                                    L("Product"),
                                    url: "Product",
                                    icon: "local_offer",
                                    requiredPermissionName: ProductPermissions.Node
                                )
                        )
                ).AddItem(
                    new MenuItemDefinition (
                            PageNames.Document,
                            L("Document"),
                            url: "",
                            icon: "layui-icon-app",
                            requiresAuthentication: true
                        ).AddItem(
                            new MenuItemDefinition (
                                    PageNames.Document,
                                    L("Document"),
                                    url: "Document",
                                    icon: "layui-icon-app",
                                    requiredPermissionName: DocumentPermissions.Node
                                )
                        )
                );


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, YMAppConsts.LocalizationSourceName);
        }
    }
}

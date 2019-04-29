using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using YMApp.Configuration.Dto;

namespace YMApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : YMAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

using System.Threading.Tasks;
using YMApp.Configuration.Dto;

namespace YMApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

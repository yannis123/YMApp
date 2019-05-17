using Abp.AspNetCore.Mvc.ViewComponents;

namespace YMApp.Web.Views
{
    public abstract class YMAppViewComponent : AbpViewComponent
    {
        protected YMAppViewComponent()
        {
            LocalizationSourceName = YMAppConsts.LocalizationSourceName;
        }
    }
}

using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace YMApp.Web.Views
{
    public abstract class YMAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected YMAppRazorPage()
        {
            LocalizationSourceName = YMAppConsts.LocalizationSourceName;
        }
    }
}

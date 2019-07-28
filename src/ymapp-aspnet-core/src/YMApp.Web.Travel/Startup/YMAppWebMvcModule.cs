using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YMApp.Configuration;

namespace YMApp.Web.Startup
{
    [DependsOn(typeof(YMAppWebCoreModule))]
    public class YMAppWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public YMAppWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<YMAppNavigationProvider>();
        }

        public override void Initialize()
        {
            Configuration.Authorization.IsEnabled = false;
            IocManager.RegisterAssemblyByConvention(typeof(YMAppWebMvcModule).GetAssembly());
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YMApp.Configuration;

namespace YMApp.Web.Host.Startup
{
    [DependsOn(
       typeof(YMAppWebCoreModule))]
    public class YMAppWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public YMAppWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YMAppWebHostModule).GetAssembly());
        }
    }
}

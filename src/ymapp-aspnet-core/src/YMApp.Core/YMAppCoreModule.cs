using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using YMApp.Authorization.Roles;
using YMApp.Authorization.Users;
using YMApp.Configuration;
using YMApp.Localization;
using YMApp.MultiTenancy;
using YMApp.Timing;

namespace YMApp
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class YMAppCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            
            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);
                                  
            YMAppLocalizationConfigurer.Configure(Configuration.Localization);
            
            // Enable this line to create a multi-tenant application.
            //Configuration.MultiTenancy.IsEnabled = YMAppConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YMAppCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}

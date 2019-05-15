using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YMApp.Authorization;
using YMApp.Categorys.Mapper;
using YMApp.Trips.Mapper;
using YMApp.ECommerce.Pictures.Mapper;
using YMApp.ECommerce.Products.Mapper;

namespace YMApp
{
    [DependsOn(
        typeof(YMAppCoreModule),
        typeof(AbpAutoMapperModule))]
    public class YMAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<YMAppAuthorizationProvider>();
            Configuration.Authorization.IsEnabled = false;
            //Configuration.MultiTenancy.IsEnabled = false;
            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);
                CategoryMapper.CreateMappings(configuration);
                TripMapper.CreateMappings(configuration);
                PictureMapper.CreateMappings(configuration);
                ProductMapper.CreateMappings(configuration);
            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(YMAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}

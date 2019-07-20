using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YMApp.Authorization;
using YMApp.Categorys.Mapper;
using YMApp.ECommerce.Pictures.Mapper;
using YMApp.ECommerce.Products.Mapper;
using YMApp.ECommerce.Pictures.Authorization;
using YMApp.ECommerce.Products.Authorization;
using YMApp.ECommerce.ProductFields.Mapper;
using YMApp.ECommerce.ProductAttributes.Mapper;
using YMApp.ECommerce.Articles.Mapper;
using YMApp.ECommerce.Articles.Authorization;
using YMApp.DocManage.Documents.Authorization;
using YMApp.DocManage.Documents.Mapper;
using Abp.Localization;
using YMApp.Categorys.Authorization;
using YMApp.ECommerce.Trips.Authorization;
using YMApp.ECommerce.Trips.Mapper;

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
            Configuration.Authorization.Providers.Add<CategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PictureAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ProductAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ArticleAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<DocumentAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<TripAuthorizationProvider>();
            //Configuration.Authorization.IsEnabled = false;
            //Configuration.MultiTenancy.IsEnabled = false;

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);
                CategoryMapper.CreateMappings(configuration);
                PictureMapper.CreateMappings(configuration);
                ProductMapper.CreateMappings(configuration);
                ProductFieldMapper.CreateMappings(configuration);
                ProductAttributeMapper.CreateMappings(configuration);
                ArticleMapper.CreateMappings(configuration);
                DocumentMapper.CreateMappings(configuration);
                TripMapper.CreateMappings(configuration);
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

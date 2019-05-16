
using AutoMapper;
using YMApp.ECommerce.ProductFields;
using YMApp.ECommerce.ProductFields.Dtos;

namespace YMApp.ECommerce.ProductFields.Mapper
{

	/// <summary>
    /// 配置ProductField的AutoMapper
    /// </summary>
	internal static class ProductFieldMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ProductField,ProductFieldListDto>();
            configuration.CreateMap <ProductFieldListDto,ProductField>();

            configuration.CreateMap <ProductFieldEditDto,ProductField>();
            configuration.CreateMap <ProductField,ProductFieldEditDto>();

        }
	}
}


using AutoMapper;
using YMApp.ECommerce.ProductAttributes;
using YMApp.ECommerce.ProductAttributes.Dtos;

namespace YMApp.ECommerce.ProductAttributes.Mapper
{

	/// <summary>
    /// 配置ProductAttribute的AutoMapper
    /// </summary>
	internal static class ProductAttributeMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ProductAttribute,ProductAttributeListDto>();
            configuration.CreateMap <ProductAttributeListDto,ProductAttribute>();

            configuration.CreateMap <ProductAttributeEditDto,ProductAttribute>();
            configuration.CreateMap <ProductAttribute,ProductAttributeEditDto>();

        }
	}
}

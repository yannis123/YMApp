
using AutoMapper;
using YMApp.ECommerce.Products;
using YMApp.ECommerce.Products.Dtos;

namespace YMApp.ECommerce.Products.Mapper
{

	/// <summary>
    /// 配置Product的AutoMapper
    /// </summary>
	internal static class ProductMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Product,ProductListDto>();
            configuration.CreateMap <ProductListDto,Product>();

            configuration.CreateMap <ProductEditDto,Product>();
            configuration.CreateMap <Product,ProductEditDto>();

        }
	}
}


using AutoMapper;
using YMApp.ECommerce.Articles;
using YMApp.ECommerce.Articles.Dtos;

namespace YMApp.ECommerce.Articles.Mapper
{

	/// <summary>
    /// 配置Article的AutoMapper
    /// </summary>
	internal static class ArticleMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Article,ArticleListDto>();
            configuration.CreateMap <ArticleListDto,Article>();

            configuration.CreateMap <ArticleEditDto,Article>();
            configuration.CreateMap <Article,ArticleEditDto>();

        }
	}
}

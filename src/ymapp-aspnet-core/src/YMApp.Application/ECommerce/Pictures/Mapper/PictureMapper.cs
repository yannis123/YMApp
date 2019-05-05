
using AutoMapper;
using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.Pictures.Dtos;

namespace YMApp.ECommerce.Pictures.Mapper
{

	/// <summary>
    /// 配置Picture的AutoMapper
    /// </summary>
	internal static class PictureMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Picture,PictureListDto>();
            configuration.CreateMap <PictureListDto,Picture>();

            configuration.CreateMap <PictureEditDto,Picture>();
            configuration.CreateMap <Picture,PictureEditDto>();

        }
	}
}


using AutoMapper;
using YMApp.DocManage.Documents;
using YMApp.DocManage.Documents.Dtos;

namespace YMApp.DocManage.Documents.Mapper
{

	/// <summary>
    /// 配置Document的AutoMapper
    /// </summary>
	internal static class DocumentMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Document,DocumentListDto>();
            configuration.CreateMap <DocumentListDto,Document>();

            configuration.CreateMap <DocumentEditDto,Document>();
            configuration.CreateMap <Document,DocumentEditDto>();

        }
	}
}


using AutoMapper;
using YMApp.ECommerce.Trips;
using YMApp.ECommerce.Trips.Dtos;

namespace YMApp.ECommerce.Trips.Mapper
{

	/// <summary>
    /// 配置Trip的AutoMapper
    /// </summary>
	internal static class TripMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Trip,TripListDto>();
            configuration.CreateMap <TripListDto,Trip>();

            configuration.CreateMap <TripEditDto,Trip>();
            configuration.CreateMap <Trip,TripEditDto>();

        }
	}
}

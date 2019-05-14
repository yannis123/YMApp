using System;
using AutoMapper;
using YMApp.Trips.Dtos;

namespace YMApp.Trips.Mapper
{
    public class TripMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Trip, TripListDto>();
            configuration.CreateMap<TripListDto, Trip>();

            configuration.CreateMap<TripEditDto, Trip>();
            configuration.CreateMap<Trip, TripEditDto>();

        }
    }
}

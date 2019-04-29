using System;
using AutoMapper;
using YMApp.Categorys.Dtos;

namespace YMApp.Categorys.Mapper
{
    public class CategoryMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryListDto>();
            configuration.CreateMap<CategoryListDto, Category>();

            configuration.CreateMap<CategoryEditDto, Category>();
            configuration.CreateMap<Category, CategoryEditDto>();

        }
    }
}

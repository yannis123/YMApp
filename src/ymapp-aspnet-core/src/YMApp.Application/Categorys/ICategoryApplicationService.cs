using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YMApp.Categorys.Dtos;

namespace YMApp.Categorys
{
    public interface ICategoryApplicationService : IApplicationService
    {
        /// <summary>
        /// 获取Book的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CategoryListDto>> GetPaged(GetCategorysInput input);


        /// <summary>
        /// 通过指定id获取BookListDto信息
        /// </summary>
        Task<CategoryListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCategoryForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改Book的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateCategoryInput input);


        /// <summary>
        /// 删除Book信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除Book
        /// </summary>
        Task BatchDelete(List<long> input);


        /// <summary>
        /// 导出Book为excel表
        /// </summary>
        /// <returns></returns>
        //Task<FileDto> GetToExcel();
    }
}

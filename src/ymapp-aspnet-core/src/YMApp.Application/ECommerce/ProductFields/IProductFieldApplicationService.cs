
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using YMApp.ECommerce.ProductFields.Dtos;
using YMApp.ECommerce.ProductFields;

namespace YMApp.ECommerce.ProductFields
{
    /// <summary>
    /// ProductField应用层服务的接口方法
    ///</summary>
    public interface IProductFieldAppService : IApplicationService
    {
        /// <summary>
		/// 获取ProductField的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ProductFieldListDto>> GetPaged(GetProductFieldsInput input);


		/// <summary>
		/// 通过指定id获取ProductFieldListDto信息
		/// </summary>
		Task<ProductFieldListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetProductFieldForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改ProductField的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateProductFieldInput input);


        /// <summary>
        /// 删除ProductField信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除ProductField
        /// </summary>
        Task BatchDelete(List<long> input);

        Task<List<ProductFieldListDto>> GetProductFieldByProductType(long productType);


		/// <summary>
        /// 导出ProductField为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}

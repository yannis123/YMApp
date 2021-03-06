
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


using YMApp.ECommerce.ProductAttributes.Dtos;
using YMApp.ECommerce.ProductAttributes;

namespace YMApp.ECommerce.ProductAttributes
{
    /// <summary>
    /// ProductAttribute应用层服务的接口方法
    ///</summary>
    public interface IProductAttributeAppService : IApplicationService
    {
        /// <summary>
		/// 获取ProductAttribute的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ProductAttributeListDto>> GetPaged(GetProductAttributesInput input);


		/// <summary>
		/// 通过指定id获取ProductAttributeListDto信息
		/// </summary>
		Task<ProductAttributeListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetProductAttributeForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改ProductAttribute的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateProductAttributeInput input);


        /// <summary>
        /// 删除ProductAttribute信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除ProductAttribute
        /// </summary>
        Task BatchDelete(List<long> input);

        Task<List<ProductAttributeListDto>> GetListByProductId(NullableIdDto<long> input);

        /// <summary>
        /// 导出ProductAttribute为excel表
        /// </summary>
        /// <returns></returns>
        //Task<FileDto> GetToExcel();

    }
}

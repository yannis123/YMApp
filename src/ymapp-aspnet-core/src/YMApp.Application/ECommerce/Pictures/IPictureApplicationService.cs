
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


using YMApp.ECommerce.Pictures.Dtos;
using YMApp.ECommerce.Pictures;

namespace YMApp.ECommerce.Pictures
{
    /// <summary>
    /// Picture应用层服务的接口方法
    ///</summary>
    public interface IPictureAppService : IApplicationService
    {
        /// <summary>
		/// 获取Picture的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PictureListDto>> GetPaged(GetPicturesInput input);


		/// <summary>
		/// 通过指定id获取PictureListDto信息
		/// </summary>
		Task<PictureListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPictureForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改Picture的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdatePictureInput input);


        /// <summary>
        /// 删除Picture信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除Picture
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出Picture为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}

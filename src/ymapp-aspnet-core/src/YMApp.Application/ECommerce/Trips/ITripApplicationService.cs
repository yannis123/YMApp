
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


using YMApp.ECommerce.Trips.Dtos;
using YMApp.ECommerce.Trips;

namespace YMApp.ECommerce.Trips
{
    /// <summary>
    /// Trip应用层服务的接口方法
    ///</summary>
    public interface ITripAppService : IApplicationService
    {
        /// <summary>
		/// 获取Trip的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<TripListDto>> GetPaged(GetTripsInput input);


		/// <summary>
		/// 通过指定id获取TripListDto信息
		/// </summary>
		Task<TripListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetTripForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改Trip的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateTripInput input);


        /// <summary>
        /// 删除Trip信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除Trip
        /// </summary>
        Task BatchDelete(List<long> input);

        Task ChangeAuditState(ChangetTripAuditStateDto input);

        /// <summary>
        /// 导出Trip为excel表
        /// </summary>
        /// <returns></returns>
        //Task<FileDto> GetToExcel();

    }
}

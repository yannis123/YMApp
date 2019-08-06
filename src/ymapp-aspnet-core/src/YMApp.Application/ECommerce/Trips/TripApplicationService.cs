
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using YMApp.ECommerce.Trips;
using YMApp.ECommerce.Trips.Dtos;
using YMApp.ECommerce.Trips.DomainService;
using YMApp.ECommerce.Trips.Authorization;


namespace YMApp.ECommerce.Trips
{
    /// <summary>
    /// Trip应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class TripAppService : YMAppAppServiceBase, ITripAppService
    {
        private readonly IRepository<Trip, long> _entityRepository;

        private readonly ITripManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public TripAppService(
        IRepository<Trip, long> entityRepository
        , ITripManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取Trip的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(TripPermissions.Query)]
        public async Task<PagedResultDto<TripListDto>> GetPaged(GetTripsInput input)
        {
            var query = _entityRepository.GetAll().Include(m => m.Category).AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name))
                .WhereIf(input.State.HasValue, m => m.State == input.State)
                .WhereIf(input.CategoryId.HasValue, m => m.CategoryId == input.CategoryId)
                //.WhereIf(input.CategoryId.HasValue, m => m.Category.ParentId == input.CategoryId)
                .WhereIf(input.Start.HasValue, m => m.CreationTime > input.Start)
                .WhereIf(input.End.HasValue, m => m.CreationTime < input.End);
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .Include(m => m.Category)
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<TripListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<TripListDto>>();

            return new PagedResultDto<TripListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取TripListDto信息
        /// </summary>
        [AbpAuthorize(TripPermissions.Query)]
        public async Task<TripListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<TripListDto>();
        }

        /// <summary>
        /// 获取编辑 Trip
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(TripPermissions.Create, TripPermissions.Edit)]
        public async Task<GetTripForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetTripForEditOutput();
            TripEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<TripEditDto>();

                //tripEditDto = ObjectMapper.Map<List<tripEditDto>>(entity);
            }
            else
            {
                editDto = new TripEditDto();
            }

            output.Trip = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Trip的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(TripPermissions.Create, TripPermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateTripInput input)
        {

            if (input.Trip.Id.HasValue)
            {
                await Update(input.Trip);
            }
            else
            {
                await Create(input.Trip);
            }
        }


        /// <summary>
        /// 新增Trip
        /// </summary>
        [AbpAuthorize(TripPermissions.Create)]
        protected virtual async Task<TripEditDto> Create(TripEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Trip>(input);
            var entity = input.MapTo<Trip>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<TripEditDto>();
        }

        /// <summary>
        /// 编辑Trip
        /// </summary>
        [AbpAuthorize(TripPermissions.Edit)]
        protected virtual async Task Update(TripEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Trip信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(TripPermissions.Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Trip的方法
        /// </summary>
        [AbpAuthorize(TripPermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task ChangeAuditState(ChangetTripAuditStateDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id.Value);
            entity.State = input.State;
            await _entityRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 导出Trip为excel表,等待开发。
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetToExcel()
        //{
        //	var users = await UserManager.Users.ToListAsync();
        //	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //	await FillRoleNames(userListDtos);
        //	return _userListExcelExporter.ExportToFile(userListDtos);
        //}

    }
}



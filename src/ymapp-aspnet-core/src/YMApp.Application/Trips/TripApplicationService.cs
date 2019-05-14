using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Microsoft.EntityFrameworkCore;
using YMApp.Trips.Dtos;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Abp.AutoMapper;

namespace YMApp.Trips
{
    public class TripApplicationService : YMAppAppServiceBase, ITripApplicationService
    {
        private readonly IRepository<Trip, long> _entityRepository;
        public TripApplicationService(IRepository<Trip, long> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

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
        protected virtual async Task<TripEditDto> Create(TripEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Book>(input);
            var entity = input.MapTo<Trip>();

            var entityId = await _entityRepository.InsertAndGetIdAsync(entity);

            return entity.MapTo<TripEditDto>();
        }

        protected virtual async Task Update(TripEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);

        }

        public async Task Delete(EntityDto<long> input)
        {
            await _entityRepository.DeleteAsync(input.Id);
        }

        public async Task<TripListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<TripListDto>();
        }

        public async Task<GetTripForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetTripForEditOutput();
            TripEditDto editDto;
            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<TripEditDto>();
            }
            else
            {
                editDto = new TripEditDto();
            }
            output.Trip = editDto;
            return output;
        }

        public async Task<PagedResultDto<TripListDto>> GetPaged(GetTripsInput input)
        {
            var query = _entityRepository
                 .GetAll().Include(p => p.Category)
                 .AsNoTracking()
                 // TODO:根据传入的参数添加过滤条件
                 .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), o => o.Name.Contains(input.FilterText));

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

            var entityListDtos = entityList.MapTo<List<TripListDto>>();

            return new PagedResultDto<TripListDto>(count, entityListDtos);
        }
    }
}

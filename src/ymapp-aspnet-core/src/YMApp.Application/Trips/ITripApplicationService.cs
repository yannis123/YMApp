using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YMApp.Trips.Dtos;

namespace YMApp.Trips
{
    public interface ITripApplicationService : IApplicationService
    {
        Task<PagedResultDto<TripListDto>> GetPaged(GetTripsInput input);



        Task<TripListDto> GetById(EntityDto<long> input);



        Task<GetTripForEditOutput> GetForEdit(NullableIdDto<long> input);



        Task CreateOrUpdate(CreateOrUpdateTripInput input);



        Task Delete(EntityDto<long> input);



        Task BatchDelete(List<long> input);



        //Task<FileDto> GetToExcel();
    }
}

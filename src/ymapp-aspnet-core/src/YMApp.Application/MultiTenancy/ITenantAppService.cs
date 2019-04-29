using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YMApp.MultiTenancy.Dto;

namespace YMApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

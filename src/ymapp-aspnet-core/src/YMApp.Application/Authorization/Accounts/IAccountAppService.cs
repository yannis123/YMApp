using System.Threading.Tasks;
using Abp.Application.Services;
using YMApp.Authorization.Accounts.Dto;

namespace YMApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

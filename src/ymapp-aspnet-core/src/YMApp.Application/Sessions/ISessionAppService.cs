using System.Threading.Tasks;
using Abp.Application.Services;
using YMApp.Sessions.Dto;

namespace YMApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YMApp.Roles.Dto;
using YMApp.Users.Dto;

namespace YMApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}

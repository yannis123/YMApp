using System.Collections.Generic;
using YMApp.Roles.Dto;
using YMApp.Users.Dto;

namespace YMApp.Web.ViewModels.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

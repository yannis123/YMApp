using System.Collections.Generic;
using YMApp.Roles.Dto;
using YMApp.Users.Dto;

namespace YMApp.Web.Admin.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

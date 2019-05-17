using System.Collections.Generic;
using YMApp.Roles.Dto;

namespace YMApp.Web.ViewModels.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}

using System.Collections.Generic;
using YMApp.Roles.Dto;

namespace YMApp.Web.ViewModels.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
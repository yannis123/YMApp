using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YMApp.Controllers;
using YMApp.Roles;
using YMApp.Roles.Dto;
using YMApp.Web.Admin.ViewModels.Roles;

namespace YMApp.Web.Admin.Controllers
{
    public class RolesController : YMAppControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Edit(NullableIdDto<int> input)
        {
            if (!input.Id.HasValue)
            {
                var permissions = await _roleAppService.GetAllPermissions();
                var role = new GetRoleForEditOutput()
                {
                    Role = new RoleEditDto(),
                    GrantedPermissionNames = new List<string>(),
                    Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions.Items)
                };
                return View(new EditRoleModalViewModel(role));
            }
            var output = await _roleAppService.GetRoleForEdit(new EntityDto(input.Id.Value));
            var model = new EditRoleModalViewModel(output);
            return View(model);
        }
    }
}
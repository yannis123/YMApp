using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using YMApp.Authorization;
using YMApp.Controllers;
using YMApp.Users;
using YMApp.Users.Dto;
using YMApp.Web.Admin.Models.Users;

namespace YMApp.Web.Admin
{
    [AbpMvcAuthorize(UserPermissions.Pages_Users)]
    public class UsersController : YMAppControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            //var users = (await _userAppService.GetAll(new PagedUserResultRequestDto {MaxResultCount = int.MaxValue})).Items; // Paging not implemented yet
            //var roles = (await _userAppService.GetRoles()).Items;
            //var model = new UserListViewModel
            //{
            //    Users = users,
            //    Roles = roles
            //};
            //return View(model);
            return View();
        }

        public async Task<ActionResult> Edit(NullableIdDto<long> input)
        {
            var model = new EditUserModalViewModel();
            if (input.Id.HasValue)
            {
                var user = await _userAppService.Get(new EntityDto<long>() { Id = input.Id.Value });
                model.User = user;
            }
            var roles = (await _userAppService.GetRoles()).Items;
            model.Roles = roles;
            return View(model);
        }
    }
}

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
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
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

        public async Task<ActionResult> Edit(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View( model);
        }
    }
}

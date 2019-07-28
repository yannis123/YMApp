using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Navigation;
using Abp.Runtime.Session;
using YMApp.Categorys;
using YMApp.ConstEnum;

namespace YMApp.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewComponent : YMAppViewComponent
    {
        private readonly ICategoryApplicationService _categoryAppService;
        private readonly IAbpSession _abpSession;

        public SideBarNavViewComponent(
            ICategoryApplicationService categoryAppService,
            IAbpSession abpSession)
        {
            _categoryAppService = categoryAppService;
            _abpSession = abpSession;
        }

        public async Task<IViewComponentResult> InvokeAsync(string activeMenu = "")
        {
            var model = new SideBarNavViewModel
            {
                Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.线路)
            };

            return View(model);
        }
    }
}

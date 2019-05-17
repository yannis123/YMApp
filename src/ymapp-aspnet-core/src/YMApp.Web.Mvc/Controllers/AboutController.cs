using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using YMApp.Controllers;

namespace YMApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : YMAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}

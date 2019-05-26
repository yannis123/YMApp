using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using YMApp.Controllers;

namespace YMApp.Web.Controllers
{
    public class HomeController : YMAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}

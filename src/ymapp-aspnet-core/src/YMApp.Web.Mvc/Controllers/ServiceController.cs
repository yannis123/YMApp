using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using YMApp.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMApp.Web.Controllers
{
    public class ServiceController : YMAppControllerBase
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}

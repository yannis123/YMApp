using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using YMApp.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMApp.Web.Controllers
{
    public class ProductController : YMAppControllerBase
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }
    }
}

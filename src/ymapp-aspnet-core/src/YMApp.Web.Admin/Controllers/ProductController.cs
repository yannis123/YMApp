using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMApp.Authorization;
using YMApp.Controllers;
using YMApp.ECommerce.Products;
using YMApp.ECommerce.Products.Authorization;
using YMApp.Web.Admin.Models.Products;

namespace YMApp.Web.Admin.Controllers
{
    [AbpMvcAuthorize(ProductPermissions.Node)]
    public class ProductController : YMAppControllerBase
    {
        IProductAppService _productservice;
        public ProductController(IProductAppService productservice)
        {
            _productservice = productservice;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}
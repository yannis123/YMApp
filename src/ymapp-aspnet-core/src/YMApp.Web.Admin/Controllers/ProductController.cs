using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YMApp.Controllers;
using YMApp.ECommerce.Products;
using YMApp.Web.Admin.Models.Products;

namespace YMApp.Web.Admin.Controllers
{
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

        public async Task<JsonResult> GetProductByPage(GetProductByPageRequest input)
        {
            var list = await _productservice.GetPaged(new ECommerce.Products.Dtos.GetProductsInput()
            {
                MaxResultCount = input.PageSize,
                SkipCount = input.PageIndex
            });



        }
    }
}
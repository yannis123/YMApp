using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMApp.Authorization;
using YMApp.Categorys;
using YMApp.Controllers;
using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.ProductFields;
using YMApp.ECommerce.Products;
using YMApp.ECommerce.Products.Authorization;
using YMApp.Web.Admin.Models.Products;

namespace YMApp.Web.Admin.Controllers
{
    [AbpMvcAuthorize(ProductPermissions.Node)]
    public class ProductController : YMAppControllerBase
    {
        IProductAppService _productservice;
        IProductFieldAppService _productFieldservice;
        IPictureAppService _pictureAppService;
        ICategoryApplicationService _categoryAppService;
        public ProductController(IProductAppService productservice
            , IProductFieldAppService productFieldservice
            , IPictureAppService pictureAppService
            , ICategoryApplicationService categoryAppService)
        {
            _productservice = productservice;
            _productFieldservice = productFieldservice;
            _pictureAppService = pictureAppService;
            _categoryAppService = categoryAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            EditProductViewModel model = new EditProductViewModel();

            var fields = await _categoryAppService.GetListByType(2);
            model.ProductFields = fields;
            model.Categorys = await _categoryAppService.GetListByType(1);
            return View(model);
        }
    }
}
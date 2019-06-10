using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMApp.Authorization;
using YMApp.Categorys;
using YMApp.ConstEnum;
using YMApp.Controllers;
using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.ProductAttributes;
using YMApp.ECommerce.ProductAttributes.Dtos;
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
        IProductAttributeAppService _productAttributeservice;
        public ProductController(IProductAppService productservice
            , IProductFieldAppService productFieldservice
             , IProductAttributeAppService productAttributeservice
            , IPictureAppService pictureAppService
            , ICategoryApplicationService categoryAppService)
        {
            _productservice = productservice;
            _productFieldservice = productFieldservice;
            _pictureAppService = pictureAppService;
            _categoryAppService = categoryAppService;
            _productAttributeservice = productAttributeservice;
        }

        public async Task<IActionResult> Index()
        {
            ProductIndeViewModel model = new ProductIndeViewModel();
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.商品);
            return View(model);
        }

        public async Task<IActionResult> Edit(NullableIdDto<long> input)
        {
            EditProductViewModel model = new EditProductViewModel();
            List<ProductAttributeListDto> attributes = new List<ProductAttributeListDto>();

            var prtoductForEditModel = await _productservice.GetForEdit(input);
            model.Product = prtoductForEditModel.Product;
            attributes = await _productAttributeservice.GetListByProductId(input);
            if (prtoductForEditModel.Pictures != null && prtoductForEditModel.Pictures.Count > 0)
            {
                model.Pictutres = prtoductForEditModel.Pictures.Select(m => m.Url).ToList();
            }
            var fields = await _productFieldservice.GetProductFieldByProductType(1);
            foreach (var item in fields)
            {
                if (attributes.Select(m => m.FieldId).Contains(item.Id))
                {
                    item.FieldValue = attributes.Single(m => m.FieldId == item.Id).FieldValue;
                }
            }

            model.ProductFields = fields;
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.商品);

            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YMApp.Categorys;
using YMApp.Controllers;
using YMApp.Web.Admin.Models.Category;

namespace YMApp.Web.Admin.Controllers
{
    public class CategoryController : YMAppControllerBase
    {
        ICategoryApplicationService _categoryAppService;
        public CategoryController(ICategoryApplicationService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public async Task<IActionResult> Index()
        {
            CategoryIndexViewModel model = new CategoryIndexViewModel();
            model.Categorys = (await _categoryAppService.GetPaged(new Categorys.Dtos.GetCategorysInput() { SkipCount = 0, MaxResultCount = 200 })).Items;
            return View(model);
        }

        public async Task<IActionResult> Edit(NullableIdDto<long> input)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            model.Category = (await _categoryAppService.GetForEdit(input)).Category;
            model.Categorys = await _categoryAppService.GetListByType(0);
            return View(model);
        }
    }
}
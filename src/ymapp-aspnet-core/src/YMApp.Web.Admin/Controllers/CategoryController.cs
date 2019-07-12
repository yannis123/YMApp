using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using YMApp.Categorys;
using YMApp.Categorys.Dtos;
using YMApp.Controllers;
using YMApp.Core;
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

        [DontWrapResult]
        public async Task<JsonResult> GetCategoryTree(long selectedId)
        {
            List<CategoryTreeViewModel> treeViewModelList = new List<CategoryTreeViewModel>();
            var list = (await _categoryAppService.GetPaged(new GetCategorysInput() { SkipCount = 0, MaxResultCount = AppLtmConsts.MaxPageSize, Sorting = "", FilterText = "" })).Items;
            var treeList = GetCategoryTree(0, selectedId, list);
            treeViewModelList.Add(new CategoryTreeViewModel() { Id = 0, Checked = false, Children = treeList, Name = "所有分类", Open = true });
            return Json(treeViewModelList);
        }

        private List<CategoryTreeViewModel> GetCategoryTree(long parentId, long selectedId, IReadOnlyList<CategoryListDto> list)
        {
            if (list == null || list.Count == 0) return null;
            List<CategoryTreeViewModel> treeViewModelList = new List<CategoryTreeViewModel>();
            var result = list.Where(m => m.ParentId == parentId).ToList();
            foreach (var item in result)
            {
                CategoryTreeViewModel model = new CategoryTreeViewModel()
                {
                    Checked = (item.Id == selectedId),
                    Id = item.Id,
                    Name = item.Name,
                    Open = false,
                    Children = GetCategoryTree(item.Id, selectedId, list)
                };
                treeViewModelList.Add(model);
            }
            return treeViewModelList.Count() == 0 ? null : treeViewModelList;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YMApp.Categorys;
using YMApp.ConstEnum;
using YMApp.Controllers;
using YMApp.ECommerce.Articles;
using YMApp.Web.Admin.Models.Article;

namespace YMApp.Web.Admin.Controllers
{
    public class ArticleController : YMAppControllerBase
    {
        ICategoryApplicationService _categoryAppService;
        IArticleAppService _articleAppService;
        public ArticleController(
             IArticleAppService articleAppService
            , ICategoryApplicationService categoryAppService)
        {
            _articleAppService = articleAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            ArticleIndexViewModel model = new ArticleIndexViewModel();
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.文章);
            return View(model);
        }

        public async Task<IActionResult> Edit(NullableIdDto<long> input)
        {
            EditArticleViewModel model = new EditArticleViewModel();
            model.Article = (await _articleAppService.GetForEdit(input)).Article;
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.文章);
            return View(model);
        }
    }
}
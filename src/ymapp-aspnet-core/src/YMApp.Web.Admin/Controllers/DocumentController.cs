using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YMApp.Categorys;
using YMApp.ConstEnum;
using YMApp.Controllers;
using YMApp.DocManage.Documents;
using YMApp.Web.Admin.Models.Document;

namespace YMApp.Web.Admin.Controllers
{
    public class DocumentController : YMAppControllerBase
    {
        ICategoryApplicationService _categoryAppService;
        IDocumentAppService _documentAppService;

        public DocumentController(
            ICategoryApplicationService categoryAppService,
            IDocumentAppService documentAppService
            )
        {
            _categoryAppService = categoryAppService;
            _documentAppService = documentAppService;
        }

        public async Task<IActionResult> Index()
        {
            DocumentIndexViewModel model = new DocumentIndexViewModel();
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.文件);
            return View(model);
        }

        public async Task<IActionResult> Edit(NullableIdDto<long> input)
        {
            EditDocumentViewModel model = new EditDocumentViewModel();
            model.Document = (await _documentAppService.GetForEdit(input)).Document;
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.文件);
            return View(model);
        }
    }
}
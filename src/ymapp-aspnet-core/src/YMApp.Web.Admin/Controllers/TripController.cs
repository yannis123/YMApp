using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YMApp.Categorys;
using YMApp.ConstEnum;
using YMApp.Controllers;
using YMApp.ECommerce.Trips;
using YMApp.Web.Admin.Models.Trip;

namespace YMApp.Web.Admin.Controllers
{
    public class TripController : YMAppControllerBase
    {
        ICategoryApplicationService _categoryAppService;
        ITripAppService _tripAppService;
        public TripController(
             ITripAppService tripAppService
            , ICategoryApplicationService categoryAppService)
        {
            _tripAppService = tripAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            TripIndexViewModel model = new TripIndexViewModel();
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.线路);
            return View(model);
        }

        public async Task<IActionResult> Edit(NullableIdDto<long> input)
        {
            EditTripViewModel model = new EditTripViewModel();
            model.Trip = (await _tripAppService.GetForEdit(input)).Trip;
            model.Categorys = await _categoryAppService.GetListByType((int)CategoryTypeEnum.线路);
            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YMApp.Categorys;
using YMApp.Controllers;
using YMApp.ECommerce.Trips;
using YMApp.Web.Travel.Models.Trip;

namespace YMApp.Web.Travel.Controllers
{
    public class TripController : YMAppControllerBase
    {
        private ITripAppService _tripAppService;
        private ICategoryApplicationService _ctegoryAppService;
        public TripController(ITripAppService tripAppService
            , ICategoryApplicationService ctegoryAppService)
        {
            _tripAppService = tripAppService;
            _ctegoryAppService = ctegoryAppService;
        }
        public async Task<IActionResult> List(TripListRequestModel input)
        {

            int pageSize = 20;
            var trips = await _tripAppService.GetPaged(new ECommerce.Trips.Dtos.GetTripsInput()
            {
                CategoryId = input.CategoryId,
                MaxResultCount = pageSize,
                SkipCount = (input.PageIndex - 1) * pageSize
            });

            var model = new TripListViewModel()
            {
                Category = await _ctegoryAppService.GetById(new Abp.Application.Services.Dto.EntityDto<long>() { Id = input.CategoryId }),
                Trips = trips.Items.ToList()
            };
            return View(model);
        }
        public async Task<IActionResult> Index(long id)
        {
            var trip = await _tripAppService.GetById(new Abp.Application.Services.Dto.EntityDto<long>() { Id = id });
            return View(trip);
        }
    }
}
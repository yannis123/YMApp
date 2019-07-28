using System;
using System.Collections.Generic;
using YMApp.Categorys;
using YMApp.Categorys.Dtos;
using YMApp.ECommerce.Trips.Dtos;

namespace YMApp.Web.Travel.Models.Trip
{
    public class TripListViewModel
    {
        public CategoryListDto Category { get; set; }
        public List<TripListDto> Trips { get; set; }
    }
}

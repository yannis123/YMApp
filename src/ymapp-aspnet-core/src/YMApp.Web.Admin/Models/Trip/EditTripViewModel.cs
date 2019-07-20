using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMApp.Categorys.Dtos;
using YMApp.ECommerce.Trips.Dtos;

namespace YMApp.Web.Admin.Models.Trip
{
    public class EditTripViewModel
    {
        public List<CategoryListDto> Categorys { get; set; }
        public TripEditDto Trip { get; set; }
    }
}

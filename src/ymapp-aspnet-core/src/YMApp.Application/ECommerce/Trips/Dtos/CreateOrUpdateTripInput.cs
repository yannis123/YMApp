

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Trips;

namespace YMApp.ECommerce.Trips.Dtos
{
    public class CreateOrUpdateTripInput
    {
        [Required]
        public TripEditDto Trip { get; set; }

    }
}